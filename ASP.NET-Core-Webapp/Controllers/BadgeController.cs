﻿using ASP.NET_Core_Webapp.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP.NET_Core_Webapp.Controllers
{
    [Route("badges")]
    public class BadgeController : Controller
    {
        [HttpPost]
        public IActionResult RecieveBadge([FromBody] Badge badge, [FromQuery]int authorized)
        {
            List<string> holdersTest = new List<string>() { "Gazsi", "Géza" };
            if (authorized.Equals(1))
            {
                if (badge.Levels == null || badge.Name == null || badge.Tag == null || badge.Version == null)
                {

                    return NotFound(new { error = "Please provide all fields" });
                }

                badge.Levels.Add(new Skill() { Description = "New test skill added", Level = 500, Holders = holdersTest });

                return Created("/badges", new { message = "Success" });

            }
            else

                return StatusCode(401, new { error = "Unauthorized" });
        }
    }
}
