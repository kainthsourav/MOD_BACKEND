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

        [Route("api/getskillprice/{id}")]
        [HttpGet]
        public IHttpActionResult GetSkillPrice(string id)
        {
            var result = userLogic.GetSkillsPrice(id);
            return Ok(result);
        }


       [Route("api/addskill")]
       [HttpPost]
        public IHttpActionResult AddSkill(SkillDtl skillDtl)
        {
            userLogic.AddNewSkill(skillDtl);
            return Ok("Request Sent");
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

        [Route("api/addTraining")]
        [HttpPost]

        public IHttpActionResult TrainingData(TrainingDtl trainingDtl)
        {
             userLogic.addTrainingDtls(trainingDtl);
            return Ok("Sent");
        }

        //Get training Data
        [Route("api/getapprovals")]
        [HttpGet]
        public IHttpActionResult Approvals()
        {
           var result= userLogic.GetApproval();
            return Ok(result);
        }

        [Route("api/approveTraining/{id}")]
        [HttpGet]

        public IHttpActionResult approve(int id)
        {
            userLogic.Approve(id);
            return Ok("Training Approved");
        }

        [Route("api/declinedTraining/{id}")]
        [HttpGet]
        public IHttpActionResult declined(int id)
        {
            userLogic.Declined(id);
            return Ok("Training Rejected");
        }

        //Get trainingById
        [Route("api/trainingById/{id}")]
        [HttpGet]

        public IHttpActionResult GetTrainingById(int id)
        {
            var result=userLogic.TrainingById(id);
            return Ok(result);
        }

        //Payment
        [Route("api/paymentgate")]
        [HttpPost]
        public IHttpActionResult PayTrainingFee(PaymentDtl paymentDtl)
        {
            userLogic.addPayment(paymentDtl);
            return Ok("Fee Paid");
        }

        [Route("api/allpayments")]
        [HttpGet]
        public IHttpActionResult GetPayments()
        {
            var result = userLogic.GetAllPayment();
            return Ok(result);
        }

        [Route("api/updatepay/{id}")]
        [HttpGet]
        public IHttpActionResult updatePay(int id)
        {
            userLogic.PayUpdate(id);
            return Ok("Payment Confirmed");
        }

        [Route("api/updateProgress")]
        [HttpPost]
        public IHttpActionResult Progress(TrainingDtl proData)
        {
            userLogic.UpdateProg(proData);
            return Ok("Progress Updated");

        }

        //AdminCommision
        [Route("api/admincommision")]
        [HttpPost]
        public IHttpActionResult Commision(PaymentDtl paymentDtl)
        {
            userLogic.AdminCommision(paymentDtl);
            return Ok("Updated");
        }

        //Update Trainer Profile
        [Route("api/updatetrainerprofile")]
        [HttpPost]
        public IHttpActionResult UpdateProfile(UserDtl userDtl)
        {
            userLogic.UpdateProfile(userDtl);
            return Ok("Updated");
        }



    }
}
