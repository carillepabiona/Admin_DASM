using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_DASM.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }

        public int RoleId { get; set; }
        public int AccessLevelId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
