//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Models;
//using Moq;
//using Services;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace Tests
//{
//    public class StudentControllerTest
//    {
//        private readonly Mock<IStudentService> mockService;
//        private readonly StudentControllerTest studentController;

//        public StudentControllerTest(IStudentService @object)
//        {
//            mockService = new Mock<IStudentService>();
//            studentController = new StudentControllerTest(mockService.Object);
//        }

//        [Xunit.Fact]
//        public async void Get_WhenCalled_ReturnsOkResult()
//        {
//            //Arrange
//            var id = 1;
//            mockService.Setup(repo => repo.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(GetMockStudent()));

//            // Act
//            var okResult = await studentController.Get(id);

//            // Assert
//            Assert.IsType<OkObjectResult>(okResult.Result);
//        }

//        [Fact]
//        public async void Get_WhenCalled_ReturnsNotFoundResult()
//        {
//            //Arrange
//            var id = -1;

//            // Act
//            var notFoundResult = await studentController.Get(id);

//            // Assert
//            Assert.IsType<NotFoundResult>(notFoundResult.Result);
//        }

//        private Task Get(int id)
//        {
//            throw new NotImplementedException();
//        }

//        [Fact]
//        public async void GetAll_WhenCalled_ReturnsItems()
//        {
//            //Arrange
//            mockService.Setup(repo => repo.GetAllAsync()).Returns(Task.FromResult(GetMockStudentList()));

//            // Act
//            var okResult = await studentController.GetAll();

//            // Assert
//            var result = okResult.Result as OkObjectResult;
//            var items = Assert.IsType<List<Student>>(result.Value);

//            Assert.True(items.Count > 0);

//        }

//        [Fact]
//        public async void Remove_NotExistingtStudent_ReturnsNotFoundResponse()
//        {
//            // Arrange
//            var notExistingId = -1;
//            mockService.Setup(repo => repo.GetAsync(It.IsAny<int>()));

//            // Act
//            var badResponse = await studentController.Delete(notExistingId);

//            // Assert
//            Assert.IsType<NotFoundResult>(badResponse.Result);
//        }

//        [Fact]
//        public async void Remove_ExistingStudent_ReturnsOkResult()
//        {
//            // Arrange
//            var existingId = 11;
//            mockService.Setup(repo => repo.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(GetMockStudent()));
//            mockService.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(1));

//            // Act
//            var okResponse = await studentController.Delete(existingId);

//            // Assert
//            Assert.IsType<ActionResult<int>>(okResponse);
//        }

//        private static Student GetMockStudent()
//        {
//            return new Student()
//            {
//                Id = 1,
//                Name = "John",
//                Email = "contactus@gmail.com",
//                PhoneNumber = 12345678,
//                Gender = true,
//                SchoolId = 1,
//                SchoolName = "ABC"
//            };
//        }
//        private static IEnumerable<Student> GetMockStudentList()
//        {
//            var studentList = new List<Student>();
//            Student student = new Student
//            {
//                Id = 1,
//                Name = "John",
//                Email = "contactus@gmail.com",
//                PhoneNumber = 12345678,
//                Gender = true,
//                SchoolId = 1,
//                SchoolName = "ABC"
//            };
//            studentList.Add(student);
//            return studentList;
//        }
//    }
//}