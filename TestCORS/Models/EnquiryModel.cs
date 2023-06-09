﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PreSchoolAPI.Models
{
    public class EnquiryModel
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public int ClassId { get; set; }
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
        public int StudentDetailsId { get; set; }
        public bool SMS { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDate { get; set; }

        public string ClassName { get; set; }
        public string AddStudentEnquiryDetails()
        {
            string addStudentDetailsReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddStudentEnquiryDetails";

                    oCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar))
                        .Value = ClassId;

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
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar))
                        .Value = UserId;
                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addStudentDetailsReturn = "Student Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        addStudentDetailsReturn = "Faild to Add Student";
                    }

                }
            }
            return addStudentDetailsReturn;
        }

        public List<EnquiryModel> GetStudentEnquiryDetailsList()
        {
            List<EnquiryModel> EnquiryModels = new List<EnquiryModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetStudentEnquiryDetailsList";
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            EnquiryModels.Add(
                            new EnquiryModel
                            {

                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                ClassName = dr["ClassName"].ToString(),
                                StudentName = dr["StudentName"].ToString(),
                                FatherName = dr["FatherName"].ToString(),
                                PhoneNo = dr["PhoneNo"].ToString()

                            }
                            ); ;
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
        public string EmailId { get; set; }
        public string FatherName { get; set; }
        public string PhoneNo { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo2 { get; set; }
        public string ClassName { get; set; }
        public int UserId { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public string SocietyName { get; set; }

        public string StudentAddress { get; set; }
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

                    oCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar))
                        .Value = Id;

                    oCommand.Parameters.Add(new SqlParameter("@CallStatus", SqlDbType.VarChar))
                        .Value = CallStatus;
                    oCommand.Parameters.Add(new SqlParameter("@Reminder", SqlDbType.VarChar))
                        .Value = Reminder;
                    oCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar))
                        .Value = Comment;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar))
                        .Value = UserId;



                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addstudentfollowupReturn = "FollowUp Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        addstudentfollowupReturn = "Faild to Add FollowUp ";
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

        public List<FollowUpModel> GetStudentFollowUpList()
        {
            List<FollowUpModel> EnquiryModels = new List<FollowUpModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetStudentFollowUpList";
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
                                    CallStatus = dr["CallStatus"].ToString(),
                                    Comment=dr["Comment"].ToString(),
                                    Reminder = dr["Reminder"].ToString()
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
        public List<FollowUpModel> GetStudentDetailsForFollowUp()
        {
            List<FollowUpModel> EnquiryModels = new List<FollowUpModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetStudentDetailsForFollowUp";

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
                                    EmailId = dr["EmailId"].ToString(),
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
            return EnquiryModels;

        }

        public FollowUpModel EditStudentEnquirydetails()
        {
            FollowUpModel EditDetails = new FollowUpModel();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetStudentEnquiryListForEdit";

                    SqlParameter param;
                    param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                    param.Value = Id;

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            EditDetails = new FollowUpModel
                            {


                                Id = Convert.ToInt32(dr["Id"].ToString()),
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

                            };
                        }
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                    }
                }

            }
            return EditDetails;
        }


        public string DeleteStudentDetails()
        {
            string DeleteStudentDetailsReturn = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    oConnection.Open();
                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.CommandText = "USP_GetDeleteStudentEnquiry";

                        SqlParameter param;
                        param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                        param.Value = Id;
                        oCommand.ExecuteNonQuery();
                        DeleteStudentDetailsReturn = " Student Details Deleted Successfully";
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    DeleteStudentDetailsReturn = "Failed to Delete Student Details  ";

                }
            }
            return DeleteStudentDetailsReturn;
        }

        public string DeleteFollowUpList()
        {
            string DeleteFollowUpReturn = "";
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                try
                {
                    oConnection.Open();
                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.CommandText = "USP_DeleteFollowUpList";

                        SqlParameter param;
                        param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                        param.Value = Id;
                        oCommand.ExecuteNonQuery();
                        DeleteFollowUpReturn = " FollowUp List Deleted Successfully";
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    DeleteFollowUpReturn = "Failed to  Delete  FollowUp List  ";

                }
            }
            return DeleteFollowUpReturn;
        }


    }
    

}


    public class AdmissionDetails
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string PhoneNo { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo1 { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public bool Sms { get; set; }
        public string Camera { get; set; }
        public string Attachment { get; set; }
        public string BirthDate { get; set; }
        public int UserId { get; set; }

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
                    oCommand.CommandText = "USP_AddAdmissionConversionDetails";
                    oCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar))
                        .Value = ClassId;
                    oCommand.Parameters.Add(new SqlParameter("@StudentName", SqlDbType.VarChar))
                        .Value = StudentName;
                    oCommand.Parameters.Add(new SqlParameter("@FatherName", SqlDbType.VarChar))
                        .Value = FatherName;
                    oCommand.Parameters.Add(new SqlParameter("@PhoneNo", SqlDbType.VarChar))
                        .Value = PhoneNo;
                    oCommand.Parameters.Add(new SqlParameter("@MotherName", SqlDbType.VarChar))
                        .Value = MotherName;
                    oCommand.Parameters.Add(new SqlParameter("@PhoneNo1", SqlDbType.VarChar))
                        .Value = PhoneNo1;
                    oCommand.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.VarChar))
                        .Value = EmailId;
                    oCommand.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.VarChar))
                        .Value = BirthDate;
                    oCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar))
                        .Value = Address;
                    oCommand.Parameters.Add(new SqlParameter("@Sms", SqlDbType.VarChar))
                        .Value = Sms;
                    oCommand.Parameters.Add(new SqlParameter("@Attachment", SqlDbType.VarChar))
                        .Value = Attachment;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar))
                       .Value = UserId;


                    try
                    {
                        oCommand.ExecuteNonQuery();
                        admissionDetails = "Admission Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnecion.Close();
                        admissionDetails = "Faild to Add Admission ";
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
                                    ClassId =Convert.ToInt32(dr["ClassId"].ToString()),
                                    StudentName = dr["StudentName"].ToString(),
                                    FatherName = dr["FatherName"].ToString(),
                                    PhoneNo = dr["PhoneNo"].ToString(),
                                    MotherName = dr["MotherName"].ToString(),
                                    PhoneNo1 = dr["PhoneNo1"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    EmailId = dr["EmailId"].ToString(),
                                    Sms = Convert.ToBoolean(dr["Sms"].ToString()),
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public string Phoneno { get; set; }
        public string EmailId { get; set; }
        public string Experience { get; set; }
        public string JoiningDate { get; set; }
         public int UserId { get; set; }
      

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
                    
                    oCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar))
                        .Value = Name;
                    oCommand.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.VarChar))
                        .Value = BirthDate;
                    oCommand.Parameters.Add(new SqlParameter("@Qualification", SqlDbType.VarChar))
                        .Value = Qualification;
                    oCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar))
                        .Value = Address;
                    oCommand.Parameters.Add(new SqlParameter("@Phoneno", SqlDbType.VarChar))
                        .Value = Phoneno;
                    oCommand.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.VarChar))
                        .Value = EmailId;
                    oCommand.Parameters.Add(new SqlParameter("@Experience", SqlDbType.VarChar))
                        .Value = Experience;
                    oCommand.Parameters.Add(new SqlParameter("@JoiningDate", SqlDbType.VarChar))
                        .Value = JoiningDate;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar))
                        .Value = UserId;
                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addTeacherDatails = "Teacher Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnecion.Close();
                        addTeacherDatails = "Faild to Add Teacher";
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
                    param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                    param.Value = Id;
                    try

                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            teacherModels.Add(
                                new TeacherModel
                                {
                                    Id = Convert.ToInt32(dr["Id"].ToString()),
                                   Name = dr["Name"].ToString(),
                                    BirthDate = dr["BirthDate"].ToString(),
                                    Qualification = dr["Qualification"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    Phoneno = dr["Phoneno"].ToString(),
                                    EmailId = dr["EmailId"].ToString(),
                                    Experience = dr["Experience"].ToString()
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
                                    Id = Convert.ToInt32(dr["Id"].ToString()),
                                    Name = dr["Name"].ToString(),
                                    BirthDate = dr["BirthDate"].ToString(),
                                    Qualification = dr["Qualification"].ToString(),
                                    Address = dr["Address"].ToString(),
                                    Phoneno = dr["Phoneno"].ToString(),
                                    EmailId = dr["EmailId"].ToString(),
                                    Experience = dr["Experience"].ToString()
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
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                Name = (dr["Name"].ToString())
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
        public int ClassDivisionId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectDescription { get; set; }
        public string AssignDate { get; set; }
        public int AcademicId { get; set; }
        public string BinaryData { get; set; }
        public string Attachment { get; set; }
        public string AttachmentName { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        
        public string ClassName { get; set; }
        public string DivisionName { get; set; }
        public string SubjectName { get; set; }
        public bool IsSubmited { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public List<string> HomeworkDate { get; set; }
        public bool AllowPrevious { get; set; }
        public bool AllowNext { get; set; }

        public string AddHomeworkDetails()

        {
        if (!string.IsNullOrEmpty(AttachmentName))
        {
            if (!string.IsNullOrEmpty(BinaryData))
            {
                string sFileName = AttachmentName.Insert(AttachmentName.LastIndexOf("."), DateTime.Now.ToString("$yyyyMMddHHmmss")).Replace(" ", "_");
                string sFilePath = ConfigurationManager.AppSettings["DoccumentPath"];
                byte[] FileData = System.Convert.FromBase64String(BinaryData);
                FileStream fileStream = File.Create((sFilePath + sFileName), (int)FileData.Length);
                fileStream.Write(FileData, 0, FileData.Length);
                fileStream.Close();
                Attachment = sFileName;
            }
        }
        string addhomeworkdetailsReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddHomeworkDetails";


                    oCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int))
                        .Value = Id;
                    oCommand.Parameters.Add(new SqlParameter("@ClassDivisionId", SqlDbType.Int))
                        .Value = ClassDivisionId;
                    oCommand.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.Int))
                      .Value = SubjectId;
                    oCommand.Parameters.Add(new SqlParameter("@SubjectDescription", SqlDbType.VarChar))
                        .Value = SubjectDescription;
                    oCommand.Parameters.Add(new SqlParameter("@AssignDate", SqlDbType.VarChar))
                       .Value = AssignDate;
                    oCommand.Parameters.Add(new SqlParameter("@AcademicId", SqlDbType.Int))
                       .Value = AcademicId;
                oCommand.Parameters.Add(new SqlParameter("@Attachment", SqlDbType.VarChar))
                   .Value = Attachment;
                oCommand.Parameters.Add(new SqlParameter("@AttachmentName", SqlDbType.VarChar))
                   .Value = AttachmentName;
                oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int))
                       .Value = UserId;



                    try
                    {
                        oCommand.ExecuteNonQuery();
                        addhomeworkdetailsReturn = "Homework Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        addhomeworkdetailsReturn = "Faild to Add Homework";
                    }

                }
            }
            return addhomeworkdetailsReturn;
        }
        public string SubmitHomework()
        {
            string SubmitHomeworkReturn = "";
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
                            SubmitHomeworkReturn = "Homework Submited Successfully";
                        }
                        else
                        {
                            SubmitHomeworkReturn = "Faild to Submit Homework";
                        }
                        
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    
                    // Action after the exception is caught  
                }
            }
            return SubmitHomeworkReturn;
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
                                    Id = Convert.ToInt32(dr["Id"].ToString()),
                                    ClassDivisionId = Convert.ToInt32(dr["ClassDivisionId"].ToString()),
                                    ClassName = dr["DivisionName"].ToString(),
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

        public HomeworkDetailsModel GetDatewiseHomeworkDetails()

        {
            HomeworkDetailsModel homeworkdetailsModel = new HomeworkDetailsModel();
            homeworkdetailsModel.HomeworkDate = new List<string>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetDatewiseHomeworkDetails";
                    SqlParameter param;
                param = oCommand.Parameters.Add("@ClassDivisionId", SqlDbType.Int);
                param.Value = ClassDivisionId;
                param = oCommand.Parameters.Add("@StartDate", SqlDbType.VarChar);
                param.Value = StartDate;
                param = oCommand.Parameters.Add("@EndDate", SqlDbType.VarChar);
                    param.Value = EndDate;
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {

                            homeworkdetailsModel.HomeworkDate.Add( dr["HomeworkDate"].ToString());
                        }
                        while (dr.NextResult())
                        {
                            while (dr.Read())
                            {
                                homeworkdetailsModel.AllowPrevious = Convert.ToBoolean(dr["AllowPrevious"].ToString());
                                homeworkdetailsModel.AllowNext = Convert.ToBoolean(dr["AllowNext"].ToString());
                            }
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
                                    ClassDivisionId = Convert.ToInt32(dr["ClassDivisionId"].ToString()),
                                    DivisionName = dr["DivisionName"].ToString(),
                                    SubjectName = dr["SubjectName"].ToString(),
                                    SubjectDescription = dr["SubjectDescription"].ToString(),
                                    AssignDate = dr["AssignDate"].ToString(),
                                    Attachment = dr["Attachment"].ToString(),
                                    IsSubmited = Convert.ToBoolean(dr["IsSubmited"].ToString())
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
                    param = oCommand.Parameters.Add("@Id", SqlDbType.VarChar);
                    param.Value = Id;
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
        public List<HomeworkDetailsModel> GetDateForLegend()

        {
            List<HomeworkDetailsModel> viewhomeworkModel = new List<HomeworkDetailsModel>();
            string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionstring))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetDateForLegend";
                    SqlParameter param;
                    param = oCommand.Parameters.Add("@ClassDivisionId", SqlDbType.Int);
                    param.Value = ClassDivisionId;
                    param = oCommand.Parameters.Add("@AssignDate", SqlDbType.VarChar);
                    param.Value = AssignDate;
                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {

                            viewhomeworkModel.Add( new HomeworkDetailsModel
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                AssignDate = dr["AssignDate"].ToString(),
                                SubjectName = dr["SubjectName"].ToString()
                                
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
                                ClassDivisionId = Convert.ToInt32(dr["ClassDivisionId"].ToString()),
                                SubjectId = Convert.ToInt32(dr["SubjectId"].ToString()),
                                ClassName = dr["ClassName"].ToString(),
                                SubjectName = dr["SubjectName"].ToString(),
                                SubjectDescription = dr["SubjectDescription"].ToString(),
                                AssignDate = dr["AssignDate"].ToString(),
                                Attachment = dr["Attachment"].ToString(),
                                AttachmentName = dr["AttachmentName"].ToString()
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
                        DeleteHomeworkReturn = "Homework Deleted Successfully";
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    DeleteHomeworkReturn = "Faild to Delete Homework ";
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
                        AddClassDetails1Return = "Class Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        AddClassDetails1Return = "Faild to Add Class";
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
                                ClassId = Convert.ToInt32(dr["Id"].ToString()),
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
        public string AssignClassToTeacher()
        {
            string AddClassDetails1Return = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AssignClassToTeacher";
                    oCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar))
                    .Value = ClassId;
                    oCommand.Parameters.Add(new SqlParameter("@TeacherId", SqlDbType.VarChar))
                    .Value = TeacherId;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar))
                  .Value = UserId;
                    try
                    {
                        oCommand.ExecuteNonQuery();
                        AddClassDetails1Return = "Assign Class To Teacher Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        AddClassDetails1Return = "Faild to Add Assign Class To Teacher";
                    }
                }
            }
            return AddClassDetails1Return;
        }
    }

    public class PhotoAlbumModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FacebookLink { get; set; }
        public string Class { get; set; }
        public string AlbumDate { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public int UserId { get; set; }

        public int ClassId { get; set; }

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
                    oCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.Int))
                   .Value = ClassId;
                    oCommand.Parameters.Add(new SqlParameter("@AlbumDate", SqlDbType.VarChar))
                   .Value = AlbumDate;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int))
                        .Value = UserId;

                    try
                    {
                        oCommand.ExecuteNonQuery();
                        AddPhotoAlbumReturn = "Photo Album Added Successfully";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        AddPhotoAlbumReturn = "Faild to Add Photo Album";
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
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                Title = dr["Title"].ToString(),
                                Class = dr["ClassName"].ToString(),
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
                                   Title = dr["Title"].ToString(),
                                   FacebookLink = dr["FacebookLink"].ToString()
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
                        param = oCommand.Parameters.Add("@Id", SqlDbType.Int);
                        param.Value = Id;
                        oCommand.ExecuteNonQuery();
                        DeletePhotoalbumReturn = "Photo Album Deleted Successfully";
                    }
                }
                catch (Exception e)
                {
                    oConnection.Close();
                    DeletePhotoalbumReturn = "Faild to Delete Photo Album ";
                     
                }
            }
            return DeletePhotoalbumReturn;
        }
    }

    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string LoginPassword { get; set; }
        public string UserType { get; set; }
        public string BirthDate { get; set; }
        public string EmailIdOrPhone { get; set; }
    public string ClassDivisionName { get; set; }

    public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public int ClassDivisionId { get; set; }
        public int ClassId { get; set; }
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
                                UserName = dr["UserName"].ToString(),
                                ClassDivisionName = dr["ClassDivisionName"].ToString(),
                                UserId = Convert.ToInt32(dr["UserId"].ToString()),
                                UserRoleId = Convert.ToInt32(dr["UserRoleId"].ToString()),
                                ClassId = Convert.ToInt32(dr["ClassId"].ToString()),
                                ClassDivisionId = Convert.ToInt32(dr["ClassDivisionId"].ToString()),
                                EmailId = dr["EmailId"].ToString(),
                                PhoneNo = dr["PhoneNo"].ToString(),
                                BirthDate = dr["BirthDate"].ToString(),
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

        public string AddUserLoginInfo()
        {
            string AddPhotoAlbumReturn = "";
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connetionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_AddUserLoginInfo";

                    oCommand.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.VarChar))
                    .Value = EmailId;
                    oCommand.Parameters.Add(new SqlParameter("@PhoneNo", SqlDbType.VarChar))
                   .Value = PhoneNo;
                    oCommand.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.VarChar))
                   .Value = BirthDate;
                    oCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int))
                        .Value = UserId;

                    try
                    {
                        oCommand.ExecuteNonQuery();
                        AddPhotoAlbumReturn = "user login added";
                    }
                    catch (Exception e)
                    {
                        oConnection.Close();
                        AddPhotoAlbumReturn = "Faild to Add user login";
                    }

                }

            }
            return AddPhotoAlbumReturn;

        }
    }

    public class SubjectModel
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public List<SubjectModel> GetSubjectNameDropdown()
        {

            List<SubjectModel> ClassModels = new List<SubjectModel>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = oConnection.CreateCommand())
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandText = "USP_GetSubjectNameDropdown";

                    try
                    {
                        SqlDataReader dr = oCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            ClassModels.Add(
                            new SubjectModel
                            {
                                Id = Convert.ToInt32(dr["Id"].ToString()),
                                SubjectName = dr["SubjectName"].ToString(),
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



