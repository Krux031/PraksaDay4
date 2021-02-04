using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;
using CityRepositoryCommon;
using CityModel;

namespace CityServiceCommon
{
    public interface ICityService
    {
        City GetCity(int id);

        List<City> GetAllCity();

        bool DeleteResident(int id);

        bool PostResident(Residents res, int id);
    }

}
