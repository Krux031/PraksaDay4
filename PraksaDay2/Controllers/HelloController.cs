using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using CityServiceCommon;
using CityModelCommon;
using CityModel;
using CityService;

namespace PraksaDay2.Controllers
{
    [RoutePrefix("api/Hello")]
    public class HelloController : ApiController
    {
        protected ICityService Service = new Service();

        public City rezultat = new City();
        public List<City> rezultati = new List<City>();

        [HttpGet]
        [Route("Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            rezultat = Service.GetCity(id);
            if (rezultat != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, rezultat);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No content");
            }
            
        }

        [HttpGet]
        [Route("Get/All")]
        public HttpResponseMessage GetAll()
        {
            rezultati = Service.GetAllCity();
            if (rezultati != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, rezultati);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No content");
            }

        }

        [HttpDelete]
        [Route("Delete/Resident/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (Service.DeleteResident(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }
        }

        [HttpPost]
        [Route("Post/Resident/{id}")]
        public HttpResponseMessage Post([FromBody] Residents res, int id)
        {
            if(Service.PostResident(res,id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }           
        }













            //public static List<string> popis = new List<string>() { "kruh", "mlijeko" , "jaja", "riza", "banane", "sok"};

            //SqlCommand dohvati = null;
            //SqlTransaction transaction;
            //public static SqlConnection konekcija = new SqlConnection(@"Server=tcp:kruninserver.database.windows.net,1433;Initial Catalog=kruninabaza;Persist Security Info=False;User ID=krux031;Password=sifra;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            //public HttpResponseMessage Get()
            //{
            //    dohvati = new SqlCommand("select * from stanovnici", konekcija);
            //    string tekst = "";

            //    try
            //    {
            //        if (konekcija.State == ConnectionState.Closed) 
            //        {
            //            konekcija.Open();
            //        }
            //        //konekcija.BeginTransaction();
            //        SqlDataReader reader = dohvati.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            tekst = tekst + "<br />" + reader.GetString(1)+ " " + reader.GetString(2) + " " + reader.GetString(4);
            //        }

            //        //transaction.Commit();
            //        return Request.CreateResponse(HttpStatusCode.OK, tekst);
            //    }
            //    catch (SqlException Ex)
            //    {
            //        transaction.Rollback();
            //        return Request.CreateResponse(HttpStatusCode.NoContent, "No Content");
            //    } 
            //    finally
            //    {
            //        if (konekcija.State == ConnectionState.Open)
            //            konekcija.Close();
            //    }

            //    //return popis;
            //}
            //public HttpResponseMessage Post([FromBody]string item)
            //{
            //    popis.Add(item);
            //    return Request.CreateResponse(HttpStatusCode.OK, "OK");
            //}
            //public HttpResponseMessage Put ([FromBody] string item)
            //{
            //    if(popis.Contains(item) == false)
            //    {
            //        popis.Add(item);
            //        return Request.CreateResponse(HttpStatusCode.Created, "Created");
            //    }
            //    else
            //    {
            //        return Request.CreateResponse(HttpStatusCode.NoContent, "No Content");
            //    }

            //}
            //public HttpResponseMessage Delete([FromBody] string item)
            //{
            //    if (popis.Contains(item) == true)
            //    {
            //        popis.Remove(item);
            //        return Request.CreateResponse(HttpStatusCode.OK, "OK");
            //    }
            //    else
            //    {
            //        return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            //    }
            //}

        }
}
