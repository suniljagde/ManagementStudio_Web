using BusinessObject;
using MasterClass;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStudio_Web.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        #region Global
        private BoCommon objBoCommon;
        private McUser objMcUser;
        private List<McUser> lstMcUser;
        #endregion

        #region Constructor
        public UserController()
        {
            objBoCommon = new BoCommon();
            objMcUser = new McUser();
            lstMcUser = new List<McUser>();
        }
        #endregion

        public IActionResult Index()
        {
            objMcUser = objBoCommon.GetUser();
            return View(objMcUser);
        }

        /*
        public IActionResult ListUsers()
        {
            lstMcUser = objBoCommon.GetAllUser();
            return View(lstMcUser);
        }        */

        [Route("list")]
        public IActionResult ListUsers() => View(objBoCommon.GetAllUser());

    }
}
