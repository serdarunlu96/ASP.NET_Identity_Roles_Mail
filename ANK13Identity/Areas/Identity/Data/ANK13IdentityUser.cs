using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ANK13Identity.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ANK13IdentityUser class
public class ANK13IdentityUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

