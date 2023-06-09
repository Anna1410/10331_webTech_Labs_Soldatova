using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10331_webTech_Labs.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? AvatarImage { get; set; }
    }
}
