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
        public MOD_DBEntities data = new MOD_DBEntities();
        
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
                    confirmedSignUp=userDtl.confirmedSignUp,
                    active=userDtl.active
                };
                data.UserDtls.Add(newTrainer);
               
            }

            //Adding User
            if(userDtl.role==3)
            {
                var newUser = new UserDtl()
                {
                    userName = userDtl.userName,
                    password = userDtl.password,
                    firstName = userDtl.firstName,
                    lastName = userDtl.lastName,
                    contactNumber = userDtl.contactNumber,
                    yearOfExperience = userDtl.yearOfExperience,
                    linkdinUrl = userDtl.linkdinUrl,
                    confirmedSignUp = userDtl.confirmedSignUp,
                    active = userDtl.active
                };
                data.UserDtls.Add(newUser);
            }

            //save data to database
            data.SaveChanges();
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
    }
}
