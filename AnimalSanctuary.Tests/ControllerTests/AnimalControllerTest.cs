using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;
using AnimalSanctuary.Controllers;
using Moq;
using System.Linq;

namespace AnimalSanctuary.Tests.ControllerTests
{

    [TestClass]
    public class AnimalControllerTests
    {
        Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Animals).Returns(new Animal[]
            {
                new Animal {AnimalId = 1, Name = "Biscuit", Species = "American Bison", Sex = "Male", HabitatType = "Prairies", MedicalEmergency = false, VeterinarianId = 1 },
                new Animal {AnimalId = 2, Name = "Angus", Species = "Common turkey", Sex = "Male", HabitatType = "Grasslands", MedicalEmergency = false, VeterinarianId = 2 },
                new Animal {AnimalId = 3, Name = "Black Beauty", Species = "Cape raven", Sex = "Female", HabitatType = "High desert,", MedicalEmergency = true, VeterinarianId = 3 }
            }.AsQueryable());
        }


        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of animals
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new AnimalController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsAnimals_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Name = "Biscuit";
            testAnimal.AnimalId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Animal> collection = indexView.ViewData.Model as List<Animal>;

            // Assert
            CollectionAssert.Contains(collection, testAnimal);
        }
        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Animal testAnimal = new Animal
            {
                AnimalId = 1,
                Name = "Biscuit"
            };

            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);

            // Act
            var resultView = controller.Create(testAnimal) as ViewResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }
        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Animal testAnimal = new Animal
            {
                AnimalId = 1,
                Name = "Biscuit"
            };

            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);

            // Act
            var resultView = controller.Details(testAnimal.AnimalId) as ViewResult;
            var model = resultView.ViewData.Model as Animal;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Animal));
        }
    }
}