using CarFactoryMVC.Entities;
using CarFactoryMVC.Repositories_DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryMVC_Test1
{
    public class OwnerRepositoryTests
    {
        Mock<FactoryContext> mockFactoryContext;
        OwnerRepository ownerRepository;
        public OwnerRepositoryTests()
        {
            mockFactoryContext = new Mock<FactoryContext>();
            ownerRepository = new OwnerRepository(mockFactoryContext.Object);
        }

        [Fact]
        public void GetAllOwners_ReturnOwnerList()
        {
            //// Arrange
            //// Create mock of dependencies
            //Mock<FactoryContext> mockFactoryContext = new Mock<FactoryContext>();

            // prepare mock data
            List<Owner> owners = new List<Owner>()
            {
                new Owner { Id = 1},
                new Owner { Id = 2},
                new Owner { Id = 3},
            };

            // setup called Dbset
            mockFactoryContext.Setup<DbSet<Owner>>(con => con.Owners).ReturnsDbSet(owners);

            //// use the fake object as dependency
            //OwnerRepository ownerRepository = new OwnerRepository(mockFactoryContext.Object);

            // Act
            List<Owner> res = ownerRepository.GetAllOwners();

            // Assert
            Assert.Equal(3,res.Count);
        }
    }
}
