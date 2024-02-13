using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using static GridViewNewProject.MyJSON;

namespace GridViewNewProject
{
    public class MyJSON
    {
        public class Source
        {
            public string mxdPath { get; set; }
            public string LOADBALANCER { get; set; }
            public string INTSERVER { get; set; }
            public string AppSuiteSERVER { get; set; }
            public string webAdaptorPortal { get; set; }
            public string webAdaptorserver { get; set; }
            public string geocodingServer { get; set; }
            public string GCXAppPath { get; set; }
            public List<Mxd> mxds { get; set; }
            public List<App> apps { get; set; }
            public List<Workflow> workflows { get; set; }
        }
        public class Mxd
        {
            public string name { get; set; }
            public string serverSite { get; set; }
            public List<string> category { get; set; }
            public bool deploy { get; set; }
            public bool updateproperties { get; set; }
            public bool updatesharing { get; set; }
            public bool updatecaching { get; set; }
            public List<string> tags { get; set; }
            public string servicename { get; set; }
            public string foldername { get; set; }
            public string portalfoldername { get; set; }
            public bool featureaccess { get; set; }
            public string featureaccess_capabilities { get; set; }
            public int minInstancesPerNode { get; set; }
            public int maxInstancesPerNode { get; set; }
            public string textAntialiasingMode { get; set; }
            public string antialiasingMode { get; set; }
            public string description { get; set; }
            public bool cached { get; set; }
            public string tile_origin { get; set; }
            public string num_of_scales { get; set; }
            public string scales { get; set; }
            public string predefined_tiling_scheme { get; set; }
            public string summary { get; set; }
            public string licenseInfo { get; set; }
            public string accessInformation { get; set; }
            public Sharing sharing { get; set; }
        }

        public class Sharing
        {
            public bool everyone { get; set; }
            public bool org { get; set; }
            public List<object> groups { get; set; }
        }

        public class App
        {
            public string name { get; set; }
            public string serverSite { get; set; }
            public bool deploy { get; set; }
        }

        public class Workflow
        {
            public string name { get; set; }
            public string id { get; set; }
            public string serverSite { get; set; }
            public bool deploy { get; set; }
        }

        public class Environments
        {
            public UAT UAT { get; set; }
            public PPD PPD { get; set; }
            public TRN TRN { get; set; }
        }

        public class UAT
        {
            public string GCXAppPath { get; set; }
            public string arcgiscache { get; set; }
            public string landmap { get; set; }
            public string LOADBALANCER { get; set; }
            public string portalServer { get; set; }
            public string AGSserverName { get; set; }
            public Dictionary<string, ServerSite> serverSite { get; set; }
            public string[] dataSources { get; set; }
            public string AppSuiteSERVER { get; set; }
        }

        public class PPD
        {
            public string GCXAppPath { get; set; }
            public string arcgiscache { get; set; }
            public string landmap { get; set; }
            public string LOADBALANCER { get; set; }
            public string portalServer { get; set; }
            public string AGSserverName { get; set; }
            public Dictionary<string, ServerSite> serverSite { get; set; }
            public string[] dataSources { get; set; }
            public string AppSuiteSERVER { get; set; }
        }

        public class TRN
        {
            public string GCXAppPath { get; set; }
            public string arcgiscache { get; set; }
            public string landmap { get; set; }
            public string LOADBALANCER { get; set; }
            public string portalServer { get; set; }
            public string AGSserverName { get; set; }
            public Dictionary<string, ServerSite> serverSite { get; set; }
            public string[] dataSources { get; set; }
            public string AppSuiteSERVER { get; set; }
        }

        public class ServerSite
        {
            public string webAdaptorserver { get; set; }
            public string agsConnection { get; set; }
        }

        public class Root
        {
            public Source source { get; set; }
            public Environments environments { get; set; }
        }

    }
}