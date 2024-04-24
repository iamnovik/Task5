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

    private IWebHostEnvironment _hostEnvironment;

    public HomeController(ILogger<HomeController> logger, IFakerService faker, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _faker = faker;
        _hostEnvironment = hostEnvironment;
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
        var fakeData = _faker.GenerateFakeData(region, seed, page);
        _faker.AddErrorsToUserDataList(fakeData, (double)errorCount);
        // Отправка данных в представление
        return PartialView("_UserDataPartial", fakeData);
    }
    
    [HttpPost]
    public IActionResult ExportToCsv(List<List<string>> tableData)
    {
        // Создание CSV-строки
        StringBuilder csvContent = new StringBuilder();
        foreach (var rowData in tableData)
        {
            csvContent.AppendLine(string.Join(",", rowData));
        }

        // Путь для сохранения CSV-файла
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserData.csv");

        // Запись CSV-строки в файл
        System.IO.File.WriteAllText(filePath, csvContent.ToString());

        // Возвращаем URL для скачивания файла на клиенте
        return Json(new { fileUrl = Url.Content("~/UserData.csv") });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}