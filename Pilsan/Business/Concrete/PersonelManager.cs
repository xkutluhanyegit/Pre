using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constant.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.DTO;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;
        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IDataResult<List<DepartmentPersonelDetailDto>> GetAllDepartmentPersonelDetailDto(int week, string departmentID)
        {
            var result = _personelDal.GetAllDepartmentPersonelDetailDto(week,departmentID);
            return new SuccessDataResult<List<DepartmentPersonelDetailDto>>(result,Messages.ListedSuccessMessage);
        }

        public IDataResult<List<HRPersonelDetailDto>> GetAllHRPersonelDetailDto(int week)
        {
            var result = _personelDal.GetAllHRPersonelDetailDto(week);
            return new SuccessDataResult<List<HRPersonelDetailDto>>(result,Messages.ListedSuccessMessage);
        }
    }
}