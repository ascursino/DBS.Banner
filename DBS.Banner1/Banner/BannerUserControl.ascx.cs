using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using Microsoft.SharePoint;

namespace DBS.Banner1.Banner
{
    public partial class BannerUserControl : UserControl
    {
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            montaBanner();
        }

        private void montaBanner()
        {
            try
            {

                StringBuilder sbMain = new StringBuilder();
                StringBuilder sbMenu = new StringBuilder();

                sb.AppendLine("<div id=\"lofslidecontent45\" class=\"lof-slidecontent\">");
                sb.AppendLine("<div class=\"preload\"><div></div></div>");
                sb.AppendLine(" <!-- MAIN CONTENT -->");
                sb.AppendLine("  <div class=\"lof-main-outer\">");
                sb.AppendLine("  	<ul class=\"lof-main-wapper\">");

                //carrego os itens da lista

                using (SPWeb oWebsiteRoot = SPContext.Current.Site.RootWeb)
                {
                    SPList banners = oWebsiteRoot.Lists["Banners"];

                    if (banners.Items.Count < 4)
                    {
                        Literal1.Text = "Erro: Menos de 4 banners configurados. Revise a lista";
                    }
                    //Loop em todos os banners
                    foreach (SPListItem item in banners.Items)
                    {
                        //Só aceita banners ativos
                        if (Boolean.Parse(item["Ativo"].ToString()) == true)
                        {
                            //Área Main
                            sbMain.AppendLine("  		<li>");
                            sbMain.AppendLine("			<img src=\"" + item["Imagem"].ToString() + "\" title=\"" + item["Titulo"].ToString() + "\" onclick=\"irPara('" + item["Link"].ToString() + "');\" height=\"229\" width=\"470\"/>");
                            //sbMain.AppendLine("			<div class=\"lof-main-item-desc\">");
                            //sbMain.AppendLine("				<h3><a target=\"_parent\" title=\"" + item["Titulo"].ToString() + "\" href=\"" + item["Link"].ToString() + "\">" + item["Titulo"].ToString() + "</a></h3>");
                            //sbMain.AppendLine("				<p>" + item["Descricao"].ToString() + "</p>");
                            //sbMain.AppendLine("			</div>");
                            sbMain.AppendLine("  		</li>");

                            //Área Menu
                            sbMenu.AppendLine("            <li>");
                            sbMenu.AppendLine("            	<div>");
                            sbMenu.AppendLine("                	<h3>" + item["TituloMenu"].ToString() + "</h3>");
                            sbMenu.AppendLine("            	</div>");
                            sbMenu.AppendLine("            </li>");
                        }
                    }

                    sb.AppendLine(sbMain.ToString());
                    sb.AppendLine("      </ul>");
                    sb.AppendLine("  </div>");
                    sb.AppendLine(" <!-- END MAIN CONTENT --> ");
                    sb.AppendLine("");

                    sb.AppendLine(" <!-- NAVIGATOR --> ");
                    sb.AppendLine("  <div class=\"lof-navigator-outer\">");
                    sb.AppendLine("  		<ul class=\"lof-navigator\">");
                    sb.AppendLine(sbMenu.ToString());
                    sb.AppendLine("  		</ul>");
                    sb.AppendLine("  </div>");

                    Literal1.Text = sb.ToString();
                    montaInicializacaoJavaScript();
                }


            }
            catch (Exception ex)
            {
                Literal1.Text = ex.ToString();
            }

        }

        private void montaInicializacaoJavaScript()
        {
            Literal2.Text = "<script type=\"text/javascript\">$(document).ready(function () {$('#lofslidecontent45').lofJSidernews({ interval: 10000, easing: 'easeInOutQuad', duration: 1200, auto: true});});</script>";            
        }

    }

}