using StudentBAL.Interface;
using StudentDAL.Interface;
using StudentDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentBAL.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private IStudentService _studentService;
        public StudentRepository(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public List<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }
        public void SaveStudents(Student std)
        {
            _studentService.SaveStudents(std);
        }

        public void UpdateStudents(Student std)
        {
            _studentService.UpdateStudents(std);
        }

        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
