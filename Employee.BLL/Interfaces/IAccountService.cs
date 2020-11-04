using Employee.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL.Interfaces
{
    public interface IAccountService
    {
        DonorSignInResponseViewModel SignIn(DonorSignInViewModel model);
        bool Register(DonorRegisterViewModel model);
    }
}
