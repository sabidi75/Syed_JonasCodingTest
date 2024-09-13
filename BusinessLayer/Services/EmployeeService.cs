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
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeInfo>> GetAllCompaniesAsync()
        {
            var res = await _EmployeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeInfo>>(res);
        }

        public async Task<EmployeeInfo> GetEmployeeByCodeAsync(string EmployeeCode)
        {
            var result = await _EmployeeRepository.GetByCodeAsync(EmployeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }

        public async Task<EmployeeInfo> SaveEmployeeAsync(EmployeeInfo EmployeeInfo)
        {
            var employee = _mapper.Map<DataAccessLayer.Model.Models.Employee>(EmployeeInfo);
            var result = await _EmployeeRepository.SaveEmployeeAsync(employee);
            return _mapper.Map<EmployeeInfo>(employee);
        }

        public async Task<EmployeeInfo> UpdateEmployeeAsync(string EmployeeCode, EmployeeInfo EmployeeInfo)
        {
            var employee = _mapper.Map<DataAccessLayer.Model.Models.Employee>(EmployeeInfo);
            var result = await _EmployeeRepository.UpdateEmployeeAsync(EmployeeCode, employee);
            return _mapper.Map<EmployeeInfo>(employee);
        }

        public async Task<EmployeeInfo> DeleteEmployeeAsync(string EmployeeCode)
        {
            var result = await _EmployeeRepository.DeleteEmployeeAsync(EmployeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }
    }
}
