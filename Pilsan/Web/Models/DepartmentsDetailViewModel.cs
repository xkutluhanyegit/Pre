using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTO;

namespace Web.Models
{
    public class DepartmentsDetailViewModel
    {
        //Week Now Shift
        public List<DepartmentPersonelDetailDto> GetAllWeekNowDepartmentPersonelDetailDto { get; set; }

        //Shift List
        public List<Shift> GetAllShiftList { get; set; }

        //Week Next Shift 
        public List<DepartmentPersonelDetailDto> GetAllWeekNextDepartmentPersonelDetailDto { get; set; }

        //Today Overtime

    }
}