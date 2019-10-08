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

        public MOD_DBEntities1 data = new MOD_DBEntities1();

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
          
            if (userDtl.role == 2)
            {
                var newTrainer = new UserDtl()
                {
                    userName = userDtl.firstName + " " + userDtl.lastName,
                    password = userDtl.password,
                    email = userDtl.email,
                    firstName = userDtl.firstName,
                    lastName = userDtl.lastName,
                    contactNumber = userDtl.contactNumber,
                    linkdinUrl = userDtl.linkdinUrl,
                    yearOfExperience = userDtl.yearOfExperience,
                    // TrainerTimings=userDtl.TrainerTimings,
                    TrainerTechnology = userDtl.TrainerTechnology,
                    //confirmedSignUp=userDtl.confirmedSignUp,
                    active = userDtl.active,
                    role = userDtl.role
                };
                data.UserDtls.Add(newTrainer);
                data.SaveChanges();

            }

            //Adding User
            else if (userDtl.role == 3)
            {
                var newUser = new UserDtl()
                {
                    userName = userDtl.firstName + " " + userDtl.lastName,
                    password = userDtl.password,
                    firstName = userDtl.firstName,
                    lastName = userDtl.lastName,
                    contactNumber = userDtl.contactNumber,
                    email = userDtl.email,
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

        public List<SkillDtl> GetSkillsPrice(string id)
        {
            return data.SkillDtls.Where(x => x.name == id).ToList();
        }

        public IList<SkillDtl> GetSkillById(int id)
        {
            return data.SkillDtls.Where(x => x.id == id).ToList();
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

        public List<UserDtl> Search(string Data)
        {
            List<UserDtl> mentors;
            mentors = data.UserDtls.Where(x => x.TrainerTechnology == Data).ToList();
            return mentors;
        }

        //Save to Trainer Table
        public void addTrainingDtls(TrainingDtl trainingDtl)
        {
            var newTraining = new TrainingDtl()
            {
                startDate = trainingDtl.startDate,
                endDate = trainingDtl.endDate,
                timeSlot = trainingDtl.timeSlot,
                accept = trainingDtl.accept,
                userId = trainingDtl.userId,
                userName = trainingDtl.userName,
                mentorId = trainingDtl.mentorId,
                skillId = trainingDtl.skillId,
                skillname = trainingDtl.skillname,
                rejected = trainingDtl.rejected,
                mentorName = trainingDtl.mentorName,

            };
            data.TrainingDtls.Add(newTraining);
            data.SaveChanges();
        }

        //get Training Data for showing approval
        public List<TrainingDtl> GetApproval()
        {
            List<TrainingDtl> dtls = data.TrainingDtls.ToList();
            return dtls;
        }

        //Approve and Rejected Training
        public void Approve(int id)
        {
            TrainingDtl user = data.TrainingDtls.Find(id);
            user.accept = true;
            user.rejected = false;
            data.Entry(user).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Declined(int id)
        {
            TrainingDtl user = data.TrainingDtls.Find(id);
            user.accept = false;
            user.rejected = true;
            data.Entry(user).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        //Get Training Details for Payment
        public IList<TrainingDtl> TrainingById(int id)
        {
            return data.TrainingDtls.Where(x => x.id == id).ToList();
        }

        //payment
          public void addPayment(PaymentDtl paymentDtl)
        {
            var myPay = new PaymentDtl()
            {
                txtType=paymentDtl.txtType,
                userId=paymentDtl.userId,
                mentorId=paymentDtl.mentorId,
                skillId=paymentDtl.skillId,
                skillName=paymentDtl.skillName,
                fees=paymentDtl.fees,
                mentorfees=paymentDtl.mentorfees,
                commision=paymentDtl.commision,
                PaymentStatus=paymentDtl.PaymentStatus
            };
            data.PaymentDtls.Add(myPay);
            data.SaveChanges();
        }

        //get all Payment
        public IList<PaymentDtl> GetAllPayment()
        {

           IList<PaymentDtl> dtl= data.PaymentDtls.ToList();
           return dtl;
        }

        //update Payment Status
        public void PayUpdate(int id)
        {
            TrainingDtl payStatus = data.TrainingDtls.Find(id);
            payStatus.PaymentStatus = true;
            data.Entry(payStatus).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        //Update Training Progress
        public void UpdateProg(TrainingDtl updateData)
        {
            TrainingDtl prog = data.TrainingDtls.Find(updateData.id);
            prog.progress = updateData.progress;
            data.Entry(prog).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        //AdminCommision
        public void AdminCommision(PaymentDtl commision)
        {
            PaymentDtl paymentDtl = data.PaymentDtls.Find(commision.id);
            paymentDtl.commision = commision.commision;
            paymentDtl.fees = commision.fees;
            data.Entry(paymentDtl).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }

        //Updation Trainer Profile

        public void UpdateProfile(UserDtl updateData)
        {
            UserDtl userDtl = data.UserDtls.Find(updateData.id);
            userDtl.firstName = updateData.firstName;
            userDtl.lastName = updateData.lastName;
            userDtl.contactNumber = updateData.contactNumber;
            userDtl.yearOfExperience = updateData.yearOfExperience;
            data.Entry(userDtl).State = EntityState.Modified;
            data.Configuration.ValidateOnSaveEnabled = false;
            data.SaveChanges();
            data.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
