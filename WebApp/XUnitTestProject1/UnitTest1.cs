using Data.Dbmodels;
using Data.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using WebApp.Controllers;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnListOfUsersWithoutPassword()
        {
            // Arrange
            var users = new List<User>()
            {
                new User()
                {
                    Username = "konto1",
                    Password = "konto1",
                    Email = "konto1@api.pl"
                },
                new User()
                {
                    Username = "konto2",
                    Password = "konto2",
                    Email = "konto2@api.pl"
                },
            };

            var usersDto = new List<UserDto>()
            {
                new UserDto()
                {
                    Username = "konto1",
                    Email = "konto1@api.pl"
                },
                new UserDto()
                {
                    Username = "konto2",
                    Email = "konto2@api.pl"
                },
            };

            var userRepository = new Mock<IRepository<User>>();
            userRepository.Setup(x => x.GetAll()).Returns(users);
            var userService = new UserService(userRepository.Object);
            var userController = new UserController(userService);

            // Act
            var result = userController.Get();

            // Assert
            Assert.Equal(usersDto, result);

        }
    }
}
