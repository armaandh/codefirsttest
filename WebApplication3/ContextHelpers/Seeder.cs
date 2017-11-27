using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.ContextHelpers
{
    public class Seeder
    {
        private NewCollegeDBContext _context;
        public Seeder(NewCollegeDBContext context)
        {
            _context = context;
            SeedData();
        }

        public void SeedData()
        {
            // Exit if data exists.
            if (_context.Colleges.Count() != 0)
            {
                return;
            }
            College college1 = new College { CollegeName = "ABC", Established = new DateTime(2017, 03, 25)};
            _context.Colleges.Add(college1);

            College college2 = new College { CollegeName = "BHC", Established = new DateTime(2017, 04, 25) };
            _context.Colleges.Add(college2);

            College college3 = new College { CollegeName = "UBC", Established = new DateTime(2017, 02, 25) };
            _context.Colleges.Add(college3);
            _context.SaveChanges();

            Building building1 = new Building { BuildingName = "buch", CollegeName = "UBC", City = "Vancouver", StreetAddress = "4354 browton ave"};
            _context.Buildings.Add(building1);

            Building building2 = new Building { BuildingName = "skbuilding", CollegeName = "BHC", City = "Vancouver", StreetAddress = "1324 maple ave"};
            _context.Buildings.Add(building2);

            Building building3 = new Building { BuildingName = "jkbuilding", CollegeName = "UBC", City = "Vancouver", StreetAddress = "3342 cordova"};
            _context.Buildings.Add(building3);
            _context.SaveChanges();


            Room room1 = new Room() {RoomID = "3342", CollegeName = "UBC", BuildingName = "buch", SeatingCapacity = 30};
            _context.Rooms.Add(room1);


            Room room2 = new Room() { RoomID = "8854", CollegeName = "BHC", BuildingName = "skbuilding", SeatingCapacity = 20 };
            _context.Rooms.Add(room2);

            Room room3 = new Room() { RoomID = "9954", CollegeName = "UBC", BuildingName = "jkbuilding", SeatingCapacity = 21 };
            _context.Rooms.Add(room3);
            _context.SaveChanges();
        }
    }
}

