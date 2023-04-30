namespace MapperApp.Models
{
    public class Driver
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }    

       public int DriverNumber { get; set; }

        public DateTime AddedDate { get; set; } 
    public DateTime UpdatedDate { get; set; }

    public int status { get; set; }

        public int  WorldChampianShip { get; set; }
    }
}
