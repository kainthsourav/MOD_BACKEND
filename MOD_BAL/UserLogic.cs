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
            try
            {
                return data.UserDtls.ToList();
            }
            catch
            {
                throw;
            }
           
        }

        public UserDtl GetUserById(int id)
        {
            try
            {
                return data.UserDtls.Find(id);
            }
            catch
            {
                throw;
            }
           
        }

        public UserInfo Register(UserDtl userDtl)
        {
            //Adding Trainer
            try
            {
                string message = null;
                UserDtl emailCheck = data.UserDtls.SingleOrDefault(x => x.email == userDtl.email);

                if (emailCheck == null)
                {
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
                        message = "Registered Successfully";

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
                        message = "Registered Successfully";
                    }
                }
                else
                {
                    message = "Email Already Exists";
                }


                return new UserInfo()
                {
                    message = message
                };
            }
            catch
            {
                throw;
            }

        }

        public void BlockUser(int id)
        {
            try
            {
                UserDtl user = data.UserDtls.Find(id);
                user.active = false;
                data.Entry(user).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                //ata.UserDtls.Remove(user);
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
          
        }

        public void UnBlockUser(int id)
        {
            try
            {
                UserDtl user = data.UserDtls.Find(id);
                user.active = true;
                data.Entry(user).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
           
        }

        public void UpdateUser(UserDtl userDtl)
        {
            try
            {
                data.Entry(userDtl).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
            
        }

        //Sigin in 
        public UserDtl SignIn(UserDtl loginDtl)
        {
            try
            {
                UserDtl Vaildlogin = data.UserDtls.FirstOrDefault(x => x.email == loginDtl.email && x.password == loginDtl.password);

                return Vaildlogin;
            }

            catch
            {
                throw;
            }
          

        }


        //SkillDtls Logic
        public IList<SkillDtl> GetAllSkills()
        {
            try
            {
                return data.SkillDtls.ToList();
            }
            catch
            {
                throw;
            }
           
        }

        public List<SkillDtl> GetSkillsPrice(string id)
        {
            try
            {
                return data.SkillDtls.Where(x => x.name == id).ToList();
            }
            catch
            {
                throw;
            }
            
        }

        public IList<SkillDtl> GetSkillById(int id)
        {
            try
            {
                return data.SkillDtls.Where(x => x.id == id).ToList();
            }
            catch
            {
                throw;
            }
         
        }
        public void AddNewSkill(SkillDtl skillDtl)
        {
            try
            {
                data.SkillDtls.Add(skillDtl);
                data.SaveChanges();
            }
            catch
            {
                throw;
            }
          
        }

        public void DeleteSkill(int id)
        {
            try
            {
                data.SkillDtls.Remove(data.SkillDtls.Find(id));
                data.SaveChanges();
            }
            catch
            {
                throw;
            }
           
        }

        public void EditSkill(SkillDtl skillDtl)
        {
            try
            {
                data.Entry(skillDtl).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
           
        }

        public List<UserDtl> Search(string Data)
        {
            try
            {
                List<UserDtl> mentors;
                mentors = data.UserDtls.Where(x => x.TrainerTechnology == Data).ToList();
                return mentors;
            }
            catch
            {
                throw;
            }
            
        }

        //Save to Trainer Table
        public void addTrainingDtls(TrainingDtl trainingDtl)
        {
            try
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
            catch
            {
                throw;
            }
       
        }

        //get Training Data for showing approval
        public List<TrainingDtl> GetApproval()
        {
            try
            {
                List<TrainingDtl> dtls = data.TrainingDtls.ToList();
                return dtls;
            }
            catch
            {
                throw;
            }
          
        }

        //Approve and Rejected Training
        public void Approve(int id)
        {
            try
            {
                TrainingDtl user = data.TrainingDtls.Find(id);
                user.accept = true;
                user.rejected = false;
                data.Entry(user).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
           
        }

        public void Declined(int id)
        {
            try
            {
                TrainingDtl user = data.TrainingDtls.Find(id);
                user.accept = false;
                user.rejected = true;
                data.Entry(user).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
            
        }

        //Get Training Details for Payment
        public IList<TrainingDtl> TrainingById(int id)
        {
            try
            {
                return data.TrainingDtls.Where(x => x.id == id).ToList();
            }
            catch
            {
                throw;
            }
        }

        //payment
          public void addPayment(PaymentDtl paymentDtl)
        {
            try
            {
                var myPay = new PaymentDtl()
                {
                    txtType = paymentDtl.txtType,
                    userId = paymentDtl.userId,
                    mentorId = paymentDtl.mentorId,
                    skillId = paymentDtl.skillId,
                    skillName = paymentDtl.skillName,
                    fees = paymentDtl.fees,
                    mentorfees = paymentDtl.mentorfees,
                    commision = paymentDtl.commision,
                    PaymentStatus = paymentDtl.PaymentStatus
                };
                data.PaymentDtls.Add(myPay);
                data.SaveChanges();
            }
            catch
            {
                throw;
            }
           
        }

        //get all Payment
        public IList<PaymentDtl> GetAllPayment()
        {
            try
            {
                IList<PaymentDtl> dtl = data.PaymentDtls.ToList();
                return dtl;
            }
            catch
            {
                throw;
            }
          
        }

        //update Payment Status
        public void PayUpdate(int id)
        {
            try
            {
                TrainingDtl payStatus = data.TrainingDtls.Find(id);
                payStatus.PaymentStatus = true;
                data.Entry(payStatus).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
           
        }

        //Update Training Progress
        public void UpdateProg(TrainingDtl updateData)
        {
            try
            {
                TrainingDtl prog = data.TrainingDtls.Find(updateData.id);
                prog.progress = updateData.progress;
                data.Entry(prog).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
        }

        //AdminCommision
        public void AdminCommision(PaymentDtl commision)
        {
            try
            {
                PaymentDtl paymentDtl = data.PaymentDtls.Find(commision.id);
                paymentDtl.commision = commision.commision;
                paymentDtl.fees = commision.fees;
                data.Entry(paymentDtl).State = EntityState.Modified;
                data.Configuration.ValidateOnSaveEnabled = false;
                data.SaveChanges();
                data.Configuration.ValidateOnSaveEnabled = true;
            }
            catch
            {
                throw;
            }
        }

        //Updation Trainer Profile

        public void UpdateProfile(UserDtl updateData)
        {
            try
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
            catch
            {
                throw;
            }
        }
    }
}
