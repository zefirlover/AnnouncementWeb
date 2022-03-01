using AnnouncementWeb.Models;
using AnnouncementWeb.Requests;
using AutoMapper;

namespace AnnouncementWeb.MapperProfiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<AnnouncementRequest, Announcement>();
        }
    }
}