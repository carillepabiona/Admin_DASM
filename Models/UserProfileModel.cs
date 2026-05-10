using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_DASM.Models
{
    public class UserProfileModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool EmailNotifications { get; set; }

        public bool PushNotifications { get; set; }

        public bool MarketingEmails { get; set; }

        public bool ActivityDigest { get; set; }

        public string Theme { get; set; }

        public string Language { get; set; }

        public string FontSize { get; set; }

        public bool ProfilePublic { get; set; }

        public bool ShowActivityStatus { get; set; }

        public bool AllowMessages { get; set; }
    }
}
