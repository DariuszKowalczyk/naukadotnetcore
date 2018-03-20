using Data.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetUser();
    }
}
