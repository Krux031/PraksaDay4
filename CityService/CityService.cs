using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityServiceCommon;
using CityModelCommon;
using CityRepositoryCommon;
using CityModel;
using CityRepository;

namespace CityService
{
    public class Service : ICityService
    {
        protected ICityRepository Repository = new Repository();

        public City GetCity(int id)
        {
            return Repository.GetCityRep(id);
        }

        public List<City> GetAllCity()
        {
            return Repository.GetAllCityRep();
        }

        public bool DeleteResident(int id)
        {
            return Repository.DeleteresidentRep(id);
        }

        public bool PostResident(Residents res, int id)
        {
            return Repository.PostResidentRep(res, id);
        }
    }
}
