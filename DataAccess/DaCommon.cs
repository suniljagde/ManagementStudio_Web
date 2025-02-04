using MasterClass;

namespace DataAccess
{
    public class DaCommon
    {
        #region GLobal
        private McUser objMcUser;
        #endregion

        #region Constructor
        public DaCommon()
        {
            objMcUser = new McUser();
        }
        #endregion

        #region Method
        /*
        public McUser GetUser()
        {
            /*
            McUser usr = new McUser();
            usr.Id = 1001;
            usr.Username = "Sunil Jagde";
            usr.Email = "sunil.admin@gyan.co.in";
            usr.Address = "Sakinaka";
            usr.Password = "super@123";
            usr.IsActive = true;

            McUser usr = new McUser()
            {
                Id = 1,
                Username = "Test",
                Email = "Test",
                Address = "Test",
                Password = "Test",
                IsActive = true
            };

            return usr;

            return new McUser()
            {
                Id = 1001,
                Username = "Sunil Jagde",
                Email = "sunil.admin@gyan.co.in",
                Address = "Sakinaka",
                Password = "super@123",
                IsActive = true
            };
        }*/
        #endregion

        #region Shorthand_Methods
        public McUser GetUser() => new McUser()
        {
            Id = 1001,
            Username = "Sunil Jagde",
            Email = "sunil.admin@gyan.co.in",
            Address = "Sakinaka",
            Password = "super@123",
            IsActive = true
        };
        public List<McUser> GetAllUsers() => new List<McUser>()
            {
                new McUser()
                {
                    Id = 1001,
                    Username = "Sunil Jagde",
                    Email = "sunil.admin@gyan.co.in",
                    Address = "Sakinaka",
                    Password = "super@123",
                    IsActive = true
                },
                new McUser()
                {
                    Id = 1002,
                    Username = "Kunal Mendarkar",
                    Email = "kunal.admin@gyan.co.in",
                    Address = "Kamothe",
                    Password = "super@123",
                    IsActive = false
                },
                new McUser()
                {
                    Id = 1001,
                    Username = "Prince Gupta",
                    Email = "prince.admin@gyan.co.in",
                    Address = "Dahisar",
                    Password = "super@123",
                    IsActive = true
                }
            };
        #endregion
    }
}
