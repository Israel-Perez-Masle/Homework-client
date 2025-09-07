namespace entities
{

    public class Message
    {

        public DateTime date;
        public string message;
        public string sender;
        public string hora;
        public string fechayHora;


        public Message(string message, string sender)
        {
            this.message = message;
            this.sender = sender;
            date = DateTime.Today;
            hora = DateTime.Now.ToString("HH:mm:ss tt");
            fechayHora = date.ToString("yyyy-MM-dd") + " " + hora;
        }
        
        
    }
}