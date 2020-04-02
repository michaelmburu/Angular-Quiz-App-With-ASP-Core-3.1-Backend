using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_Backend.Models
{
    public class Credentials : IdentityUser
    {
        public string Password { get; set; }
    }
}
