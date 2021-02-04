using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Data;
using CityRepositoryCommon;
using CityModelCommon;
using CityModel;

namespace CityRepository
{
    public class Repository : ICityRepository
    {
        SqlCommand zahtjev = null;
        SqlTransaction transaction;
        public static SqlConnection konekcija = new SqlConnection(@"Server=tcp:kruninserver.database.windows.net,1433;Initial Catalog=kruninabaza;Persist Security Info=False;User ID=krux031;Password=sifra;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public City GetCityRep(int id)
        {
            zahtjev = new SqlCommand("select * from grad where pbr=@id", konekcija);
            zahtjev.Parameters.AddWithValue("@id", id);
            City grad = new City();
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }

                SqlDataReader reader = zahtjev.ExecuteReader();

                while (reader.Read())
                {
                    grad.Id = reader.GetInt32(0);
                    grad.Naziv = reader.GetString(1);
                }

            }
            catch (SqlException Ex)
            {
                transaction.Rollback();
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            return grad;
        }


        public List<City> GetAllCityRep()
        {
            zahtjev = new SqlCommand("select * from grad", konekcija);
            List<City> gradovi = new List<City>();
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }

                SqlDataReader reader = zahtjev.ExecuteReader();

                while (reader.Read())
                {
                    City grad = new City();
                    grad.Id = reader.GetInt32(0);
                    grad.Naziv = reader.GetString(1);
                    gradovi.Add(grad);
                }

            }
            catch (SqlException Ex)
            {
                transaction.Rollback();
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            return gradovi;
        }

        public bool DeleteresidentRep(int id)
        {
            zahtjev = new SqlCommand("delete from stanovnici where jmbg=@id", konekcija);
            zahtjev.Parameters.AddWithValue("@id", id);
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }

                if(zahtjev.ExecuteNonQuery()==0)
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                transaction.Rollback();
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            return true;
        }

        public bool PostResidentRep(Residents res, int id)
        {
            zahtjev = new SqlCommand("insert into stanovnici values (@id, @ime, @prezime, @pbr, @spol)", konekcija);
            zahtjev.Parameters.AddWithValue("@id", id);
            zahtjev.Parameters.AddWithValue("@ime", res.Ime);
            zahtjev.Parameters.AddWithValue("@prezime", res.Prezime);
            zahtjev.Parameters.AddWithValue("@pbr", res.Pbr);
            zahtjev.Parameters.AddWithValue("@spol", res.Spol);
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }
                zahtjev.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                return false;
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
            
            return true;
        }
    }
}
