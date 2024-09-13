using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Microsoft.Extensions.Logging;
using WebApi.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ILogger _logger;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILogger logger)
        {
            _logger = logger;
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        [LogApiRequestAttribute]
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try 
            {
                var items = await _companyService.GetAllCompaniesAsync();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyController.GetAll");
                throw;
            }
        }

        // GET api/<controller>/5
        [LogApiRequestAttribute]
        public async Task<CompanyDto> Get(string companyCode)
        {
            try
            {
                var item = await _companyService.GetCompanyByCodeAsync(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyController.Get");
                throw;
            }
        }

        // POST api/<controller>
        [LogApiRequestAttribute]
        public async Task<CompanyDto> Post([FromBody]CompanyDto value)
        {
            try
            {

                var item = _mapper.Map<CompanyInfo>(value);
                var result = await _companyService.SaveCompanyAsync(item);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyController.Post");
                throw;
            }
        }

        // PUT api/<controller>/5
        [LogApiRequestAttribute]
        public async Task Put(string companyCode, [FromBody] CompanyInfo value)
        {
            try
            {
                var item = _mapper.Map<CompanyInfo>(value);
                await _companyService.SaveCompanyAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyController.Put");
                throw;
            }
        }

        // DELETE api/<controller>/5
        [LogApiRequestAttribute]
        public async Task Delete(string companyCode)
        {
            try
            {
                await _companyService.DeleteCompanyAsync(companyCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompanyController.Delete");
                throw;
            }
        }
    }
}