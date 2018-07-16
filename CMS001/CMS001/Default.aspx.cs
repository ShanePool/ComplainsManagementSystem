using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BizDBproj;
using PropertyProj;
using Label = System.Web.UI.WebControls.Label;


namespace CMS001
{
    public partial class _Default : Page
    {
        private string connectionString()
        {
            return WebConfigurationManager.ConnectionStrings["SNPSysContext"].ConnectionString;

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGrid();
            DropDownBind_Cat();
            DropDownBind_Stat();
            

            this.btnEdit.Enabled = false;
            this.btnSubmit.Enabled = true;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DetailsBizDB detailsBizDb = new DetailsBizDB(connectionString());
            DetailsProp detailsProp = new DetailsProp();

            TextBox6.Text = ddlCategory.SelectedItem.Text;


            try
            {
                // propDe.Id = Convert.ToInt32(TextBox9.Text);
                detailsProp.Name = TextBox2.Text.ToString();
                detailsProp.Address = TextBox3.Text.ToString();
                detailsProp.Tele = Convert.ToInt32(TextBox4.Text);

                detailsProp.Description = TextBox5.Text;
                detailsProp.Category = Convert.ToString(ddlCategory.SelectedItem.Text);
                detailsProp.Timestamp = TextBox7.Text;
                detailsProp.Status = Convert.ToString(ddlStatus.SelectedItem.Text);
                //Console.WriteLine(detailsProp.Status);

                ddlCategory.Items.Clear();
                ddlStatus.Items.Clear();
                detailsBizDb.insertDataMeth(detailsProp);
                

            }
            catch (Exception exception)
            {
                
                MessageBox.Show("Enter correct details!");
                
                //Console.WriteLine(exception);
                //throw;
                
            }
            finally
            {

                LoadGrid();
                DropDownBind_Cat();
                DropDownBind_Stat();

                EmptyVals();
                
            }

        }

        public void EmptyVals()
        {
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
            this.TextBox7.Text = "";
            this.TextBox8.Text = "";
            this.TextBox9.Text = "";

        }


        public void LoadGrid()
        {
            DetailsBizDB insDetails = new DetailsBizDB(connectionString());

            //bind data to grid view
            this.Grid_GetDetails.DataSource = insDetails.Getallobjects();
            this.Grid_GetDetails.DataBind();
        }


        //select record
        protected void Grid_GetDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            if (e.CommandName == "SelectRecord")
            {
                hidId.Value = e.CommandArgument.ToString();

                Label lblid = (Label)row.FindControl("lblId");
                TextBox9.Text = lblid.Text.ToString();

                Label lblname = (Label) row.FindControl("lblName");
                TextBox2.Text = lblname.Text.ToString();

                Label lbladdress = (Label)row.FindControl("lblAddress");
                TextBox3.Text = lbladdress.Text.ToString();

                Label lbltelephone = (Label)row.FindControl("lblTelephone");
                TextBox4.Text = lbltelephone.Text.ToString();

                Label lbldescription = (Label)row.FindControl("lblDescription");
                TextBox5.Text = lbldescription.Text.ToString();

                Label lblcategory = (Label)row.FindControl("lblCategory");
                TextBox6.Text = lblcategory.Text.ToString();
                



                Label lbltime = (Label)row.FindControl("lblTime");
                TextBox7.Text = lbltime.Text.ToString();

                Label lblstatus = (Label)row.FindControl("lblName");
                TextBox8.Text = lblstatus.Text.ToString();

                btnSubmit.Enabled = false;
                btnEdit.Enabled = true;


            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EditRecord();

            btnSubmit.Enabled = true;
            btnEdit.Enabled = false;

            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
            this.TextBox7.Text = "";
            this.TextBox8.Text = "";
            this.TextBox9.Text = "";

        }

        public void EditRecord()
        {
            DetailsBizDB detailsBizDb = new DetailsBizDB(connectionString());
            DetailsProp detailsProp = new DetailsProp();

            try
            {
                detailsProp.Id = Convert.ToInt32(this.hidId.Value);
                detailsProp.Name = this.TextBox2.Text.ToString();
                detailsProp.Address = this.TextBox3.Text.ToString();
                detailsProp.Tele = Convert.ToInt32(TextBox4.Text.ToString());
                detailsProp.Description = TextBox5.Text.ToString();
                detailsProp.Category = TextBox6.Text.ToString();
                detailsProp.Timestamp = TextBox7.Text.ToString();
                detailsProp.Status = TextBox8.Text.ToString();

                detailsBizDb.EditRecords(detailsProp);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                LoadGrid();
                
                btnSubmit.Enabled = true;
                btnEdit.Enabled = false;

                this.TextBox2.Text = "";
                this.TextBox3.Text = "";
                this.TextBox4.Text = "";
                this.TextBox5.Text = "";
                this.TextBox6.Text = "";
                this.TextBox7.Text = "";
                this.TextBox8.Text = "";
                this.TextBox9.Text = "";
            }


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            this.LoadGrid();
        }

        public void DeleteRecord()
        {
            DetailsBizDB detailsBizDb = new DetailsBizDB(connectionString());
            detailsBizDb.DeleteRecord(Convert.ToInt32(hidId.Value));

        }

        public void DropDownBind_Cat()
        {
            DetailsBizDB detailsBizDb = new DetailsBizDB(connectionString());

            this.ddlCategory.DataSource = detailsBizDb.GetAllCategoriesProps();
            this.ddlCategory.DataBind();
            this.ddlCategory.Items.Insert(0,"Select..");
        }

        public void DropDownBind_Stat()
        {
            DetailsBizDB detailsBizDb = new DetailsBizDB(connectionString());
            this.ddlStatus.DataSource = detailsBizDb.GetAllStatusPropsProps();
            this.ddlStatus.DataBind();
            this.ddlStatus.Items.Insert(0, "Select..");
        }



    }

}