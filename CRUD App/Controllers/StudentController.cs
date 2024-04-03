using CRUD_App.Data;
using CRUD_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _appDbContext.Student.ToListAsync();
            return View(students);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(Student studentRequest)
        {
            var student = new Student()
            {
                Name = studentRequest.Name,
                Description = studentRequest.Description,
                Grade = studentRequest.Grade,
            };

            _appDbContext.Student.Add(student);
            await _appDbContext.SaveChangesAsync();
            return Ok(student);

        }
    }
}
