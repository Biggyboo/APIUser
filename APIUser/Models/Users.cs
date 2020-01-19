using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser.Models
{
    public class Users
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Bio { get; set; }
    }
}
