<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> b79556de721255f51d5ead6e5c85af09cf666b3b
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
<<<<<<< HEAD

        // public ICollection<ActivityAttendee> Activities { get; set; }  // Perviy variant many_to_many
        public ICollection<ActivityAttendee> Activities { get; set; }
=======
>>>>>>> b79556de721255f51d5ead6e5c85af09cf666b3b
    }
}