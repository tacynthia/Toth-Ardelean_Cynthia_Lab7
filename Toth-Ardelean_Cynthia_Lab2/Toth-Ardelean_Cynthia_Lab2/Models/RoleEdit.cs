using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toth_Ardelean_Cynthia_Lab2.Models
{
	public class RoleEdit
	{
		public IdentityRole Role { get; set; }
		public IEnumerable<IdentityUser> Members { get; set; }
		public IEnumerable<IdentityUser> NonMembers { get; set; }
	}
}

