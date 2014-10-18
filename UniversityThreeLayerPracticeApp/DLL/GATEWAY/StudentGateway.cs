using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityThreeLayerPracticeApp.DLL.DAO;

namespace UniversityThreeLayerPracticeApp.DLL.GATEWAY
{
    class StudentGateway
    {
        private SqlConnection connection;

        public StudentGateway()
        {
            string conn = @"SERVER = .\sqlexpress; database = AbcUniversity; integrated security = true";
            connection = new SqlConnection();
            connection.ConnectionString = conn;

        }

        public string Save(Student aStudent)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Student VALUES ('{0}', '{1}', '{2}')",aStudent.Name, aStudent.Email,aStudent.Address);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();

            if (affectedRows > 0)
            {
                return "Insert database in successfull";
            }
            else
            {
                return "Something wrong";
            }
        }

        public bool HasThisEmailValid(string email)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Student WHERE Email = '{0}'",email);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            if (aReader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
