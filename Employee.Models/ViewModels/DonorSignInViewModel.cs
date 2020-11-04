using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Models.ViewModels
{
    public class DonorSignInViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class DonorSignInResponseViewModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
