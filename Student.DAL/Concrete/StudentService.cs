using StudentDAL.Interface;
using StudentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDAL.Concrete
{
    public class StudentService : IStudentService
    {

        List<Student> IStudentService.GetStudents()
        {
            var context = new SmartContext();
            return context.Students.ToList();
        }
        public void SaveStudents(Student std)
        {
            try
            {
                using (var context = new SmartContext())
                {
                    context.Students.Add(std);
                    context.SaveChanges();
                }

            }
            catch(Exception exc)
            {
                throw;
            }
        }
        public void UpdateStudents(Student std)
        {
            using (var context = new SmartContext())
            {
                context.Update<Student>(std);
                context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = new SmartContext())
            {
                context.Remove<Student>(new Student() { StudentId = id});
                context.SaveChanges();
            }
        }
    }
}
