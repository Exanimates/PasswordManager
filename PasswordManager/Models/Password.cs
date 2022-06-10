namespace PasswordManager.Models
{
    public class Password
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }

        public string Pass { get; set; }

        public string Comment { get; set; }

        public string Tags { get; set; }
    }
}
