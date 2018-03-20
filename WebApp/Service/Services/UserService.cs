using Data.Dbmodels;
using Data.ModelsDto;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<UserDto> GetUser()
        {
            var users = _userRepository.GetAll();
            var usersDto = new List<UserDto>();
            users.ForEach(x => usersDto.Add(new UserDto() { Id = x.Id, Username = x.Username, Email = x.Email }));
            return usersDto;
        }
    }
}
