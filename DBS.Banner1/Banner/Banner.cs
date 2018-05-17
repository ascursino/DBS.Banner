using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace DBS.Banner1.Banner
{
    [ToolboxItemAttribute(false)]
    public class Banner : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/DBS.Banner1/Banner/BannerUserControl.ascx";

        private const string js1 = "redirect.js";
        private const string js3 = "jquery.easing.js";
        private const string js4 = "jquery.js";
        private const string js5 = "script.js";

        private const string incJs1 = "redirect";
        private const string incJs3 = "jquery.easing";
        private const string incJs4 = "jquery";
        private const string incJs5 = "script";

        private const string IncludeScriptFormat =
            @"<script language=""{0}"" src=""{1}{2}""></script>";

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
        }

        public Banner()
        {
            try
            {
                this.PreRender += new EventHandler(Banner_PreRender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void Banner_PreRender(object sender, System.EventArgs e)
        {

            ClientScriptManager cs = Page.ClientScript;
            String location = "/_layouts/DBS.Banner1/";

            //Script 1
            if (!cs.IsClientScriptBlockRegistered(incJs1))
            {
                // Create the client script block.
                string includeScript1 = String.Format(IncludeScriptFormat, "javascript", location, js1);
                cs.RegisterClientScriptBlock(this.GetType(), incJs1, includeScript1);
            }

            //Script 2
            if (!cs.IsClientScriptBlockRegistered(incJs4))
            {
                // Create the client script block.
                string includeScript4 = String.Format(IncludeScriptFormat, "javascript", location, js4);
                cs.RegisterClientScriptBlock(this.GetType(), incJs4, includeScript4);
            }

            //Script 3
            if (!cs.IsClientScriptBlockRegistered(incJs3))
            {
                // Create the client script block.
                string includeScript3 = String.Format(IncludeScriptFormat, "javascript", location, js3);
                cs.RegisterClientScriptBlock(this.GetType(), incJs3, includeScript3);
            }

            //Script 4
            if (!cs.IsClientScriptBlockRegistered(incJs5))
            {
                // Create the client script block.
                string includeScript5 = String.Format(IncludeScriptFormat, "javascript", location, js5);
                cs.RegisterClientScriptBlock(this.GetType(), incJs5, includeScript5);
            }

        }
    }
}
