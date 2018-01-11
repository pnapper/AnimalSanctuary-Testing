using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalSanctuary.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AnimalSanctuary.Models
{
    public class EFAnimalRepository : IAnimalRepository
    {
        AnimalSanctuaryContext db;

        public EFAnimalRepository()
        {
            db = new AnimalSanctuaryContext();
        }
        public EFAnimalRepository(AnimalSanctuaryContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Animal> Animals
        { get { return db.Animals; } }

        public Animal Save(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
            return animal;
        }

        public Animal Edit(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return animal;
        }

        public void Remove(Animal animal)
        {
            db.Animals.Remove(animal);
            db.SaveChanges();
        }

        public void ClearAll()
        {
            List<Animal> AllAnimals = db.Animals.ToList();
            db.Animals.RemoveRange(AllAnimals);
            db.SaveChanges();
        }
    }
}