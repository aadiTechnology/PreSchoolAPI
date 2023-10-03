using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PreSchoolAPI.Models;
using static UserLoginModel;

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
        [HttpPost]
        [Route("GetStudentDetails")]
        public EnquiryModel GetStudentDetails([FromBody] EnquiryModel enquiryModel)
        {
            return enquiryModel.GetStudentDetails();

        }

        [HttpPost]
        [Route("GetEnquiryStudentDetails")]
        public List<EnquiryModel> GetEnquiryStudentDetails()
        {
            EnquiryModel enquiryModel = new EnquiryModel();
            return enquiryModel.GetEnquiryStudentDetails();
        }
        [HttpPost]
        [Route("GetEnquiryStudentDetailsForEdit")]
        public EnquiryModel GetEnquiryStudentDetailsForEdit([FromBody] EnquiryModel enquiryModel)
        {
            return enquiryModel.GetEnquiryStudentDetailsForEdit();
        }
        [HttpPost]
        [Route("EditEnquiryStudentdetails")]
        public EnquiryModel EditEnquiryStudentdetails([FromBody] EnquiryModel enquirymodel)
        {
            return enquirymodel.EditEnquiryStudentdetails();
        }

        [HttpPost]
        [Route("DeleteEnquiryStudentDetails")]
        public string DeleteEnquiryStudentDetails([FromBody] EnquiryModel enquirymodel)
        {
            return enquirymodel.DeleteEnquiryStudentDetails();
        }
        [HttpPost]
        [Route("GetStudentDetailsList")]
        public List<EnquiryModel> GetStudentDetailsList([FromBody] EnquiryModel enquiryModel)
        {
            return enquiryModel.GetStudentDetailsList();
        }

        [HttpPost]
        [Route("DeleteStudentDetails")]
        public string DeleteStudentDetails([FromBody] EnquiryModel enquiryModel)
        {
            return enquiryModel.DeleteStudentDetails();
        }
        //get GetStudentDetails
        //[HttpPost]
        //[Route("GetStudentDetails")]
        //public List<EnquiryModel> GetStudentDetails([FromBody] EnquiryModel enquiryModel)
        //{
        //    return enquiryModel.GetStudentDetails();

        //}

        [HttpPost]
        [Route("AddStudentFollowUp")]
        public string AddStudentFollowUp([FromBody] FollowUpModel followUpModel)
        {
            return followUpModel.AddStudentFollowUp();
        }

        [HttpPost]
        [Route("GetStudentDetailsForFollowUp")]
        public List<FollowUpModel> GetStudentDetailsForFollowUp([FromBody] FollowUpModel followUpModel)
        {
            return followUpModel.GetStudentDetailsForFollowUp();
        }

        [HttpPost]
        [Route("GetStudentFollowUpList")]
        public List<FollowUpModel> GetStudentFollowUpList()
        {
            FollowUpModel followUpModel = new FollowUpModel();
            return followUpModel.GetStudentFollowUpList();
        }


        [HttpPost]
        [Route("AdmissionForm")]
        public string AdmissionForm([FromBody] AdmissionDetails admissionDetails)
        {
            return admissionDetails.AdmissionForm();
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
        [Route("GetDatewiseHomeworkDetails")]
        public HomeworkDetailsModel GetDatewiseHomeworkDetails([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.GetDatewiseHomeworkDetails();
        }

        [HttpPost]
        [Route("GetHomeworkDetailsList")]
        public List<HomeworkDetailsModel> GetHomeworkDetailsList([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.GetHomeworkDetailsList();
        }



        [HttpPost]
        [Route("HomeworkDetailsListForEdit")]
        public HomeworkDetailsModel HomeworkDetailsListForEdit([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.HomeworkDetailsListForEdit();
        }

        [HttpPost]
        [Route("GetDateForLegend")]
        public List<HomeworkDetailsModel> GetDateForLegend([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.GetDateForLegend();
        }

        [HttpPost]
        [Route("GetViewHomeWorkList")]
        public List<HomeworkDetailsModel> GetViewHomeWorkList([FromBody] HomeworkDetailsModel homeworkDetails)
        {

            return homeworkDetails.GetViewHomeWorkList();
        }

        [HttpPost]
        [Route("DeleteHomeworkDetails")]
        public string DeleteHomeworkDetails([FromBody] HomeworkDetailsModel homeworkDetails)
        {
            return homeworkDetails.DeleteHomeworkDetails();
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
        [Route("GetAllAlbumNameList")]
        public List<PhotoAlbumModel> GetAllAlbumNameList([FromBody] PhotoAlbumModel photoAlbumModel)
        {
            PhotoAlbumModel photoModel = new PhotoAlbumModel();
            return photoModel.GetAllAlbumNameList();
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
        [Route("AddUserLoginInfo")]
        public string AddUserLoginInfo([FromBody] UserLoginModel userLoginModel)
        {

            return userLoginModel.AddUserLoginInfo();
        }


        [HttpPost]
        [Route("ForgotPassword")]
        public UserLoginModel ForgotPassword([FromBody] UserLoginModel userLoginModel)
        {
            return userLoginModel.ForgotPassword();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public string ChangePassword([FromBody] UserLoginModel userLoginModel)
        {
            return userLoginModel.ChangePassword();
        }


        [HttpPost]
        [Route("GetClassNameList")]
        public List<ClassModel> GetClassNameList()
        {
            ClassModel classModel = new ClassModel();
            return classModel.GetClassNameList();
        }

        [HttpPost]
        [Route("GetClassDivisionList")]
        public List<ClassModel> GetClassDivisionList([FromBody] ClassModel classModel)
        {
            return classModel.GetClassDivisionList(classModel);
        }

        [HttpPost]
        [Route("AssignClassToTeacher")]
        public string AssignClassToTeacher([FromBody] ClassModel classModel)
        {

            return classModel.AssignClassToTeacher();
        }


        [HttpPost]
        [Route("GetSubjectNameDropdown")]
        public List<SubjectModel> GetSubjectNameDropdown()
        {
            SubjectModel classModel = new SubjectModel();
            return classModel.GetSubjectNameDropdown();
        }

        [HttpPost]
        [Route("EditStudentEnquirydetails")]
        public FollowUpModel EditStudentEnquirydetails([FromBody] FollowUpModel followmodel)
        {
            return followmodel.EditStudentEnquirydetails();
        }


        [HttpPost]
        [Route("DeleteFollowUpList")]
        public string DeleteFollowUpList([FromBody] FollowUpModel followmodel)
        {
            return followmodel.DeleteFollowUpList();
        }


        [HttpPost]
        [Route("GetUsersForLogIn")]
        public List<UserLoginModel> GetUsersForLogIn([FromBody] UserLoginModel loginmodel)
        {
            return loginmodel.GetUsersForLogIn();
        }

        [HttpPost]
        [Route("GetLogInByUserId")]
        public UserLoginModel GetLogInByUserId([FromBody] UserLoginModel loginmodel)
        {
            return loginmodel.GetLogInByUserId();
        }
    }

}

