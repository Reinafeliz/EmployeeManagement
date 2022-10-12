using EmployeeManagement.Data;
using EmployeeManagement.Entities;
using EmployeeManagement.Interface;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _empRepo;
        private readonly DataContext _context;
         private readonly IWebHostEnvironment _webHost;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository empRepo, DataContext context,IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            _context = context;
            _empRepo = empRepo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> objCatlist = _context.Employees;
            IList<EmployeeViewModel> empList = new List<EmployeeViewModel>();
            foreach (var item in objCatlist)
            {
                var data = new EmployeeViewModel();
                data.Id = item.Id;
                data.Name = item.Name;
                data.DOB = item.DOB;
                data.Email = item.Email;
                data.Mobile = item.Mobile;
                data.City = item.City;
                data.CityName = item.CityName;
                data.Address = item.Address;
                data.PinCode = item.PinCode;
                data.ImagePath = item.Image;
                empList.Add(data);
            }
            return View(empList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IReadOnlyList<StateCity> GetCity()
        {
            var cities = _empRepo.GetCity();
            return cities;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel empobj)
        {
            if (ModelState.IsValid)
            {
                var data = new Employee();
                data.Name = empobj.Name;
                data.DOB = empobj.DOB;
                data.Email = empobj.Email;
                data.Mobile = empobj.Mobile;
                data.City = empobj.City;
                data.CityName = empobj.CityName;
                data.Address = empobj.Address;
                data.PinCode = empobj.PinCode;
                data.InsertedDate=DateTimeOffset.Now;

 string uniqueFileName = null;  //to contain the filename
            if (empobj.ImageFile!= null)  //handle iformfile
            {
              //  string uploadsFolder =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                string uploadsFolder =Path.Combine(_webHost.WebRootPath,"Images");
                uniqueFileName =empobj.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    empobj.ImageFile.CopyTo(fileStream);
                }
                 data.Image ="wwwroot/Images"+ uniqueFileName;
            }
            
      _context.Employees.Add(data);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empobj = _context.Employees.Find(id);

            if (empobj == null)
            {
                return NotFound();
            } 
             var data = new EmployeeViewModel();
             data.Id=empobj.Id;
                data.Name = empobj.Name;
                data.DOB = empobj.DOB;
                data.Email = empobj.Email;
                data.Mobile = empobj.Mobile;
                data.City = empobj.City;
                data.CityName = empobj.CityName;
                data.Address = empobj.Address;
                data.PinCode = empobj.PinCode;
                data.ImagePath = empobj.Image;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel empobj)
        {
            if (ModelState.IsValid)
            {
                 var data = new Employee();
                 data.Id=empobj.Id;
                data.Name = empobj.Name;
                data.DOB = empobj.DOB;
                data.Email = empobj.Email;
                data.Mobile = empobj.Mobile;
                data.City = empobj.City;
                data.CityName = empobj.CityName;
                data.Address = empobj.Address;
                data.PinCode = empobj.PinCode;
                data.Image = empobj.ImagePath;
                data.UpdatedDate=DateTimeOffset.Now;
                _context.Employees.Update(data);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empobj = _context.Employees.Find(id);

            if (empobj == null)
            {
                return NotFound();
            }
             var data = new EmployeeViewModel();
             data.Id=empobj.Id;
                data.Name = empobj.Name;
                data.DOB = empobj.DOB;
                data.Email = empobj.Email;
                data.Mobile = empobj.Mobile;
                data.City = empobj.City;
                data.CityName = empobj.CityName;
                data.Address = empobj.Address;
                data.PinCode = empobj.PinCode;
                data.ImagePath = empobj.Image;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int? id)
        {
            var deleterecord = _context.Employees.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}