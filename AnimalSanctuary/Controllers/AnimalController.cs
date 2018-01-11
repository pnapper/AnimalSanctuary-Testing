using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalSanctuary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalSanctuary.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalRepository animalRepo;  // New!

        public AnimalController(IAnimalRepository repo = null)
        {
            if (repo == null)
            {
                this.animalRepo = new EFAnimalRepository();
            }
            else
            {
                this.animalRepo = repo;
            }
        }

        public ViewResult Index()
        {
            // Updated:
            return View(animalRepo.Animals.ToList());
        }
    }

}
