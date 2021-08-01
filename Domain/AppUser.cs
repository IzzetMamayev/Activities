using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }

        // public ICollection<ActivityAttendee> Activities { get; set; }  // Perviy variant many_to_many
        public ICollection<ActivityAttendee> Activities { get; set; }
    }
}