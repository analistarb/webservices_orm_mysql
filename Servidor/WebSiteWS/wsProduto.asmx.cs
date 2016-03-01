using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using BLL;
using DAL;

namespace WebSiteWS
{
    /// <summary>
    /// Summary description for wsProduto
    /// </summary>
    [WebService(Namespace = "webserviceModel")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsProduto : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsultarProduto()
        {
            try
            {
                NegProduto negProduto = new NegProduto();
                List<vproduto_categoria> colecao = new List<vproduto_categoria>();
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

                string json = string.Empty;

                colecao.AddRange(negProduto.ConsultarProduto(null));
                json = jsSerializer.Serialize(colecao);

                return json;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
