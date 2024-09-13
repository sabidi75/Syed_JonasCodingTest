using BusinessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetAllCompaniesAsync();
        Task<EmployeeInfo> GetEmployeeByCodeAsync(string EmployeeCode);
        Task<EmployeeInfo> SaveEmployeeAsync(EmployeeInfo EmployeeInfo);
        Task<EmployeeInfo> UpdateEmployeeAsync(string EmployeeCode, EmployeeInfo EmployeeInfo);
        Task<EmployeeInfo> DeleteEmployeeAsync(string EmployeeCode);
    }
}
