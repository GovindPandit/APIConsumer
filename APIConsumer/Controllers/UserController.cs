using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace APIConsumer.Controllers
{
    public class UserController : ApiController
    {
        // GET: User
        public IHttpActionResult getUsers()
        {
            sampleEntities entities = new sampleEntities();
            var users=entities.users.ToList();
            return Ok(users);
        }
    }
}