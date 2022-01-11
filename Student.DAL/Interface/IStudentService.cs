using System;
using System.Collections.Generic;
using StudentDAL.Models;

namespace StudentDAL.Interface
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        void SaveStudents(Student std);
        void UpdateStudents(Student std);
        void DeleteStudent(int id);
    }
}
