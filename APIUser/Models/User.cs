using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
    }
}
