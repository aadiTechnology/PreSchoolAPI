using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PreSchoolAPI.Models
{
    public class EnquiryModel
    {
        public int Id { get; set; }
        public string Class { get; set; }

        public string StudentName { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public string FatherName { get; set; }
        public string PhoneNo { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo2 { get; set; }
        public string SocietyName { get; set; }
        public string StudentAddress { get; set; }
        public string EmailId { get; set; }
        public bool sms1 { get; set; }

        public string CallStatus { get; set; }
        public string Reminder { get; set; }
        public string Comment { get; set; }
        public int StudentDetailsId { get; set; }
        public bool SMS { get; set; }
        public string AddStudentDetails()
        {
            string addStudentDetailsReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddStudentDetails";

                    oCommand.Parameters.Add(new SqlParameter("@Class", SqlDbType.VarChar))
                        .Value = Class;

                    oCommand.Parameters.Add(new SqlParameter("@StudentName", SqlDbType.VarChar))
                        .Value = StudentName;
                    oCommand.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.VarChar))
                        .Value = BirthDate;
                    oCommand.Parameters.Add(new SqlParameter("@Age", SqlDbType.Int))
                        .Value = Age;
                    oCommand.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.VarChar))
                        .Value = FatherName;
                    oCommand.Parameters.Add(new SqlParameter("@PhoneNo", SqlDbType.VarChar))
                        .Value = PhoneNo;
                    oCommand.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.VarChar))
                        .Value = MotherName;
                    oCommand.Parameters.Add(new SqlParameter("@PhoneNo2", SqlDbType.VarChar))
                        .Value = PhoneNo2;
                    oCommand.Parameters.Add(new SqlParameter("@SocietyName", SqlDbType.VarChar))
                        .Value = SocietyName;
                    oCommand.Parameters.Add(new SqlParameter("@StudentAddress", SqlDbType.VarChar))
                        .Value = StudentAddress;
                    oCommand.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.VarChar))
                        .Value = EmailId;
                    oCommand.Parameters.Add(new SqlParameter("@SMS", SqlDbType.VarChar))
                        .Value = SMS;
                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addStudentDetailsReturn = "Success";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        addStudentDetailsReturn = "Failure";
                    }

                }
            }
            return addStudentDetailsReturn;
        }

        public List<EnquiryModel> GetStudentDetails()
        {
            List<EnquiryModel> EnquiryModels = new List<EnquiryModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetStudentsDetails";

                    SqlParameter param;
                    param = oCommand.Parameters.Add("@StudentDetailsId", SqlDbType.Int);
                    param.Value = StudentDetailsId;

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            EnquiryModels.Add(
                            new EnquiryModel
                            {

                                //Id = Convert.ToInt32(dr["Id"].ToString()),
                                Class = dr["Class"].ToString(),
                                StudentName = dr["StudentName"].ToString(),
                                BirthDate = dr["BirthDate"].ToString(),
                                Age = Convert.ToInt32(dr["Age"].ToString()),
                                FatherName = dr["FatherName"].ToString(),
                                PhoneNo = dr["PhoneNo"].ToString(),
                                MotherName = dr["MotherName"].ToString(),
                                PhoneNo2 = dr["PhoneNo2"].ToString(),
                                SocietyName = dr["SocietyName"].ToString(),
                                StudentAddress = dr["StudentAddress"].ToString(),
                                EmailId = dr["EmailId"].ToString(),
                                SMS = Convert.ToBoolean(dr["SMS"].ToString()),

                            }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return EnquiryModels;
        }

    }

    public class FollowUpModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string CallStatus { get; set; }
        public string Reminder { get; set; }
        public string Comment { get; set; }

        public string FatherName { get; set; }
        public string PhoneNo { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo2 { get; set; }


        public string AddStudentFollowUp()

        {
            string addstudentfollowupReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddStudentFollowUp";

                    oCommand.Parameters.Add(new SqlParameter("@CallStatus", SqlDbType.VarChar))
                        .Value = CallStatus;
                    oCommand.Parameters.Add(new SqlParameter("@Reminder", SqlDbType.VarChar))
                        .Value = Reminder;
                    oCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar))
                        .Value = Comment;



                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addstudentfollowupReturn = "Success";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        addstudentfollowupReturn = "Failure";
                    }

                }
            }
            return addstudentfollowupReturn;
        }


        public List<FollowUpModel> GetStudentFollowUp()
        {
            List<FollowUpModel> EnquiryModels = new List<FollowUpModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetStudentFollowUp";

                    SqlParameter param;
                    param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                    param.Value = Id;

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            EnquiryModels.Add(
                                new FollowUpModel
                                {

                                    Id = Convert.ToInt32(dr["Id"].ToString()),
                                    StudentName = dr["StudentName"].ToString(),
                                    FatherName = dr["FatherName"].ToString(),
                                    PhoneNo = dr["PhoneNo"].ToString(),
                                    MotherName = dr["MotherName"].ToString(),
                                    PhoneNo2 = dr["PhoneNo2"].ToString(),
                                    CallStatus = dr["CallStatus"].ToString(),
                                    Reminder = dr["Reminder"].ToString(),
                                    Comment = dr["Comment"].ToString(),
                                }
                                );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return EnquiryModels;

        }

    }

    public class AdmissionDetails
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string MotherName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool Sms { get; set; }
        public string Camera { get; set; }
        public string Attachment { get; set; }
        public string BirthDate { get; set; }

        public string AdmissionConversion()
        {
            string admissionDetails = "";
            string connectioString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnecion = new SqlConnection(connectioString))
            {
                oConnecion.Open();
                using (SqlCommand oCommand = oConnecion.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddAdmissionDetails";
                    oCommand.Parameters.Add(new SqlParameter("@Class", SqlDbType.VarChar))
                        .Value = Class;
                    oCommand.Parameters.Add(new SqlParameter("@StudentName", SqlDbType.VarChar))
                        .Value = StudentName;
                    oCommand.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.VarChar))
                        .Value = FatherName;
                    oCommand.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.VarChar))
                        .Value = PhoneNumber;
                    oCommand.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.VarChar))
                        .Value = MotherName;
                    oCommand.Parameters.Add(new SqlParameter("@PhoneNumber1", SqlDbType.VarChar))
                        .Value = PhoneNumber1;
                    oCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar))
                        .Value = Address;
                    oCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar))
                        .Value = Email;
                    oCommand.Parameters.Add(new SqlParameter("@Sms", SqlDbType.VarChar))
                        .Value = Sms;
                    oCommand.Parameters.Add(new SqlParameter("@Camera", SqlDbType.VarChar))
                        .Value = Camera;
                    oCommand.Parameters.Add(new SqlParameter("@Attachment", SqlDbType.VarChar))
                        .Value = Attachment;
                    oCommand.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.VarChar))
                        .Value = BirthDate;


                    try
                    {
                        oCommand.ExecuteNonQuery();
                        admissionDetails = "Success";
                    }
                    catch (Exception e)
                    {
                        oConnecion.Close();
                        admissionDetails = "Failure";
                    }
                }
            }
            return admissionDetails;
        }

        public List<AdmissionDetails> GetAdmissionDetails()
        {
            List<AdmissionDetails> admissiondetailsModel = new List<AdmissionDetails>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetAdmissionDetails";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                    param.Value = Id;
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            admissiondetailsModel.Add(
                                new AdmissionDetails
                                {
                                    Class = dr["Class"].ToString(),
                                    StudentName = dr["StudentName"].ToString(),
                                    FatherName = dr["FatherName"].ToString(),
                                    PhoneNumber = dr["PhoneNumber"].ToString(),
                                    MotherName = dr["MotherName"].ToString(),
                                    PhoneNumber1 = dr["PhoneNumber1"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Sms = Convert.ToBoolean(dr["Sms"].ToString()),
                                    Camera = dr["Camera"].ToString(),
                                    Attachment = dr["Attachment"].ToString(),
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return admissiondetailsModel;
        }

    }

    public class TeacherModel
    {
        public string TeacherName { get; set; }
        public string TeacherBirthDate { get; set; }
        public string TeacherQualification { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherNumber { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherExperience { get; set; }
        public string TeacherJoiningDate { get; set; }

        public string InsertBy { get; set; }
        public string ClassId { get; set; }

        public int TeacherId { get; set; }

        public string AddTeacherDetails()
        {
            string addTeacherDatails = "";
            string connectioString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnecion = new SqlConnection(connectioString))
            {
                oConnecion.Open();
                using (SqlCommand oCommand = oConnecion.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddTeacherDetails";
                    oCommand.Parameters.Add(new SqlParameter("@TeacherName", SqlDbType.VarChar))
                        .Value = TeacherName;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherBirthDate", SqlDbType.VarChar))
                        .Value = TeacherBirthDate;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherQualification", SqlDbType.VarChar))
                        .Value = TeacherQualification;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherAddress", SqlDbType.VarChar))
                        .Value = TeacherAddress;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherNumber", SqlDbType.VarChar))
                        .Value = TeacherNumber;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherEmail", SqlDbType.VarChar))
                        .Value = TeacherEmail;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherExperience", SqlDbType.VarChar))
                        .Value = TeacherExperience;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherJoiningDate", SqlDbType.VarChar))
                        .Value = TeacherJoiningDate;
                    oCommand.Parameters.Add(new SqlParameter("@InsertBy", SqlDbType.VarChar))
                        .Value = InsertBy;
                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addTeacherDatails = "Success";
                    }
                    catch (Exception e)
                    {
                        oConnecion.Close();
                        addTeacherDatails = "Failure";
                    }
                }
            }
            return addTeacherDatails;
        }

        public List<TeacherModel> GetTeacherDetailsList()
        {
            List<TeacherModel> teacherModels = new List<TeacherModel>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetTeacherDetailslist";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@TeacherId", SqlDbType.Int);
                    param.Value = TeacherId;
                    try

                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            teacherModels.Add(
                                new TeacherModel
                                {
                                    TeacherName = dr["TeacherName"].ToString(),
                                    TeacherBirthDate = dr["TeacherBirthDate"].ToString(),
                                    TeacherQualification = dr["TeacherQualification"].ToString(),
                                    TeacherAddress = dr["TeacherAddress"].ToString(),
                                    TeacherNumber = dr["TeacherNumber"].ToString(),
                                    TeacherEmail = dr["TeacherEmail"].ToString(),
                                    TeacherExperience = dr["TeacherExperience"].ToString()
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return teacherModels;
        }

        public List<TeacherModel> GetAllTeacherDetailsList()
        {
            List<TeacherModel> teacherModels = new List<TeacherModel>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetAllTeacherDetailslist";
                    try

                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            teacherModels.Add(
                                new TeacherModel
                                {
                                    TeacherName = dr["TeacherName"].ToString(),
                                    TeacherBirthDate = dr["TeacherBirthDate"].ToString(),
                                    TeacherQualification = dr["TeacherQualification"].ToString(),
                                    TeacherAddress = dr["TeacherAddress"].ToString(),
                                    TeacherNumber = dr["TeacherNumber"].ToString(),
                                    TeacherEmail = dr["TeacherEmail"].ToString(),
                                    TeacherExperience = dr["TeacherExperience"].ToString()
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return teacherModels;
        }

        public List<TeacherModel> GetTeacherName()
        {

            List<TeacherModel> AddTeacherNameDropdownModels = new List<TeacherModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetTeacherDropdown";
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            AddTeacherNameDropdownModels.Add(
                            new TeacherModel
                            {
                                TeacherId = Convert.ToInt32(dr["TeacherId"].ToString()),
                                TeacherName = (dr["TeacherName"].ToString())
                            }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return AddTeacherNameDropdownModels;
        }


    }

    public class HomeworkDetailsModel
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public string AssignDate { get; set; }
        public string Attachment { get; set; }
        public int UserId { get; set; }
        public int TeacherId { get; set; }
        public string AddHomeworkDetails()

        {

            string addhomeworkdetailsReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddHomeworkDetails";


                    oCommand.Parameters.Add(new SqlParameter("@Class", SqlDbType.VarChar))
                        .Value = Class;
                    oCommand.Parameters.Add(new SqlParameter("@SubjectName", SqlDbType.VarChar))
                      .Value = SubjectName;
                    oCommand.Parameters.Add(new SqlParameter("@SubjectDescription", SqlDbType.VarChar))
                        .Value = SubjectDescription;
                    oCommand.Parameters.Add(new SqlParameter("@AssignDate", SqlDbType.VarChar))
                       .Value = AssignDate;
                    oCommand.Parameters.Add(new SqlParameter("@Attachment", SqlDbType.VarChar))
                       .Value = Attachment;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int))
                       .Value = UserId;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherId", SqlDbType.Int))
                        .Value = TeacherId;

                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addhomeworkdetailsReturn = "Success";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        addhomeworkdetailsReturn = "Failure";
                    }

                }
            }
            return addhomeworkdetailsReturn;
        }
        public string SubmitHomework()
        {
            string DeleteHomeworkReturn = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    oConnection.Open();
                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.CommandText = "USP_SubmitHomework";

                        SqlParameter param;
                        param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                        param.Value = Id;
                        int result = oCommand.ExecuteNonQuery();
                        if (result >= 1) 
                        {
                            DeleteHomeworkReturn = "Success";
                        }
                        else
                        {
                            DeleteHomeworkReturn = "Failure";
                        }
                        
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    
                    // Action after the exception is caught  
                }
            }
            return DeleteHomeworkReturn;
        }
        public List<HomeworkDetailsModel> GetHomeworkDetails()

        {
            List<HomeworkDetailsModel> homeworkdetailsModel = new List<HomeworkDetailsModel>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetHomeworkDetails";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                    param.Value = Id;
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            homeworkdetailsModel.Add(
                                new HomeworkDetailsModel
                                {
                                    Class = dr["Class"].ToString(),
                                    SubjectName = dr["SubjectName"].ToString(),
                                    SubjectDescription = dr["SubjectDescription"].ToString(),
                                    AssignDate = dr["AssignDate"].ToString(),
                                    Attachment = dr["Attachment"].ToString()
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return homeworkdetailsModel;
        }
        public List<HomeworkDetailsModel> GetHomeworkDetailsList()

        {
            List<HomeworkDetailsModel> homeworkdetailsModel = new List<HomeworkDetailsModel>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetHomeworkList";

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            homeworkdetailsModel.Add(
                                new HomeworkDetailsModel
                                {
                                    Id = Convert.ToInt32(dr["Id"].ToString()),
                                    Class = dr["Class"].ToString(),
                                    SubjectName = dr["SubjectName"].ToString(),
                                    SubjectDescription = dr["SubjectDescription"].ToString(),
                                    AssignDate = dr["AssignDate"].ToString(),
                                    Attachment = dr["Attachment"].ToString()
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return homeworkdetailsModel;
        }
        public List<HomeworkDetailsModel> GetViewHomeWorkList()

        {
            List<HomeworkDetailsModel> viewhomeworkModel = new List<HomeworkDetailsModel>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetViewHomeWork";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@AssignDate", SqlDbType.VarChar);
                    param.Value = AssignDate;
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            viewhomeworkModel.Add(
                                new HomeworkDetailsModel
                                {
                                    SubjectDescription = dr["SubjectDescription"].ToString(),
                                    AssignDate = dr["AssignDate"].ToString(),
                                    Attachment = dr["Attachment"].ToString(),
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return viewhomeworkModel;
        }
        public HomeworkDetailsModel GetDateForLegend()

        {
            HomeworkDetailsModel viewhomeworkModel = new HomeworkDetailsModel();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetDateForLegend";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@AssignDate", SqlDbType.VarChar);
                    param.Value = AssignDate;
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {

                            viewhomeworkModel = new HomeworkDetailsModel
                            {
                                AssignDate = dr["AssignDate"].ToString(),
                                SubjectName = dr["SubjectName"].ToString()
                                
                            };
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return viewhomeworkModel;
        }
        public HomeworkDetailsModel HomeworkDetailsListForEdit()
        {
            HomeworkDetailsModel HomeworkDetails = new HomeworkDetailsModel();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_HomeworkDetailsListForEdit";

                    SqlParameter param;
                    param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                    param.Value = Id;

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            HomeworkDetails = new HomeworkDetailsModel
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                Class = dr["Class"].ToString(),
                                SubjectName = dr["SubjectName"].ToString(),
                                SubjectDescription = dr["SubjectDescription"].ToString(),
                                AssignDate = dr["AssignDate"].ToString(),
                                Attachment = dr["Attachment"].ToString()
                            };
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                    }
                }
            }
            return HomeworkDetails;
        }
        public string DeleteHomeworkDetails()
        {
            string DeleteHomeworkReturn = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    oConnection.Open();
                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.CommandText = "USP_DeleteHomeworkDetails";

                        SqlParameter param;
                        param = oCommand.Parameters.Add("@HomeworkId", SqlDbType.Int);
                        param.Value = Id;
                        oCommand.ExecuteNonQuery();
                        DeleteHomeworkReturn = "Success";
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    DeleteHomeworkReturn = "Failure";
                    // Action after the exception is caught  
                }
            }
            return DeleteHomeworkReturn;
        }

    }
    public class ClassModel

    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string InsertBy { get; set; }
        public string TeacherId { get; set; }
        public int UserId { get; set; }
        public string AddClassDetails()
        {
            string AddClassDetails1Return = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddClassDetails";
                    oCommand.Parameters.Add(new SqlParameter("@ClassName", SqlDbType.VarChar))
                    .Value = ClassName;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar))
                  .Value = UserId;
                    try
                    {
                        oCommand.ExecuteNonQuery();
                        AddClassDetails1Return = "Success";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        AddClassDetails1Return = "Failure";
                    }
                }
            }
            return AddClassDetails1Return;
        }
        public List<ClassModel> GetClassNameList()
        {

            List<ClassModel> ClassModels = new List<ClassModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetClassDropdown";

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            ClassModels.Add(
                            new ClassModel
                            {
                                ClassId = Convert.ToInt32(dr["ClassId"].ToString()),
                                ClassName = dr["ClassName"].ToString(),
                            }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return ClassModels;
        }
    }

    public class PhotoAlbumModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string FacebookLink { get; set; }
        public string Class { get; set; }
        public string AlbumDate { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public int CreatedBy { get; set; }

        public string AddPhotoAlbum()
        {
            string AddPhotoAlbumReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddPhotoAlbum";

                    oCommand.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar))
                    .Value = Title;
                    oCommand.Parameters.Add(new SqlParameter("@FacebookLink", SqlDbType.VarChar))
                   .Value = FacebookLink;
                    oCommand.Parameters.Add(new SqlParameter("@Class", SqlDbType.VarChar))
                   .Value = Class;
                    oCommand.Parameters.Add(new SqlParameter("@AlbumDate", SqlDbType.VarChar))
                   .Value = AlbumDate;
                    oCommand.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int))
                        .Value = CreatedBy;

                    try
                    {
                        oCommand.ExecuteNonQuery();
                        AddPhotoAlbumReturn = "Success";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        AddPhotoAlbumReturn = "Failure";
                    }

                }

            }
            return AddPhotoAlbumReturn;

        }

        public List<PhotoAlbumModel> GetAllAlbumNameList()
        {

            List<PhotoAlbumModel> photoModels = new List<PhotoAlbumModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetAllAlbumNameList";

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            photoModels.Add(
                            new PhotoAlbumModel
                            {
                                AlbumId = Convert.ToInt32(dr["AlbumId"].ToString()),
                                Title = dr["Title"].ToString(),
                                Class = dr["Class"].ToString(),
                                AlbumDate = dr["AlbumDate"].ToString(),
                                FacebookLink = dr["FacebookLink"].ToString()

                            }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return photoModels;
        }
        public List<PhotoAlbumModel> GetYearDropDownForAlbumList()
        {

            List<PhotoAlbumModel> photoModels = new List<PhotoAlbumModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetYearDropDown";

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            photoModels.Add(
                            new PhotoAlbumModel
                            {

                                AlbumDate = dr["AlbumDate"].ToString()

                            }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return photoModels;
        }
        public List<PhotoAlbumModel> GetMonthDropDownForAlbumList()
        {

            List<PhotoAlbumModel> photoModels = new List<PhotoAlbumModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetMonthDropDown";

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            photoModels.Add(
                            new PhotoAlbumModel
                            {

                                AlbumDate = dr["month_name"].ToString()

                            }
                            );
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        // Action after the exception is caught  
                    }
                }
            }
            return photoModels;
        }
        public List<PhotoAlbumModel> GetAlbumNameList()
        {
            List<PhotoAlbumModel> albumModels = new List<PhotoAlbumModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetAlbumNameList";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@GetMonth", SqlDbType.Int);
                    param.Value = month;
                    param = oCommand.Parameters.Add("@GetYear", SqlDbType.Int);
                    param.Value = year;
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            albumModels.Add(
                               new PhotoAlbumModel
                               {
                                   Title = dr["Title"].ToString()
                               });
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                    }

                }
            }
            return albumModels;
        }
        public string DeletePhotoAlbum()
        {
            string DeletePhotoalbumReturn = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    oConnection.Open();
                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.CommandText = "USP_DeletePhotoAlbum";

                        SqlParameter param;
                        param = oCommand.Parameters.Add("@AlbumId", SqlDbType.Int);
                        param.Value = AlbumId;
                        oCommand.ExecuteNonQuery();
                        DeletePhotoalbumReturn = "Success";
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    DeletePhotoalbumReturn = "Failure";
                    // Action after the exception is caught  
                }
            }
            return DeletePhotoalbumReturn;
        }
    }

    public class UserLoginModel
    {
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string LoginPassword { get; set; }
        public string UserType { get; set; }
        public string BirthDate { get; set; }
        public string EmailIdOrPhone { get; set; }
        public UserLoginModel UserLogin()
        {


            UserLoginModel userLogin = new UserLoginModel();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oconnection = new SqlConnection(connectionstring))
            {
                oconnection.Open();
                using (SqlCommand oCommand = oconnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetLoginType";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@EmailIdOrPhone", SqlDbType.VarChar);
                    param.Value = EmailIdOrPhone;
                    param = oCommand.Parameters.Add("@LoginPassword", SqlDbType.VarChar);
                    param.Value = LoginPassword;

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            userLogin = new UserLoginModel
                            {
                                UserType = dr["UserType"].ToString()
                            };
                        }

                    }
                    catch (Exception e)
                    {
                        oconnection.Close();
                    }
                }
            }

            return userLogin;
        }
        public UserLoginModel ForgotPassword()
        {

            UserLoginModel userModel = new UserLoginModel();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_ForgotPassword";

                    SqlParameter param;
                    param = oCommand.Parameters.Add("@EmailId", SqlDbType.VarChar);
                    param.Value = EmailId;
                    param = oCommand.Parameters.Add("@PhoneNo", SqlDbType.VarChar);
                    param.Value = PhoneNo;
                    param = oCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar);
                    param.Value = BirthDate;

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            userModel = new UserLoginModel
                            {
                                LoginPassword = dr["LoginPassword"].ToString()
                            };
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();

                    }
                }
            }
            return userModel;
        }
    }



}