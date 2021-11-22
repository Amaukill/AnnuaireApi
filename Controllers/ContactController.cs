using AnnuaireApi.Data;
using AnnuaireApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnuaireApi.Controllers
{
    [ApiController]
    [Route("Contact")]
    public class ContactController : ControllerBase
    {
        DataAccess db;
        // GET: ContactController
        public ContactController(IConfiguration configuration)
        {
           db = new DataAccess(configuration);
        }
        
        [Route("GetAllContact")]
        [HttpGet]
        public ActionResult<List<Contact>> GetAllContact()
        {
            return db.GetAllContact();
        }
        [Route("GetContactsByParameters")]
        [HttpGet]
        public ActionResult<List<Contact>> GetContactsByParameters(string first=null , string last=null , string city=null , string street = null , int? zip = null)
        {
            return db.GetContactsByParameters(first,last,city,street,zip);
        }

    }
}
