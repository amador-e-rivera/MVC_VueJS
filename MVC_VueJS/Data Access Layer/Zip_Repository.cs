using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_VueJS.Models;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace MVC_VueJS.Data_Access_Layer
{
    public class Zip_Repository : IRepository<Zip, int>
    {
        public bool Create(Zip model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Zip> GetAll()
        {
            IList<Zip> modelList = new List<Zip>();
            string sqlQuery = "SELECT * FROM ZipCodes";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnString"].ToString()))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = conn.CreateCommand();
                    DataSet ds = new DataSet();

                    cmd.CommandText = sqlQuery;
                    da.SelectCommand = cmd;

                    conn.Open();
                    da.Fill(ds);
                    conn.Close();

                    modelList = MapDataSetToModel(ds);
                }
            }
            catch (Exception)
            {
            }

            return modelList;
        }

        public Zip GetByID(int id)
        {
            Zip model = new Zip();
            string sqlQuery = "SELECT * FROM ZipCodes WHERE ZipCode = " +  id;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TestConnString"].ToString()))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd = conn.CreateCommand();
                    DataSet ds = new DataSet();

                    cmd.CommandText = sqlQuery;
                    da.SelectCommand = cmd;

                    conn.Open();
                    da.Fill(ds);
                    conn.Close();

                    model = MapDataSetToModel(ds).FirstOrDefault();
                }
            }
            catch (Exception)
            {
            }

            return model;
        }

        public bool Update(Zip model)
        {
            throw new NotImplementedException();
        }

        private IList<Zip> MapDataSetToModel(DataSet ds)
        {
            List<Zip> modelList = new List<Zip>();
            
            if(!IsDataSetEmpty(ds))
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    Zip model = MapDataRowToModel(row);
                    modelList.Add(model);
                }
            }

            return modelList;
        }

        private Zip MapDataRowToModel(DataRow row)
        {
            Zip model = new Zip();

            model.ZipCode = Convert.ToInt32(row["ZipCode"].ToString());
            model.County = row["County"].ToString();
            model.Latitude = Convert.ToDouble(row["Latitude"].ToString());
            model.Longitude = Convert.ToDouble(row["Longitude"].ToString());
            model.PrimaryCity = row["PrimaryCity"].ToString();
            model.State = row["State"].ToString();
            model.Type = row["Type"].ToString();

            return model;
        }

        private bool IsDataSetEmpty(DataSet ds)
        {
            bool result = false;

            if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }

            return result;
        }
    }
}