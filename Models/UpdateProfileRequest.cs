using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_DASM.Models
{
    public class UpdateProfileRequest
    {
        public string ContactNumber { get; set; } = "";

        public string Address { get; set; } = "";
    }
}
