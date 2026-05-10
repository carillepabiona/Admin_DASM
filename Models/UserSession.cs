using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_DASM.Models
{
    public class UserSession
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = "";

        public string FullName { get; set; } = "";

        public string Email { get; set; } = "";

        public string ContactNumber { get; set; } = "";

        public string Address { get; set; } = "";

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
