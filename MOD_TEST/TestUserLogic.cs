using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD_DATA;
using MOD_BAL;
using NUnit;
using NUnit.Framework;
namespace MOD_TEST
{
   [TestFixture]
    public class TestUserLogic
    {
        [Test]
        public void GetById()
        {
            UserLogic userLogic = new UserLogic();
            UserDtl user = userLogic.GetUserById(1);
            Assert.IsNotNull(user); 
        }

        [Test]
        public void Register()
        {
            UserLogic userLogic = new UserLogic();
            UserDtl user = new UserDtl()
            {
                firstName ="Sourav",
                lastName = "Kainth",
                userName = "Kainth Sourav",
                password = "12345678",
                email = "xx@yts.com",
                contactNumber =9876350744,
                linkdinUrl = "www.linkdin.com",
                yearOfExperience = 12,
                TrainerTechnology = "C#",
                active = true,
                role = 2,
            };
            userLogic.Register(user);
            UserDtl user1 = userLogic.GetUserById(13);
            Assert.IsNotNull(user1);
        }

        [Test]
        public void GetAllUser()
        {
            UserLogic userLogic = new UserLogic();
            IList<UserDtl> p = userLogic.GetAllUsers();
            Assert.IsNotNull(p);
        }

        [Test]
        public void BlockUser()
        {
            UserLogic userLogic = new UserLogic();
            userLogic.BlockUser(2);
            UserDtl user = userLogic.GetUserById(2);
            Assert.IsTrue(user.active == false);

        }

        [Test]
        public void UnBlockUser()
        {
            UserLogic userLogic = new UserLogic();
            userLogic.UnBlockUser(2);
            UserDtl user = userLogic.GetUserById(2);
            Assert.IsTrue(user.active == true);

        }


        [Test]
        public void getskillbyid()
        {
            UserLogic userLogic = new UserLogic();
            IList<SkillDtl> p= userLogic.GetSkillById(12);
            Assert.IsNotNull(p);
        }
        [Test]
        public void Delete()
        {
            UserLogic userLogic = new UserLogic();
            userLogic.DeleteSkill(21);
            Assert.IsEmpty(userLogic.GetSkillById(21));
        }


    }
}
