namespace LaundryApplication.Models
{
    public class User
    {
        public string _phoneNumber { get; set; }

        public string _name { get; set; }

        public string _email { get; set; }

        public string _address { get; set; } = "";

        public User(string phone, string name, string email)
        {
            _phoneNumber = phone;
            _name = name;
            _email = email;
        }

        public void serialize(StreamWriter s)
        {
            s.WriteLine(_phoneNumber);
            s.WriteLine(_name);
            s.WriteLine(_email);
            s.WriteLine(_address);
        }

        public void deserialize(StreamReader s)
        {
            string? temp = s.ReadLine();
            _phoneNumber = (null == temp) ? "" : temp;
            temp = s.ReadLine();
            _name = (null == temp) ? "" : temp;
            temp = s.ReadLine();
            _email = (null == temp) ? "" : temp;
            temp = s.ReadLine();
            _address = (null == temp) ? "" : temp;
        }

        private User()
        {
            _phoneNumber = "";
            _name = "";
            _email = "";
        }
    }
}
