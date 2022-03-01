using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnnouncementWeb.Data;
using AnnouncementWeb.Models;
using AnnouncementWeb.Requests;
using AutoMapper;

namespace AnnouncementWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AnnouncementController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Announcement>>> Get()
        {
            return await _db.Announcements.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Announcement>> Add([FromBody]AnnouncementRequest announcementRequest)
        {
            var addAnnouncement = _mapper.Map<Announcement>(announcementRequest);
            await _db.Announcements.AddAsync(addAnnouncement);
            await _db.SaveChangesAsync();
            return Ok(addAnnouncement);
        }
    }
}