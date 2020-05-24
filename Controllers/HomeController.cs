using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentManagement.Model;
using StudentManagement.Service;
using StudentManagement.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _repository;

        public HomeController(IRepository<Student> repository)
        {
            this._repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //var st = new Student
            //{
            //    Id = 1,
            //    FirstName = "Liao",
            //    LastName = "Wenchao"
            //};
            //var st = _repository.GetAll();
            //return View(st);
            //return "hello from HomeController";

            var list = _repository.GetAll();
            var vms = list.Select(x => new StudentViewModel
            {
                Id=x.Id,
                Name = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Subtract(x.BirthDay).Days / 365
            });

            var vm = new HomeIndexViewModel { Students = vms };
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var stu = _repository.GetById(id);
            if (null == stu)
            {
                return RedirectToAction("Index");
            }
            return View(stu);
        }
        //[HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stu)
        {
            return Content(JsonConvert.SerializeObject(stu));
        }
    }
}
