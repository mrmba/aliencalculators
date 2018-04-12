using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSGeek.DAL;

namespace SSGeek.Controllers
{
    public class ForumController : BaseController
    {
        private string connectionString;

        public ForumController(string connectionString)
        {
            this.connectionString = connectionString;
        }


        private IForumPostDAL _dal;

        public ForumController(IForumPostDAL dal)
        {
            _dal = dal;
        }

        public ActionResult Index()
        {
            List<ForumPost> allPosts = _dal.GetAllPosts();

            return View("Index", allPosts);
        }

        public ActionResult SubmitPost()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult SubmitPost(ForumPost model)
        {
            _dal.SaveNewPost(model);

            //Check that it was successfully added
            bool successful = true;

            //If successful:

            if (successful)
            {
                SetMessage("Your post was successfully added!", MessageType.Success);
            }
            else
            {
                SetMessage("There was an error adding your post!", MessageType.Error);
            }

            return RedirectToAction("Index");
        }

       
    }
}