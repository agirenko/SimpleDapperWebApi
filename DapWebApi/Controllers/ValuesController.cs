using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using System.Configuration;
using System.Data;
using DapWebApi.Models;


namespace DapWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        // GET api/GetCountryBrands
        public IEnumerable<CountryBrand> GetCountryBrands(int countryId)
        {
            return DapModels.GetCountryBrandsFromDb(countryId);
        }

        [HttpGet]
        public IEnumerable<dynamic> GetCountries()
        {
            return DapModels.GetCountriesFromDb();
        }
    }
}
