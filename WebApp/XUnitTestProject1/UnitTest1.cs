using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnListOfUsers()
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

            var userRepository = new Mock<IRepository<User>>();
            userRepository.Setup(x => x.GetAll()).Returns(users);
            var userService = new UserService(userRepository.Object);
            var userController = new UserController(userService);

            // Act
            var result = userController.Get();

            // Assert
            Assert.Equal(users, result);

        }
    }

    public class UserController : Controller
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        public List<User> Get()
        {
            var users = _userService.GetUser();
            return users;
        }
    }

    public interface IUserService
    {
        List<User> GetUser();
    }

    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<User> GetUser()
        {
            var users = _userRepository.GetAll();
            return users;
        }
    }

    public interface IRepository<T> where T : Entity
    {
        List<T> GetAll();
    }

    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class Entity
    {
        public long Id { get; set; }
    }
}
