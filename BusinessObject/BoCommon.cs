using DataAccess;
using MasterClass;

namespace BusinessObject
{
    public class BoCommon
    {
        #region Global
        private DaCommon objDaCommon;
        #endregion

        #region Constructor
        public BoCommon()
        {
            objDaCommon = new DaCommon();
        }
        #endregion

        /*
        public McUser GetUser()
        {
            return objDaCommon.GetUser();
        }
        */

        public McUser GetUser() => objDaCommon.GetUser();
        public List<McUser> GetAllUser() => objDaCommon.GetAllUsers();
    }
}
