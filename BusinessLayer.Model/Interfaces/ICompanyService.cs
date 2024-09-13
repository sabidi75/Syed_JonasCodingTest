using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync();
        Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode);
        Task<CompanyInfo> SaveCompanyAsync(CompanyInfo companyInfo);
        Task<CompanyInfo> UpdateCompanyAsync(string companyCode, CompanyInfo companyInfo);
        Task<CompanyInfo> DeleteCompanyAsync(string companyCode);
    }
}
