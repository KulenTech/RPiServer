using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Faire.Controllers
{
	public class response 
	{
		public Boolean status { get; set; }
	}
	public class LoginController : Controller
	{	
		private Dictionary<String, String> ListOfUsers = new Dictionary<String, String>();
		public ActionResult Index ()
		{
			return Content ("Hello");
		}
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult auth(String input){
			dynamic req = JObject.Parse (input);
			string user = req.user;
			string pass = req.pass;
			response r = new response ();
			r.status = checkIf (user, pass);
			return Json (r);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult register(String input){
			dynamic req = JObject.Parse (input);
			string user = req.user;
			string pass = req.pass;
			response r = new response ();
			r.status = checkIfExists (user, pass);
			return Json (r);
		}
		public Boolean checkIfExists(string user, string pass){
			if (ListOfUsers.ContainsKey (user))
				return false;
			ListOfUsers.Add (user, pass);
			return true;
		}
		public Boolean checkIf(string user, string pass){
			string p;
			ListOfUsers.TryGetValue (user, out p);
			if (p == pass)
				return true;
			return false;
		}
	}
} 

