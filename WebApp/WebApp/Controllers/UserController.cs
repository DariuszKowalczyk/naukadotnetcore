using Data.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        public List<UserDto> Get()
        {
            var users = _userService.GetUser();
            return users;
        }
    }
}
