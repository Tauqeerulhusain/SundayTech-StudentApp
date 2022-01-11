using System;
using System.Collections.Generic;
using System.Text;
using StudentDAL.Models;


namespace StudentBAL.Interface
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        void SaveStudents(Student std);
        void UpdateStudents(Student std);
        void DeleteStudent(int id);

    }
}
