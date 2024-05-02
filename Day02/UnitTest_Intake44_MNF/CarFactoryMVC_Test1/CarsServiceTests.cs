using CarFactoryMVC.Entities;
using CarFactoryMVC.Repositories_DAL;
using CarFactoryMVC.Services_BLL;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CarFactoryMVC_Test1
{
   
    public class CarsServiceTests : IDisposable
    {
        private readonly ITestOutputHelper outputHelper;
        Mock<ICarsRepository> MockRepoCar;
        CarsService carsService;
        public CarsServiceTests(ITestOutputHelper outputHelper) 
        {
            this.outputHelper = outputHelper;
            outputHelper.WriteLine("Test Setup");

            MockRepoCar = new Mock<ICarsRepository>();
            carsService = new CarsService(MockRepoCar.Object);
        }

        public IHelpService HelpService { get; }

        public void Dispose()
        {
            outputHelper.WriteLine("Test Cleanup");
        }

        [Fact]
        public void GetAll_ListOfCars_Cars()
        {
            outputHelper.WriteLine("GetAll_ListOfCars_Cars");

            ////arrange
            ////create mock for dependencies
            //Mock<ICarsRepository> MockRepoCar = new Mock<ICarsRepository>();

            //prepare data
            List<Car> cars = new List<Car>
            {
                new Car { Id = 1},
                new Car { Id = 2},
                new Car { Id = 3}
            };

            //make setup for mock
            MockRepoCar.Setup(cr=>cr.GetAllCars()).Returns(cars);

            //act
            //CarsService carsService = new CarsService(MockRepoCar.Object);
            var cars1 = carsService.GetAll();
            
            //assert
            Assert.Equal(3, cars1.Count);
        }

        [Fact]
        public void GetCarById_CarID_Car()
        {
            outputHelper.WriteLine("GetCarById_CarID_Car");

            //arrange 
            //prepare data
            Car car = new Car() { Id = 1 };

            //make setup for mock
            MockRepoCar.Setup(cr=>cr.GetCarById(1)).Returns(car);

            //act
            var car1 = carsService.GetCarById(1);

            //assert
            Assert.NotNull(car1);
            Assert.True(car1.Id == 1);
            Assert.Same(car, car1);
        }

        [Fact]
        public void AddCar_CarAdded_True()
        {
            outputHelper.WriteLine("AddCar_CarAdded_True");

            //arrange 
            //prepare data
            Car car = new Car { Id = 1 };

            //make setup for mock
            MockRepoCar.Setup(cr => cr.AddCar(car)).Returns(true);

            //act
            var result = carsService.AddCar(car);

            //assert
            Assert.True(result);
        }
    }
}
