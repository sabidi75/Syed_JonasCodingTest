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
    public class EmployeeController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger logger)
        {
            _logger = logger;
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET api/<controller>
        [LogApiRequestAttribute]
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            try
            {
                var items = await _employeeService.GetAllCompaniesAsync();
                return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in EmployeeController.GetAll");
                throw;
            }
        }

        // GET api/<controller>/5
        [LogApiRequestAttribute]
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            try
            {
                var item = await _employeeService.GetEmployeeByCodeAsync(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in EmployeeController.Get");
                throw;
            }
        }

        // POST api/<controller>
        [LogApiRequestAttribute]
        public async Task<EmployeeDto> Post([FromBody] EmployeeDto value)
        {
            try
            {
                var item = _mapper.Map<EmployeeInfo>(value);
                var result = await _employeeService.SaveEmployeeAsync(item);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in EmployeeController.Post");
                throw;
            }
        }

        // PUT api/<controller>/5
        [LogApiRequestAttribute]
        [Route("api/employee/{employeeCode}")]
        public async Task<EmployeeDto> Put(string employeeCode, [FromBody] EmployeeInfo value)
        {
            try
            {
                var item = _mapper.Map<EmployeeInfo>(value);
                var result = await _employeeService.UpdateEmployeeAsync(employeeCode, item);
                return _mapper.Map<EmployeeDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in EmployeeController.Put");
                throw;
            }
        }

        // DELETE api/<controller>/5
        [LogApiRequestAttribute]
        public async Task Delete(string employeeCode)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(employeeCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in EmployeeController.Delete");
                throw;
            }
        }
    }
}