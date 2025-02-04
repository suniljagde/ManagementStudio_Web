using BusinessObject;
using MasterClass;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStudio_Web.Controllers
{
    public class UserController : Controller
    {
        #region Global
        private BoCommon objBoCommon;
        private McUser objMcUser;
        #endregion

        #region Constructor
        public UserController()
        {
            objBoCommon = new BoCommon();
            objMcUser = new McUser();
        }
        #endregion

        public IActionResult Index()
        {
            objMcUser = objBoCommon.GetUser();
            return View(objMcUser);
        }
    }
}
