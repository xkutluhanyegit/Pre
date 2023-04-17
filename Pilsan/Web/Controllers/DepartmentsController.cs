using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Constant;
using Entities.Concrete;
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
        private readonly IPersonelShiftService _personelShiftService;

        private readonly IPersonelOvertimeService _personelOvertimeService;


        public DepartmentsController(ILogger<DepartmentsController> logger, IPersonelService personelService, IShiftService shiftService, IPersonelShiftService personelShiftService,IPersonelOvertimeService personelOvertimeService)
        {
            _logger = logger;
            _personelService = personelService;
            _shiftService = shiftService;
            _personelShiftService = personelShiftService;
            _personelOvertimeService=personelOvertimeService;
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

            var result = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNow, id);

            if (result.Success)
            {
                //NowWeek List
                d.GetAllWeekNowDepartmentPersonelDetailDto = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNow, id).Data.ToList();

                //NextWeek List
                d.GetAllWeekNextDepartmentPersonelDetailDto = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNext, id).Data.ToList();

                var NextWeekShiftList = d.GetAllWeekNextDepartmentPersonelDetailDto.Where(p => p.WeekofYear == WeekofDay.weekNext).ToList();

                //Need Refactoring Yeni hafta Atanmaış
                d.GetAllWeekNextNoShiftDepartmentPersonelDetailDto = d.GetAllWeekNowDepartmentPersonelDetailDto.Where(p=> !NextWeekShiftList.Any(l=>p.RegisterNo == l.RegisterNo)).ToList();

                //NextWeek List Show
                d.GetAllWeekNextYesShiftDepartmentPersonelDetailDto = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNext,id).Data.Where(p=>p.WeekofYear == WeekofDay.weekNext).ToList();
                
                d.GetAllWeekNowNoOvertimeDepartmentPersonelDetailDto = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNow,id).Data.Where(p=>p.OvertimeID == null & (p.ShiftID == 1 | p.ShiftID == 2)).ToList();
                d.GetAllWeekNowYesOvertimeDepartmentPersonelDetailDto = _personelService.GetAllDepartmentPersonelDetailDto(WeekofDay.weekNow,id).Data.Where(p=>p.OvertimeID!=null).ToList();

                //Shift List
                d.GetAllShiftList = _shiftService.GetAllShift().Data.ToList();
                return View(d);
            }
            return View();
        }

        [HttpPost("vardiya-ekle")]
        public IActionResult department_shift_add(DepartmentsDetailViewModel personelList, int shiftID)
        {
            var result = personelList.GetAllWeekNextNoShiftDepartmentPersonelDetailDto;

            foreach (var item in result)
            {
                Personelshift p = new Personelshift();
                if (item.Check & item.NextWeekShiftID != null & item.NextWeekShiftID != 0)
                {
                    p.Sicilno = item.RegisterNo;
                    p.Shiftid = item.NextWeekShiftID;
                    _personelShiftService.Add(p);

                }
                else
                {
                    //Hata
                    return RedirectToAction("index", "departments");
                }
            }
            return RedirectToAction("index", "departments");
        }

        [HttpPost("vardiya-sil")]
        public IActionResult department_shift_delete(DepartmentsDetailViewModel personelList)
        {
          var result = personelList.GetAllWeekNextYesShiftDepartmentPersonelDetailDto.ToList();

          foreach (var item in result)
          {
            if (item.Check)
            {
                Personelshift p = new Personelshift();
                p.Sicilno = item.RegisterNo;
                p.WeekOfYear = item.WeekofYear;
                _personelShiftService.Delete(p);
            }
          }
          return RedirectToAction("index","departments");
        }

        [HttpPost("mesai-ekle")]
        public IActionResult department_overtime_add(DepartmentsDetailViewModel personelList, int OvertimeID)
        {
          var result = personelList.GetAllWeekNowNoOvertimeDepartmentPersonelDetailDto;

          foreach (var item in result)
          {
            if (item.Check)
            {
                Personelovertime p = new Personelovertime();
                p.Sicilno = item.RegisterNo;
                p.Overtimeid = OvertimeID;
                p.WeekOfYear = item.WeekofYear;
                _personelOvertimeService.Add(p);

            }
            else{
                return RedirectToAction("index","departments");
            }
          }
          return RedirectToAction("index","departments");
          
        }

        [HttpPost("mesai-sil")]
        public IActionResult department_overtime_delete(DepartmentsDetailViewModel personelList)
        {
            var result = personelList.GetAllWeekNowYesOvertimeDepartmentPersonelDetailDto;

            foreach (var item in result)
            {
                if (item.Check)
                {
                    Personelovertime p = new Personelovertime();
                    p.Sicilno = item.RegisterNo;
                    p.Overtimeday = DateTime.Now.ToShortDateString();
                    _personelOvertimeService.Delete(p);
                }
            }
          
          return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}