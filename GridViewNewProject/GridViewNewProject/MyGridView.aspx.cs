using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using static GridViewNewProject.MyJSON;

namespace GridViewNewProject
{
    public partial class MyGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        public void BindGrid()
        {
            var json = File.ReadAllText(Server.MapPath("~/comboboxdata.json"));
            // Deserialize JSON into the Root object
            Root root = JsonConvert.DeserializeObject<Root>(json);

            //Here We can Add DropDownList
            //start Here
            //End Here

            //Binding Starts From Here Main Bindings
            List < Mxd > mxds= root.source.mxds;




        }
        public string GetColorsofImage()
        {
            return "";
        }
    }
}