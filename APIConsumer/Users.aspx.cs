using APIConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APIConsumer
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            IEnumerable<User> users;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress=new Uri("https://localhost:44390/api/user");

            var consumeapi = httpClient.GetAsync("user");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displayresults = readdata.Content.ReadAsAsync<IList<User>>();
                displayresults.Wait();
                users = displayresults.Result;
                GridView1.DataSource = users;
                GridView1.DataBind();
            }

        }
    }
}