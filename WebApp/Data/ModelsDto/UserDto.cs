using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ModelsDto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            var user = (UserDto)obj;
            return user.Username == Username && user.Email == Email && user.Id == Id;
        }
    }
}
