namespace RESTcarsConsumer
{
    class Car
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return Id + " " + Vendor + " " + Model;
        }
    }
}
