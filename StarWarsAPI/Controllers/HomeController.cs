using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWarsAPI.Models;

namespace StarWarsAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<People> GetPersonById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api");
            var response = await client.GetAsync($"people/{id}");

            var result = await response.Content.ReadAsAsync<People>();//need to have a way to take in the json file
            return result;
        }
        public async Task<Planet> GetPlanetById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api");
            var response = await client.GetAsync($"planets/{id}");

            var result = await response.Content.ReadAsAsync<Planet>();//need to have a way to take in the json file
            return result;
        }
        public IActionResult SelectedPerson(int id)
        {
            var result = GetPersonById(id);
            ViewBag.Result = result;
            return View();
        }
        public IActionResult SelectedPlanet(int id)
        {
            var result = GetPlanetById(id);
            ViewBag.Result = result;
            return View();
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
