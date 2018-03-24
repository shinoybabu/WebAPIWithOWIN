using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebAPIWithOWIN.Controllers
{
    public class ValuesController : ApiController
    {
        [AllowAnonymous]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello" + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [Route("values/authenticateadmin")]
        public IHttpActionResult AuthenticateAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            return Ok("Hello" + identity.Name + " Role:" + string.Join(",", roles.ToList()));
        }

        [Authorize(Roles = "user")]
        public IHttpActionResult AuthenticateUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            return Ok("Hello" + identity.Name + " Role:" + string.Join(",", roles.ToList()));
        }



        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
