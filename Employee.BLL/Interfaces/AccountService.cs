using Employee.DAL.UnitOfWorkPattern;
using Employee.Models.Entities;
using Employee.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL.Interfaces
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool Register(DonorRegisterViewModel model)
        {
            bool result = false;
            if (model != null)
            {
                var repo = unitOfWork.GetRepository<Donors>();

                var donor = new Donors
                {
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age,
                    City = model.City,
                    Country = model.Country,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    Phone = model.Phone,
                    Pincode = model.Pincode,
                    State = model.State
                };

                repo.Insert(donor);
                unitOfWork.Save();
                result = true;
            }

            return result;
        }
        public DonorSignInResponseViewModel SignIn(DonorSignInViewModel model)
        {

            if (model != null)
            {
                try
                {
                    var repo = unitOfWork.GetRepository<Donors>();
                    var query = repo.Get();

                    var donor =  query.Where(x => (x.Email == model.Email && x.Password == model.Password)).Select(x => x).FirstOrDefault();

                    if (donor != null)
                    {
                        var resultedDonor = new DonorSignInResponseViewModel
                        {
                            Email = donor.Email
                        };

                        return resultedDonor;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return null;
        }
    }
}
