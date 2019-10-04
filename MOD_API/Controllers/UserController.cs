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

        //Skill Logic

      [Route ("api/getskills")]
      [HttpGet]
      public IHttpActionResult GetSkills()
        {
            var result= userLogic.GetAllSkills();
            return Ok(result);
        }


       [Route("api/addskill")]
       [HttpPost]
        public IHttpActionResult AddSkill(SkillDtl skillDtl)
        {
            userLogic.AddNewSkill(skillDtl);
            return Ok("Added");
        }

        [Route ("api/delteteskill/{id}")]

        [HttpGet]
        public IHttpActionResult DeleteSkill(int id)
        {
            userLogic.DeleteSkill(id);
            return Ok("Deleted");
        }

        [Route("api/getskillbyid/{id}")]
        [HttpGet]
        public IHttpActionResult GetSkillById(int id)
        {
            var result= userLogic.GetSkillById(id);
            if(result !=null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Empty");
            }
        }


       [Route("api/searchtrainings/{id}")]
       [HttpGet]
       public IHttpActionResult SearchTrainings(string id)
        {
           var result= userLogic.Search(id);
            return Ok(result);
          
        }


    }
}
