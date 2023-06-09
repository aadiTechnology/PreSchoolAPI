﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PreSchoolAPI.Models;
namespace TestCORS.Controllers
{
    public class EnquiryController : ApiController
    {
        [HttpPost]
        [Route("AddStudentDetails")]
        public string AddStudentDetails([FromBody] EnquiryModel enquiryModel)
        {
            return enquiryModel.AddStudentDetails();
        }

        //get GetStudentDetails
        [HttpPost]
        [Route("GetStudentDetails")]
        public List<EnquiryModel> GetStudentDetails([FromBody] EnquiryModel enquiryModel)
        {
            return enquiryModel.GetStudentDetails();

        }

        [HttpPost]
        [Route("AddStudentFollowUp")]
        public string AddStudentFollowUp([FromBody] FollowUpModel followUpModel)
        {
            return followUpModel.AddStudentFollowUp();
        }

        [HttpPost]
        [Route("GetStudentFollowUp")]
        public List<FollowUpModel> GetStudentFollowUp([FromBody] FollowUpModel followUpModel)
        {

            return followUpModel.GetStudentFollowUp();
        }


        [HttpPost]
        [Route("AdmissionConversion")]
        public string AdmissionConversion([FromBody] AdmissionDetails admissionDetails)
        {
            return admissionDetails.AdmissionConversion();
        }


        [HttpPost]
        [Route("GetAdmissionDetails")]
        public List<AdmissionDetails> GetAdmissionDetails([FromBody] AdmissionDetails admissionDetails)
        {

            return admissionDetails.GetAdmissionDetails();
        }


        [HttpPost]
        [Route("AddTeacherDetails")]
        public string AddTeacherDetails([FromBody] TeacherModel teacherModel)
        {
            return teacherModel.AddTeacherDetails();
        }


        [HttpPost]
        [Route("GetTeacherDetailsList")]
        public List<TeacherModel> GetTeacherDetailsList([FromBody] TeacherModel teacherModel)
        {
            return teacherModel.GetTeacherDetailsList();

        }

        [HttpPost]
        [Route("GetTeacherName")]
        public List<TeacherModel> GetTeacherName()
        {
            TeacherModel model = new TeacherModel();
            return model.GetTeacherName();

        }

        [HttpPost]
        [Route("GetAllTeacherDetailsList")]
        public List<TeacherModel> GetAllTeacherDetailsList()
        {
            TeacherModel listTeacherDetails = new TeacherModel();
            return listTeacherDetails.GetAllTeacherDetailsList();
        }

        [HttpPost]
        [Route("AddHomeworkDetails")]
        public string AddHomeworkDetails([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.AddHomeworkDetails();
        }

        [HttpPost]
        [Route("SubmitHomework")]
        public string SubmitHomework([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.SubmitHomework();
        }


        [HttpPost]
        [Route("GetHomeworkDetails")]
        public List<HomeworkDetailsModel> GetHomeworkDetails([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.GetHomeworkDetails();
        }
        [HttpPost]
        [Route("GetHomeworkDetailsList")]
        public List<HomeworkDetailsModel> GetHomeworkDetailsList()
        {
            HomeworkDetailsModel homeworkDetails = new HomeworkDetailsModel();
            return homeworkDetails.GetHomeworkDetailsList();
        }



        [HttpPost]
        [Route("HomeworkDetailsListForEdit")]
        public HomeworkDetailsModel HomeworkDetailsListForEdit([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.HomeworkDetailsListForEdit();
        }


        [HttpPost]
        [Route("UpdateHomeworkAfterEdit")]
        public string UpdateHomeworkAfterEdit([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.UpdateHomeworkAfterEdit();
        }


        [HttpPost]
        [Route("DeleteHomeworkDetails")]
        public string DeleteHomeworkDetails([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.DeleteHomeworkDetails();
        }

        [HttpPost]
        [Route("GetViewHomeWorkList")]
        public List<HomeworkModel> GetViewHomeWorkList([FromBody] HomeworkModel homeworkModel)
        {

            return homeworkModel.GetViewHomeWorkList();
        }

        [HttpPost]
            [Route("GetDateForLegend")]
        public HomeworkModel GetDateForLegend([FromBody] HomeworkModel homeworkModel)
        {
            return homeworkModel.GetDateForLegend();
        }


        [HttpPost]
        [Route("AddClassDetails")]
        public string AddClassDetails([FromBody] ClassModel classModel)
        {
            return classModel.AddClassDetails();
        }

        [HttpPost]
        [Route("AddPhotoAlbum")]
        public string AddPhotoAlbum([FromBody] PhotoAlbumModel photoAlbumModel)
        {
            return photoAlbumModel.AddPhotoAlbum();
        }

        [HttpPost]
        [Route("GetYearDropDownForAlbumList")]
        public List<PhotoAlbumModel> GetYearDropDownForAlbumList()
        {
            PhotoAlbumModel photoModel = new PhotoAlbumModel();
            return photoModel.GetYearDropDownForAlbumList();
        }

        [HttpPost]
        [Route("GetMonthDropDownForAlbumList")]
        public List<PhotoAlbumModel> GetMonthDropDownForAlbumList()
        {
            PhotoAlbumModel photoModel = new PhotoAlbumModel();
            return photoModel.GetMonthDropDownForAlbumList();
        }

        [HttpPost]
        [Route("GetAlbumNameList")]
        public List<PhotoAlbumModel> GetAlbumNameList([FromBody] PhotoAlbumModel photoAlbumModel)
        {
            return photoAlbumModel.GetAlbumNameList();

        }

        [HttpPost]
        [Route("DeletePhotoAlbum")]
        public string DeletePhotoAlbum([FromBody] PhotoAlbumModel photoAlbumModel)
        {
            return photoAlbumModel.DeletePhotoAlbum();
        }

        [HttpPost]
        [Route("UserLogin")]
        public UserLoginModel UserLogin([FromBody] UserLoginModel userLoginModel)
        {

            return userLoginModel.UserLogin();
        }


        [HttpPost]
        [Route("ForgotPassword")]
        public UserLoginModel ForgotPassword([FromBody] UserLoginModel userLoginModel)
        {
            return userLoginModel.ForgotPassword();
        }


        [HttpPost]
        [Route("GetClassNameList")]
        public List<ClassModel> GetClassNameList()
        {
            ClassModel classModel = new ClassModel();
            return classModel.GetClassNameList();
        }

        [HttpPost]
        [Route("GetSubjectListDropDown")]
        public List<SubjectModel> GetSubjectListDropDown()
        {
            SubjectModel subjectModel = new SubjectModel();
            return subjectModel.GetSubjectListDropDown();
        }
    }

}