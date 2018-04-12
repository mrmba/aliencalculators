using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
    public enum MessageType
    {
        Success,
        Warning,
        Error
    }
    
    public class BaseController : Controller
    {
        public const string SUCCESS_MESSAGE_KEY = "postSuccessMessage.Text";
        public const string SUCCESS_MESSAGE_TYPE_KEY = "postSuccessMessage.Type";


        protected void SetMessage(string text, MessageType type = MessageType.Success)
        {
            TempData[SUCCESS_MESSAGE_KEY] = text;
            TempData[SUCCESS_MESSAGE_TYPE_KEY] = type;
        }
    }
}