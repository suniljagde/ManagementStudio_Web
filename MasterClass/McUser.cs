namespace MasterClass
{
    public class McUser
    {
        public McUser()
        {
            IsActive = true; // Setting up the default value
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
