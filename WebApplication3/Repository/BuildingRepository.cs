using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.ContextHelpers;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Repository
{
    public class BuildingRepository
    {
        private NewCollegeDBContext _context;

        public BuildingRepository(NewCollegeDBContext context)
        {
            _context = context;
        }

        public IEnumerable<BuildingViewModel> GetAllBuildings()
        {
            IEnumerable<BuildingViewModel> buildings = _context.Buildings.Select(b => new

                BuildingViewModel()
                {
                    BuildingName = b.BuildingName,
                    CollegeName =  b.CollegeName,
                    StreetAddress = b.StreetAddress,
                    City = b.City

                });
            return buildings;
        }
    }
}
