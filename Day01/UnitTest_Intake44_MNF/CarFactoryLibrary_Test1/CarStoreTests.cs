using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test1
{
    public class CarStoreTests
    {
        [Fact]
        [Trait("Author", "Mohamed")]
        public void AddCar_BMWCar_Added()
        {
            CarStore carStore = new CarStore();

            Car car = new BMW { velocity = 15, drivingMode = DrivingMode.Backward };

            carStore.AddCar(car);

            Assert.Contains<Car>(car, carStore.cars);
        }

        [Fact]
        public void AddCar_ListofCars_NotEmpty()
        {
            CarStore carStore = new CarStore();

            List<Car> cars = new List<Car>
            {
                new BMW(),
                new Toyota(),
                new Toyota(){velocity=15, drivingMode=DrivingMode.Backward}
            };
            carStore.AddCars(cars);

            Assert.NotEmpty(carStore.cars);
        }
    }
}
