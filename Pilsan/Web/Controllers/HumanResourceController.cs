using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Constant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("insan-kaynaklari")]
    public class HumanResourceController : Controller
    {
        private readonly ILogger<HumanResourceController> _logger;
        private readonly IPersonelService _personelService;

        public HumanResourceController(ILogger<HumanResourceController> logger,IPersonelService personelService)
        {
            _logger = logger;
            _personelService = personelService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var result = _personelService.GetAllHRPersonelDetailDto(WeekofDay.weekNow);
            if (result.Success)
            {
                return View(result.Data);
            }
            else{
                return View(result.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}