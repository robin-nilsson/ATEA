using ATEA.console;
using ATEA.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ATEA.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public async Task<ActionResult> Atea()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50046/api/Messages");
            var messages = await response.Content.ReadAsAsync<IEnumerable<Message>>();
            return View(messages);
        }
    }
}