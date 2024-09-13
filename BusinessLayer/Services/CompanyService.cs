﻿using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync()
        {
            var res = await _companyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            var result = await _companyRepository.GetByCodeAsync(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<CompanyInfo> SaveCompanyAsync(CompanyInfo companyInfo)
        {
            var company = _mapper.Map<DataAccessLayer.Model.Models.Company>(companyInfo);
            var result = await _companyRepository.SaveCompanyAsync(company);
            return _mapper.Map<CompanyInfo>(company);
        }

        public async Task<CompanyInfo> UpdateCompanyAsync(string companyCode, CompanyInfo companyInfo)
        {
            var company = _mapper.Map<DataAccessLayer.Model.Models.Company>(companyInfo);
            var result = await _companyRepository.UpdateCompanyAsync(companyCode, company);
            return _mapper.Map<CompanyInfo>(company);
        }

        public async Task<CompanyInfo> DeleteCompanyAsync(string companyCode)
        {
            var result = await _companyRepository.DeleteCompanyAsync(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }
    }
}
