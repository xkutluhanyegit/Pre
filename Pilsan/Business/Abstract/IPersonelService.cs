using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.DTO;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        IDataResult<List<HRPersonelDetailDto>> GetAllHRPersonelDetailDto(int week);
        IDataResult<List<DepartmentPersonelDetailDto>> GetAllDepartmentPersonelDetailDto(int week,string departmentID);
    }
}