using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Constant;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    [Route("departmanlar")]
    public class DepartmentsController : Controller
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IPersonelService _personelService;
        private readonly IShiftService _shiftService;


        public DepartmentsController(ILogger<DepartmentsController> logger,IPersonelService personelService,IShiftService shiftService)
        {
            _logger = logger;
            _personelService = personelService;
            _shiftService = shiftService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("departman")]
        public IActionResult department(string id, string departmentname)
        {
          DepartmentsDetailViewModel d = new DepartmentsDetailViewModel();
          
          var result = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNow,id);

          if (result.Success)
          {
            d.GetAllWeekNowDepartmentPersonelDetailDto = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNow,id).Data.ToList();
            d.GetAllShiftList = _shiftService.GetAllShift().Data.ToList();
            return View(d);
          }
          return View();
        }

        [HttpPost("vardiya-ekle")]
        public IActionResult department_shift_add(DepartmentsDetailViewModel personelList,int shiftID)
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}