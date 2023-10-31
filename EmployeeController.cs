using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMVC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace WebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly IWebHostEnvironment _webhostenvironment;


        Uri baseAddress = new Uri("https://localhost:44363/api");

        string str = "Data Source=192.168.25.25;Initial Catalog = ENFINLiveTestDB; Persist Security Info=True;User ID = Dev_Test_CH; Password=RT78^yykh987";
        EmpDAL e = new EmpDAL();
        private readonly HttpClient _client;

        public EmployeeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public EmployeeController(string baseAddress)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseAddress) };
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Employee
        public ActionResult Index()
        {
            EmpDAL e = new EmpDAL();
            List<Emp> lst = e.GetDataList();
            return View(lst);
        }



        //GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.Hobbies = new List<string>
            {
                "Travelling",
                 "Cooking",
                 "Reading",
                 "Playing",
                 "Netsurfing",
            };


            //ViewBag.States = GetCitiesByState();
            //List<SelectListItem> states = GetCitiesByState();


            ViewBag.SelectedHobbies = new List<string>
            {
                "Travelling",
                 "Cooking",
                 "Reading",
                 "Playing",
                 "Netsurfing",
            };

            return PartialView();
        }

        public async Task<string> CreateEmployeeAsync(Emp employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Serialize the employee object to JSON
                    string employeeJson = JsonConvert.SerializeObject(employee);
                    var content = new StringContent(employeeJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("api/AddEmployees", content); // Use PostAsync for creating a new employee

                    if (response.IsSuccessStatusCode)
                    {
                        // If the API call is successful, return the response as a string
                        return await response.Content.ReadAsStringAsync();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        // Handle bad request (e.g., duplicate employee or missing files)
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        // Handle other error cases
                        throw new Exception($"API call failed with status code {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"API call failed: {ex.Message}");
                }
            }
        }


        [HttpGet]
        public async Task<ActionResult> GetEmployeeDetails()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("GetEmployeeDetails");

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsAsync<PagingData>(); // Deserialize directly into PagingData
                        return View(data);
                    }
                    else
                    {
                        Console.WriteLine($"Response Status Code: {response.StatusCode}");

                        // You can also check the response content for additional details
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Response Content: {errorContent}");

                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
        }




        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CommonView()
        {
            return View();
        }
    }
}