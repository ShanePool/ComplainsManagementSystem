using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyProj;

namespace BizDBproj
{
    public class DetailsBizDB
    {

        private string ConnectionString;



        public DetailsBizDB(string connString)
        {
            this.ConnectionString = connString;

        }


        //select records
        public List<DetailsProp> Getallobjects()
        {
            List<DetailsProp> insProp = new List<DetailsProp>();

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("cms_selectallrecords", con);
                comm.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = comm.ExecuteReader();


                //reading line by line
                while (rdr.Read())
                {
                    DetailsProp dr = new DetailsProp();

                    dr.Id = Convert.ToInt32(rdr["ComplaintID"]);
                    
                    dr.Name = rdr["C_Name"].ToString();
                     
                    dr.Address = rdr["C_Address"].ToString();
                    dr.Tele = Convert.ToInt32(rdr["C_Tele"]);
                    dr.Description = rdr["C_Description"].ToString();
                    dr.Category = rdr["C_Category"].ToString();
                    dr.Timestamp = rdr["C_Time"].ToString();
                    dr.Status = rdr["C_Status"].ToString();
                    
                    insProp.Add(dr);
                }

            }


            return insProp;
        }


        //get category list
        public List<CategoriesProp> GetAllCategoriesProps()
        {
            List<CategoriesProp> CatProp = new List<CategoriesProp>();

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("cms_GetCatList", con);
                comm.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = comm.ExecuteReader();


                //reading line by line
                while (rdr.Read())
                {
                    CategoriesProp dr = new CategoriesProp();

                    dr.CatId = Convert.ToInt32(rdr["Category_Id"]);
                    
                    dr.CatName = rdr["Category_Name"].ToString();
                     
                    
                    
                    CatProp.Add(dr);

                }

            }


            return CatProp;
        }

        //get Status from db
        public List<StatusProp> GetAllStatusPropsProps()
        {
            List<StatusProp> StatProp = new List<StatusProp>();

            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("cms_GetStatusList", con);
                comm.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = comm.ExecuteReader();


                //reading line by line
                while (rdr.Read())
                {
                    StatusProp dr = new StatusProp();

                    dr.StatId = Convert.ToInt32(rdr["StatId"]);

                    dr.StatName = rdr["StatName"].ToString();



                    StatProp.Add(dr);

                }

            }


            return StatProp;
        }

        //insert to table
        public void insertDataMeth(DetailsProp detailsProp)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand comm = new  SqlCommand("cms_insertTotable", con);
                comm.CommandType = CommandType.StoredProcedure;

                /*
                 SqlParameter cid = new SqlParameter();
                cid.ParameterName = "@c_id";
                cid.Value = Convert.ToInt32(detailsProp.Id);
                comm.Parameters.Add(cid);
                */
                
                 
                SqlParameter cname = new SqlParameter();
                cname.ParameterName = "@c_name";
                cname.Value = detailsProp.Name.ToString();
                comm.Parameters.Add(cname);

                
                SqlParameter caddress = new SqlParameter();
                caddress.ParameterName = "@c_Address";
                caddress.Value = detailsProp.Address.ToString();
                comm.Parameters.Add(caddress);

                SqlParameter ctele = new SqlParameter();
                ctele.ParameterName = "@c_Tele";
                ctele.Value = Convert.ToInt32(detailsProp.Tele);
                comm.Parameters.Add(ctele);
                
                SqlParameter cdescription = new SqlParameter();
                cdescription.ParameterName = "@c_Description";
                cdescription.Value = detailsProp.Description.ToString();
                comm.Parameters.Add(cdescription);

                SqlParameter ccategory = new SqlParameter();
                ccategory.ParameterName = "@c_Category";
                ccategory.Value = detailsProp.Category.ToString();
                comm.Parameters.Add(ccategory);

                SqlParameter ctime = new SqlParameter();
                ctime.ParameterName = "@c_Time";
                ctime.Value = DateTime.Now.ToShortTimeString();
                comm.Parameters.Add(ctime);

                SqlParameter cstatus = new SqlParameter();
                cstatus.ParameterName = "@c_Status";
                cstatus.Value = detailsProp.Status.ToString();
                comm.Parameters.Add(cstatus);
                

                con.Open();
                comm.ExecuteNonQuery();

                



            }

        }

        public void EditRecords(DetailsProp detailsProp)
        {
            using (SqlConnection con = new SqlConnection((ConnectionString)))
            {
                SqlCommand cmd = new SqlCommand("cms_EditProcedure",con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter did = new SqlParameter();
                did.ParameterName = "@c_id";
                did.Value = Convert.ToInt32(detailsProp.Id);
                cmd.Parameters.Add(did);

                SqlParameter dname = new SqlParameter();
                dname.ParameterName = "@c_name";
                dname.Value = detailsProp.Name.ToString();
                cmd.Parameters.Add(dname);

                SqlParameter daddress = new SqlParameter();
                daddress.ParameterName = "@c_Address";
                daddress.Value = detailsProp.Address.ToString();
                cmd.Parameters.Add(daddress);

                SqlParameter dtelephone = new SqlParameter();
                dtelephone.ParameterName = "@c_Tele";
                dtelephone.Value = detailsProp.Tele.ToString();
                cmd.Parameters.Add(dtelephone);

                SqlParameter ddescription = new SqlParameter();
                ddescription.ParameterName = "@c_Description";
                ddescription.Value = (detailsProp.Description).ToString();
                cmd.Parameters.Add(ddescription);

                SqlParameter dcategory = new SqlParameter();
                dcategory.ParameterName = "@c_Category";
                dcategory.Value = (detailsProp.Category).ToString();
                cmd.Parameters.Add(dcategory);

                SqlParameter dtime = new SqlParameter();
                dtime.ParameterName = "@c_Time";
                dtime.Value = (detailsProp.Timestamp).ToString();
                cmd.Parameters.Add(dtime);

                SqlParameter dstatus = new SqlParameter();
                dstatus.ParameterName = "@c_Status";
                dstatus.Value = (detailsProp.Status).ToString();
                cmd.Parameters.Add(dstatus);
                
                con.Open();
                cmd.ExecuteNonQuery();



            }
           
        }


        public void DeleteRecord(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("cms_DeleteRecord", con );
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idParameter = new SqlParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = Convert.ToInt32(id);
                cmd.Parameters.Add(idParameter);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            

        }

    }
}
