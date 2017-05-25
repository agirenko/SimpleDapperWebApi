using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using Dapper;

namespace DapWebApi.Models
{

    public class CountryBrand
    {
        public int CountryBrandID { get; set; }
        public string BrandName { get; set; }
    }

    public class DapModels
    {
        static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["gmAggregatorConnectionString"]
            .ConnectionString;

        public static IEnumerable<CountryBrand> GetCountryBrandsFromDb(int countryId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var resultList = conn.Query<CountryBrand>("[dbo].[spGetCountryBrands]", new {countryId}, commandType: CommandType.StoredProcedure);
                return resultList;
            }
        }

        public static IEnumerable<dynamic> GetCountriesFromDb()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var resultList = conn.Query<dynamic>("SELECT * FROM Country", commandType: CommandType.Text);
                return resultList;
            }
        }

    }
}