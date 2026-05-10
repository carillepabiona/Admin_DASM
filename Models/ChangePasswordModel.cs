using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_DASM.Models
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set; } = "";

        public string NewPassword { get; set; } = "";

        public string ConfirmPassword { get; set; } = "";
    }
}
