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

        [Route("api/getuserbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var result = userLogic.GetUserById(id);
            return Ok(result);
        }

        [Route ("api/blockuser/{id}")]
        [HttpGet]
        public IHttpActionResult BlockUser(int id)
        {
            userLogic.BlockUser(id);
            return Ok("User Blocked");

        }

        [Route("api/unblockuser/{id}")]
        [HttpGet]
        public IHttpActionResult UnblockUser(int id)
        {
            userLogic.UnBlockUser(id);
            return Ok("User Unblocked");
        }

        [Route ("api/login")]
        [HttpPost]
        public IHttpActionResult Signin(UserDtl userinfo)
        {
            UserDtl result=userLogic.SignIn(userinfo);
            return Ok(result);
        }

        [Route ("api/register")]
        [HttpPost]
        public IHttpActionResult Register(UserDtl User)
        {
            userLogic.Register(User);
            return Ok("User Added");
        }
    }
}
