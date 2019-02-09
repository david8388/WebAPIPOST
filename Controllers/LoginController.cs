using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIPOST.Models;

namespace WebAPIPOST.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {
        private readonly List<Member> _members = new List<Member> { new Member { Username = "David", Password = "1234" } };

        // POST api/login
        [HttpPost]
        public ActionResult<Response> LoginMember ([FromBody] Member member) {
            bool isMember (Member x) => x.Username == member.Username && x.Password == member.Password;
            Member DefaultMember () => new Member { Username = string.Empty, Password = string.Empty };
            Response Result (Member x) => new Response { Success = !string.IsNullOrEmpty (x.Username), Username = x.Username };
            return _members.Where (isMember).DefaultIfEmpty (DefaultMember ()).Select (Result).First ();
        }
    }
}