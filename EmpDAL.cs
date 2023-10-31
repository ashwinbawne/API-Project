using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class EmpDAL
    {
        public SqlConnection con = new SqlConnection("Data Source=192.168.25.25; Initial Catalog=ENFINLiveTestDB; Persist Security Info=True;User ID=Dev_Test_CH;Password=RT78^yykh987");

        public object FormImageFile { get; internal set; }
        public object FormPdfFile { get; internal set; }

        internal static IEnumerable<object> GetCities()
        {
            throw new NotImplementedException();
        }

        public List<Emp> GetDataList()
        {
            List<Emp> lst = new List<Emp>();

            SqlCommand cmd = new SqlCommand("sp_MVC1", con);

            cmd.CommandType = CommandType.StoredProcedure;


            DataTable dt = new DataTable();



            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);



            Emp e = new Emp();

            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new Emp());

                e.Firstname = Convert.ToString(dr["strfirst_name"]);
                e.Lastname = Convert.ToString(dr["strlast_name"]);
                e.Dateofbirth = dr["dtedob"].ToString();
                e.Hobbies = Convert.ToString(dr["strhobbies"]);
                e.Gender = Convert.ToString(dr["strgender"]);
                e.State = Convert.ToString(dr["strstate"]);
                e.City = Convert.ToString(dr["strcity"]);
                e.UploadImage = Convert.ToString(dr["uploadimage"]);
                e.UploadPdf = Convert.ToString(dr["uploadpdf"]);

                lst.Add(e);



            }


            return lst;

        }
    }

}





