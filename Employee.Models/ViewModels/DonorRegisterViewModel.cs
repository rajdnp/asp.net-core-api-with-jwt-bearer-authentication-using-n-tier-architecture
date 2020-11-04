using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Models.ViewModels
{
    public class DonorRegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string Password { get; set; }
    }
}
