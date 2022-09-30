using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityServer.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? OrganizationId { get; set; }
    }

    public class Organization
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public DateTime LastUpdatedDateTime { get; set; } = DateTime.Now;

        public string LastUpdatedBy { get; set; } = "System";

        public string CreatedBy { get; set; } = "System";
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
