using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.ContextHelpers;
using WebApplication3.Models.ViewModels;


namespace WebApplication3.Repository
{
    public class RoomRepository
    {
        private NewCollegeDBContext _context;

        public RoomRepository (NewCollegeDBContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomViewModel> GetAllRooms()
        {
            IEnumerable<RoomViewModel> rooms = _context.Rooms

                .Select(r => new RoomViewModel()
                {
                    RoomID = r.RoomID,
                    BuildingName = r.BuildingName,
                    CollegeName = r.CollegeName,
                    SeatingCapacity = r.SeatingCapacity
                });


            return rooms;
        }

        // add view to implement this method
        public IEnumerable<RoomViewModel> GetRoomDetails(string id)
        {
            IEnumerable<RoomViewModel> rooms = _context.Rooms
                .Where(r => r.RoomID == id)
                .Select(r => new RoomViewModel()
                {
                    RoomID = r.RoomID,
                    BuildingName = r.BuildingName,
                    CollegeName = r.CollegeName,
                    SeatingCapacity = r.SeatingCapacity
                });


            return rooms;
        }
    }
}
