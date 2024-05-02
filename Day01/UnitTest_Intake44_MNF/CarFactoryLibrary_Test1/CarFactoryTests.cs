using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Test1
{
    public class CarFactoryTests
    {
        [Fact]
        public void NewCar_AskForHonda_Exception()
        {
            Assert.Throws<NotImplementedException>(() => CarFactory.NewCar(CarTypes.Honda));
        }

        [Fact]
        [Trait("Author", "Mohamed")]
        public void NewCar_AskForBMW_BMW()
        {
            var res = CarFactory.NewCar(CarTypes.BMW);

            Assert.NotNull(res);
            Assert.IsType<BMW>(res);
        }

        [Fact]
        public void NewCar_AskForAudi_Null()
        {
            var res = CarFactory.NewCar(CarTypes.Audi);

            Assert.Null(res);
        }
    }
}
