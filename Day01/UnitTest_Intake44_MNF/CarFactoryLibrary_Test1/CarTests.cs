using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test1
{
    public class CarTests
    {
        [Fact]
        [Trait("Author", "Mohamed")]
        public void Stop_Velocit15CarModeForward_velocity0CarModeStop()
        {
            Car car = new Toyota { velocity = 15, drivingMode = DrivingMode.Forward };

            car.Stop();

            Assert.Equal(DrivingMode.Stopped, car.drivingMode);
            Assert.Equal(0, car.velocity);
        }

        [Fact]
        public void IncreaseVelocity_Velocity15IncreaseBy3_Velocity18()
        {
            Car car = new BMW { velocity = 15,drivingMode = DrivingMode.Forward };

            car.IncreaseVelocity(3);

            Assert.Equal(18, car.velocity);
        }

        [Fact(Skip = "Working on it")]
        public void Accelerate_Velocity10_VelocityIncreased()
        {
            Car car = new BMW();

            car.Accelerate();

            //Assert.InRange(car.velocity, 0, 15);
            Assert.NotInRange(car.velocity, 0, 15);
        }

        [Fact]
        [Trait("Author","Mohamed")]
        public void TimeToCoverDistance_velocity3Distance15_Time5()
        {
            Car car = new BMW { velocity=3,drivingMode = DrivingMode.Forward};

            var result = car.TimeToCoverDistance(15);

            Assert.Equal(5, result);
        }

        [Fact]
        [Trait("Author", "Mohamed")]
        public void GetMyCar_Car_NotSame()
        {
            Car car1 = new BMW();
            Car car2 = new Toyota();

            Car car3 = car1.GetMyCar();
            
            Assert.NotSame(car2,car3);
        }

        [Fact]
        public void GetMyCar_Car_Equal()
        {
            Car car1 = new BMW { velocity = 15,drivingMode= DrivingMode.Backward};
            Car car2 = new Toyota { velocity = 15, drivingMode = DrivingMode.Backward };

            Car car3 = car1.GetMyCar();

            Assert.Equal(car2, car3);
        }

    }
}
