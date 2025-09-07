namespace entities
{
    public class Message
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public string Hora { get; set; }
        public string FechayHora { get; set; }

        public Message() {} 

        public Message(string message, string sender)
        {
            Text = message;
            Sender = sender;
            Date = DateTime.Today;
            Hora = DateTime.Now.ToString("HH:mm:ss tt");
            FechayHora = Date.ToString("yyyy-MM-dd") + " " + Hora;
        }

        public override string ToString() => $"{Sender}: {Text} ({FechayHora})";
    }
}
