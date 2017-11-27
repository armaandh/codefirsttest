using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.ContextHelpers;
using WebApplication3.Models;
using WebApplication3.Models.ViewModels;
using WebApplication3.Repository;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private NewCollegeDBContext _context;

        // Initialize context when controller is created.
        public HomeController(NewCollegeDBContext context)
        {
            _context = context;
            Seeder seeder = new Seeder(_context); //change from dirty seeding method to optimized one
        }

        public IActionResult College()
        {
            CollegeRepository collegeRepository = new CollegeRepository(_context);
            IEnumerable<CollegeViewModel> collegeViewModel = collegeRepository.GetAllColleges();
            return View(collegeViewModel);
        }

        public IActionResult Building()
        {
            BuildingRepository buildingRepository = new BuildingRepository(_context);
            IEnumerable<BuildingViewModel> buildingViewModel = buildingRepository.GetAllBuildings();
            return View(buildingViewModel);
        }

        public IActionResult Room()
        {
            RoomRepository roomRepository = new RoomRepository(_context);
            IEnumerable<RoomViewModel> roomViewModel = roomRepository.GetAllRooms();
            return View(roomViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
