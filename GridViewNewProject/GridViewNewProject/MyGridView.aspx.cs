using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
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
            var json = File.ReadAllText(Server.MapPath("~/myjsondata.json"));
            // Deserialize JSON into the Root object
            Root root = JsonConvert.DeserializeObject<Root>(json);

            //Here We can Add DropDownList
            //start Here


            foreach (var prop in typeof(Environments).GetProperties())
            {
                ddlenviornment.Items.Add(new ListItem(prop.Name, prop.Name));
            }
            //End Here

            //Binding Starts From Here Main Bindings
            List<Mxd> mxds = root.source.mxds;

            List<MxdBinding> binding = new List<MxdBinding>();
            foreach (var item in mxds)
            {
                MxdBinding mx=new MxdBinding();
                mx.name = item.name;
                mx.updatesharing = item.updatesharing;
                mx.deploy= item.deploy;
                mx.updateproperties=item.updateproperties;
                mx.updatecaching=item.updatecaching;
                string tags = string.Empty;
                foreach (var item1 in item.tags)
                {
                    if (tags.Equals(string.Empty))
                    {
                        tags = tags + item1;
                    }
                    else
                    {
                        tags = tags + ',' + item1;
                    }
                }
                mx.tags = tags;
                binding.Add(mx);
            }
            GridView1.DataSource = binding;
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                var rowData = mxds[row.RowIndex];
                var deployProperty = row.FindControl("deploy") as CheckBox;
                var updatepropProperty = row.FindControl("updateproperties") as CheckBox;
                var updateshareProperty = row.FindControl("updatesharing") as CheckBox;
                var updateCacheProperty = row.FindControl("updatecaching") as CheckBox;

                if (deployProperty != null)
                {
                    deployProperty.Checked = (bool)rowData.deploy;
                }
                if (updatepropProperty != null)
                {
                    updatepropProperty.Checked = (bool)rowData.updateproperties;
                }
                if (updateshareProperty != null)
                {
                    updateshareProperty.Checked = (bool)rowData.updatesharing;
                }
                if (updateCacheProperty != null)
                {
                    updateCacheProperty.Checked = (bool)rowData.updatecaching;
                }
                string colorName = GetColorsofImage(rowData.name, rowData.deploy, rowData.updateproperties, rowData.updatesharing, rowData.updatecaching, rowData.tags);
                if (colorName == "red")
                {
                    var imgsrc = row.FindControl("redimg") as Image;
                    if (imgsrc != null)
                    {
                        imgsrc.Visible = true;
                        
                    }
                }
                else if (colorName == "green")
                {
                    var imgsrc = row.FindControl("greenimg") as Image;
                    if (imgsrc != null)
                    {
                        imgsrc.Visible = true;
                    }
                }
                else if (colorName == "yellow")
                {
                    var imgsrc = row.FindControl("yellowimg") as Image;
                    if (imgsrc != null)
                    {
                        imgsrc.Visible = true;
                    }
                }

            }
        }
        public string GetColorsofImage(string name, bool deploy, bool updateproperties, bool updatesharing, bool updatecaching, List<string> tags)
        {
            //You can Code Here 
            return "red";
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
            GridViewRow row = GridView1.Rows[e.NewEditIndex];

            var json = File.ReadAllText(Server.MapPath("~/myjsondata.json"));
            // Deserialize JSON into the Root object
            Root root = JsonConvert.DeserializeObject<Root>(json);
            var rowData = root.source.mxds[e.NewEditIndex];
            CheckBox deployProperty = row.FindControl("deployPropertyEdit") as CheckBox;
            CheckBox updatepropProperty = row.FindControl("updatePropertyEdit") as CheckBox;
            CheckBox updateshareProperty = row.FindControl("updatesharingPropertyEdit") as CheckBox;
            CheckBox updateCacheProperty = row.FindControl("cachingPropertyEdit") as CheckBox;

            if (deployProperty != null)
            {
                deployProperty.Checked = rowData.deploy;
            }
            if (updatepropProperty != null)
            {
                updatepropProperty.Checked = rowData.updateproperties;
            }
            if (updateshareProperty != null)
            {
                updateshareProperty.Checked = rowData.updatesharing;
            }
            if (updateCacheProperty != null)
            {
                updateCacheProperty.Checked = rowData.updatecaching;
            }



        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            if (row != null)
            {
                CheckBox deployProperty = row.FindControl("deployPropertyEdit") as CheckBox;
                CheckBox updatepropProperty = row.FindControl("updatePropertyEdit") as CheckBox;
                CheckBox updateshareProperty = row.FindControl("updatesharingPropertyEdit") as CheckBox;
                CheckBox updateCacheProperty = row.FindControl("cachingPropertyEdit") as CheckBox;
                bool deploye = false;
                bool updatepropey=false;
                bool updateshre = false;
                bool updatecache = false;
                if (deployProperty != null) {
                    if (deployProperty.Checked)
                    {
                        deploye = true;
                    }
                }
                if (updatepropProperty != null)
                {
                    if (updatepropProperty.Checked)
                    {
                        updatepropey = true;
                    }
                }
                if (updateshareProperty != null)
                {
                    if (updateshareProperty.Checked)
                    {
                        updateshre = true;
                    }
                }
                if (updateCacheProperty != null)
                {
                    if (updateCacheProperty.Checked)
                    {
                        updatecache = true;
                    }
                }
                TextBox tagsedit=row.FindControl("tagsPropertyEdit") as TextBox;
                string tags =string.Empty ;
                if (tagsedit != null)
                {
                    tags = tagsedit.Text ;
                }
                string jsonFilePath = Server.MapPath("~/myjsondata.json");
                Root obj=new Root();
                using (StreamReader reader = new StreamReader(jsonFilePath))
                {
                    string json = reader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<Root>(json);
                }
                Mxd mxd = obj.source.mxds[e.RowIndex];
                mxd.deploy = deploye;
                mxd.updatesharing=updateshre;
                mxd.updatecaching = updatecache;
                mxd.updateproperties = updatepropey;
                List<string> list = new List<string>();
                string[] mylist = tags.Split(',');
                foreach (var item in mylist)
                {
                    if (item!=null && item!=string.Empty)
                    {
                        list.Add(item);
                    }
                    
                }
                mxd.tags = list;
                obj.source.mxds[e.RowIndex]=mxd;
                string updatedJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(jsonFilePath))
                {
                    writer.Write(updatedJson);
                }
                GridView1.EditIndex = -1;
                BindGrid();
            }

        }
       

        public class MxdBinding
        {
            public string name { get; set; }
            public bool deploy { get; set; }
            public bool updateproperties { get; set; }
            public bool updatesharing { get; set; }
            public bool updatecaching { get; set; }
            public string tags { get; set; }
        }

        protected void deploybutton_Click(object sender, EventArgs e)
        {
            //For Deployment Button
            string jsonFilePath = Server.MapPath("~/myjsondata.json");
            Root obj = new Root();
            using (StreamReader reader = new StreamReader(jsonFilePath))
            {
                string json = reader.ReadToEnd();
                obj = JsonConvert.DeserializeObject<Root>(json);
            }
            string newFileName = "Config_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json";
            string newJsonFilePath = Server.MapPath("~/" + newFileName);
            string updatedJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(newJsonFilePath))
            {
                writer.Write(updatedJson);
            }
            string url = "https://example.com/update-config"; // Replace with your actual URL
            string parameters = "?fileName=" + newFileName;

            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString(url + parameters);
                // You can handle the response here if needed
            }
        }
    }
}