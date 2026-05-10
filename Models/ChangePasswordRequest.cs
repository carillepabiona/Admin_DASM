using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_DASM.Models
{
    public class ChangePasswordRequest
    {
        public string CurrentPassword { get; set; } = "";

        public string NewPassword { get; set; } = "";
    }
}
