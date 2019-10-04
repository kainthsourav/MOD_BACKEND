using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MOD_DATA;

namespace MOD_BAL
{
   public class UserLogic
    {
        public MOD_DBEntities4 data = new MOD_DBEntities4();
        
        public IList<UserDtl> GetAllUsers()
        {
            return data.UserDtls.ToList();
        }

        public UserDtl GetUserById(int id)
        {
            return data.UserDtls.Find(id);
        }

        public void Register(UserDtl userDtl)
        {
            //Adding Trainer
            if(userDtl.role==2)
            {
                var newTrainer = new UserDtl()
                {
                    userName = userDtl.userName,
                    password = userDtl.password,
                    email = userDtl.email,
                    firstName = userDtl.firstName,
                    lastName = userDtl.lastName,
                    contactNumber = userDtl.contactNumber,
                    linkdinUrl = userDtl.linkdinUrl,
                    yearOfExperience = userDtl.yearOfExperience,
                    TrainerTimings=userDtl.TrainerTimings,
                    TrainerTechnology=userDtl.TrainerTechnology,
                    //confirmedSignUp=userDtl.confirmedSignUp,
                    active=userDtl.active,
                    role = userDtl.role
                };
                data.UserDtls.Add(newTrainer);
                data.SaveChanges();

            }

            //Adding User
            else if(userDtl.role==3)
            {
                var newUser = new UserDtl()
                {
                    userName = userDtl.email,
                    password = userDtl.password,
                    firstName = userDtl.firstName,
                    lastName = userDtl.lastName,
                    contactNumber = userDtl.contactNumber,
                    email=userDtl.email,
                    //yearOfExperience = userDtl.yearOfExperience,
                    //linkdinUrl = userDtl.linkdinUrl,
                    confirmedSignUp = userDtl.confirmedSignUp,
                    active = userDtl.active,
                    role = userDtl.role
                };
                data.UserDtls.Add(newUser);
                data.SaveChanges();
            }

            //save data to database
           
        }

        public void BlockUser(int id)
        {
            UserDtl user = data.UserDtls.Find(id);
            user.active = false;
            data.Entry(user).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
           //ata.UserDtls.Remove(user);
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        public void UnBlockUser(int id)
        {
            UserDtl user = data.UserDtls.Find(id);
            user.active = true;
            data.Entry(user).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        public void UpdateUser(UserDtl userDtl)
        {
            data.Entry(userDtl).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        //Sigin in 
        public UserDtl SignIn(UserDtl loginDtl)
        {
            UserDtl Vaildlogin = data.UserDtls.FirstOrDefault(x => x.email == loginDtl.email && x.password == loginDtl.password);

            return Vaildlogin;

        }


        //SkillDtls Logic
        public IList<SkillDtl> GetAllSkills()
        {
            return data.SkillDtls.ToList();
        }

        public SkillDtl GetSkillById(int id)
        {
            return data.SkillDtls.Find(id);
        }
        public void AddNewSkill(SkillDtl skillDtl)
        {
            data.SkillDtls.Add(skillDtl);
            data.SaveChanges();
        }

        public void DeleteSkill(int id)
        {
            data.SkillDtls.Remove(data.SkillDtls.Find(id));
            data.SaveChanges();
        }

        public void EditSkill(SkillDtl skillDtl)
        {
            data.Entry(skillDtl).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        public IList<UserDtl> SearchTrainings(SkillDtl skillDtl)
        {
         return data.UserDtls.Where(x => x.TrainerTechnology == skillDtl.id.ToString() && x.TrainerTimings == skillDtl.timings).ToList();
           
        }
    }
}
