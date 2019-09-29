using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MOD_BAL;
using MOD_DATA;

namespace MOD_API.Controllers
{
    public class UserController : ApiController
    {
        MOD_BAL.UserLogic userLogic = new MOD_BAL.UserLogic();

        [Route("api/getuser")]
        [HttpGet]
        public IHttpActionResult GetAllUser()
        {
            var result = userLogic.GetAllUsers();
            return Ok(result);
        }
    }
}
