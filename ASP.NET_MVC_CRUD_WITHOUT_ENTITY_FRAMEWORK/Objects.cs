using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ASP.NET_MVC_CRUD_WITHOUT_ENTITY_FRAMEWORK
{
    public class Objects
    {
        public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        public static SqlCommand cmd;
        public static SqlDataReader dr;

        public static SqlDataAdapter da;
        public static DataTable dt;
        public static DataSet ds;
    }
}