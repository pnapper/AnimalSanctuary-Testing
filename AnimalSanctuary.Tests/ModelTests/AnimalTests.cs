using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalSanctuary.Models;

namespace AnimalSanctuary.Tests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void GetSpecies_ReturnsAnimalSpecies_String()
        {
            //Arrange
            var animal = new Animal();
            animal.Species = "Black Spider Monkey";

            //Act
            var result = animal.Species;

            //Assert
            Assert.AreEqual("Black Spider Monkey", result);
        }
    }
}