using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Bogus;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using task5.Models;
using task5.Services;

namespace task5.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IFakerService _faker;


    public HomeController(ILogger<HomeController> logger, IFakerService faker)
    {
        _logger = logger;
        _faker = faker;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult GenerateData(string region, decimal errorCount, int seed, int page)
    {
        _logger.LogInformation("Received region: {region}, errorCount: {errorCount}, seed: {seed}, page: {page}", region, (double)errorCount, seed, page);
        var fakeData = _faker.GenerateFakeData(region, seed, page);
        _faker.AddErrorsToUserDataList(fakeData, (double)errorCount);
        // Отправка данных в представление
        return PartialView("_UserDataPartial", fakeData);
    }
    
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}