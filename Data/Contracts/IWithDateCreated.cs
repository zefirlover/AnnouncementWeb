using System;

namespace AnnouncementWeb.Data.Contracts
{
    public interface IWithDateCreated
    {
        DateTimeOffset DateCreated { get; }
        void SetDateCreated(DateTimeOffset value);
    }
}