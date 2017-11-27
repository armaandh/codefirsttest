using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.ContextHelpers;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Repository
{
    public class CollegeRepository
    {
        private NewCollegeDBContext _context;

        public CollegeRepository(NewCollegeDBContext context)
        {
            _context = context;
        }

        public IEnumerable<CollegeViewModel> GetAllColleges()
        {
            IEnumerable<CollegeViewModel> colleges = _context.Colleges.Select(c => new

                CollegeViewModel()
                {
                    CollegeName = c.CollegeName,
                    Established = c.Established
                });
            return colleges;
        } 
    }
}
