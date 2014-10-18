using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityThreeLayerPracticeApp.DLL.DAO;
using UniversityThreeLayerPracticeApp.DLL.GATEWAY;

namespace UniversityThreeLayerPracticeApp.BLL
{
    class StudentBLL
    {
        private StudentGateway aStudentGateway;


        public StudentBLL()
        {
            aStudentGateway = new StudentGateway();
        }


        public string Save(Student aStudent)
        {
            if (aStudent.Name == string.Empty || aStudent.Email == string.Empty || aStudent.Address == string.Empty)
            {
                return "Please fill up all field";
            }
            else
            {
                if (!HasThisEmailValid(aStudent.Email))
                {
                    return aStudentGateway.Save(aStudent);
                }
                else
                {
                    return "Email already exists";
                }    
            }
        }


        private bool HasThisEmailValid(string email)
        {
          return  aStudentGateway.HasThisEmailValid(email);
        }

    }
}
