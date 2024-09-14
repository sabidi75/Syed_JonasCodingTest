using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _employeeRepository = EmployeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync()
        {
            var res = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeInfo>>(res);
        }

        public async Task<EmployeeInfo> GetEmployeeByCodeAsync(string EmployeeCode)
        {
            var result = await _employeeRepository.GetByCodeAsync(EmployeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }

        public async Task<EmployeeInfo> SaveEmployeeAsync(EmployeeInfo EmployeeInfo)
        {
            var employee = _mapper.Map<DataAccessLayer.Model.Models.Employee>(EmployeeInfo);
            var result = await _employeeRepository.SaveEmployeeAsync(employee);
            return _mapper.Map<EmployeeInfo>(employee);
        }

        public async Task<EmployeeInfo> UpdateEmployeeAsync(string EmployeeCode, EmployeeInfo EmployeeInfo)
        {
            var employee = _mapper.Map<DataAccessLayer.Model.Models.Employee>(EmployeeInfo);
            var result = await _employeeRepository.UpdateEmployeeAsync(EmployeeCode, employee);
            return _mapper.Map<EmployeeInfo>(employee);
        }

        public async Task<EmployeeInfo> DeleteEmployeeAsync(string EmployeeCode)
        {
            var result = await _employeeRepository.DeleteEmployeeAsync(EmployeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }
    }
}
