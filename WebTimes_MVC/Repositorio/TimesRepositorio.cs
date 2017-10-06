using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebTimes_MVC.Models;

namespace WebTimes_MVC.Repositorio
{
    public class TimesRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            _con = new SqlConnection(constr);
        }

        public bool AdicionarTime(Times timeObj)
        {
            Connection();

            int linhasAfetadas;

            using (SqlCommand cmd = new SqlCommand("InserirTime", _con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Time", timeObj.Time);
                cmd.Parameters.AddWithValue("@Estado", timeObj.Estado);
                cmd.Parameters.AddWithValue("@Cores", timeObj.Cores);

                _con.Open();

                linhasAfetadas = cmd.ExecuteNonQuery();
            }

            _con.Close();

            return linhasAfetadas >= 1;
        }


        public List<Times> ObterTimes()
        {
            Connection();

            List<Times> timesList = new List<Times>();

            using (SqlCommand cmd = new SqlCommand("ObterTimes", _con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Times time = new Times();
                    time.TimeId = Convert.ToInt32(reader["TimeId"]);
                    time.Time = Convert.ToString(reader["Time"]);
                    time.Estado = Convert.ToString(reader["Estado"]);
                    time.Cores = Convert.ToString(reader["Cores"]);

                    timesList.Add(time);
                }

                _con.Close();

                return timesList;
            }
        }

        public bool AtualizarTime(Times timeObj)
        {
            Connection();

            int linhasAfetadas;

            using (SqlCommand cmd = new SqlCommand("AtualizarTime", _con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TimeId", timeObj.TimeId);
                cmd.Parameters.AddWithValue("@Time", timeObj.Time);
                cmd.Parameters.AddWithValue("@Estado", timeObj.Estado);
                cmd.Parameters.AddWithValue("@Cores", timeObj.Cores);

                _con.Open();

                linhasAfetadas = cmd.ExecuteNonQuery();
            }

            _con.Close();

            return linhasAfetadas >= 1;
        }

        public bool ExcluirTime(int id)
        {
            Connection();

            int linhasAfetadas;

            using (SqlCommand cmd = new SqlCommand("ExcluirTimePorId", _con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TimeId", id);

                _con.Open();

                linhasAfetadas = cmd.ExecuteNonQuery();
            }

            _con.Close();

            if (linhasAfetadas >= 1)
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