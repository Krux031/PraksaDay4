using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;
using CityModel;

namespace CityRepositoryCommon
{
    public interface ICityRepository
    {
        City GetCityRep(int id);

        List<City> GetAllCityRep();

        bool DeleteresidentRep(int id);

        bool PostResidentRep(Residents res, int id);
    }
}
