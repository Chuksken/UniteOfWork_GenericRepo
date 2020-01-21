using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniteOfWork.Data.Infrastracture;
using UniteOfWork.Data.Models;

namespace UniteOfWork.Data.Repository
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        //Employee GetByDepositSlipNumber(string depositSlipNumber);
        long Add(Employee emp);
        bool Update(Employee emp);


        //bool Delete(int id);
    }

    public class EmployeeRepo : BaseService, IEmployeeRepo, IDisposable
    {

        private readonly IRepository<Employee> _otherRequestRepo;

        public EmployeeRepo()
        {
            _otherRequestRepo = new BaseRepository<Employee>(this.unitOfWork);
        }

        #region CRUD_Area
        public IEnumerable<Employee> GetAll()
        {
            return _otherRequestRepo.All.AsNoTracking()
                  .ToList();
        }
        public Employee GetById(int id)
        {
            return this._otherRequestRepo.Find(id);
        }

    
        public long Add(Employee oOtherRequest)
        {
            this._otherRequestRepo.Add(oOtherRequest);
            this.unitOfWork.SaveChanges();
            return oOtherRequest.Id;
        }

        public bool Update(Employee oOtherRequest)
        {
            var originalPayment = _otherRequestRepo.Find(oOtherRequest.Id);
            originalPayment.Name = oOtherRequest.Name;
            originalPayment.Address = oOtherRequest.Address;
            originalPayment.Age = oOtherRequest.Age;
           
            this._otherRequestRepo.Edit(originalPayment);
            var numberOfRecordsAffected = this.unitOfWork.SaveChanges();
            if (numberOfRecordsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var originalPayments = this._otherRequestRepo.Find(id);
            this._otherRequestRepo.Delete(originalPayments);
            return true;
        }
        #endregion

        public void Dispose()
        {
            this.unitOfWork.Dispose();
            this._otherRequestRepo.Dispose();
        }


      
    }
}
