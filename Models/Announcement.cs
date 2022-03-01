using System;
using System.ComponentModel.DataAnnotations;
using AnnouncementWeb.Data.Contracts;

namespace AnnouncementWeb.Models
{
    public class Announcement : IWithDateCreated
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        void IWithDateCreated.SetDateCreated(DateTimeOffset value) => DateCreated = value;
    }
}