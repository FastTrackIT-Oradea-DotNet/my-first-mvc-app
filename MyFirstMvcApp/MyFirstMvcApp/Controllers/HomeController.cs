using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyFirstMvcApp.Configuration;
using MyFirstMvcApp.Models;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HostingSettings _hostSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<HostingSettings> hostSettings)
        {
            _logger = logger;
            _hostSettings = hostSettings.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation($"HostingProviderName: {_hostSettings.HostingProviderName}");
            _logger.LogInformation($"BaseUrl: {_hostSettings.BaseUrl}");
            _logger.LogInformation($"SqlServerAddress: {_hostSettings.SqlServerAddress}");

            _logger.LogInformation("Accessing Index method");

            return View();
        }

        public IActionResult Test(string id)
        {
            return View("Test", id);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
