namespace DevFreela.API.Models
{
    public class CreatedProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public decimal TotalCost { get; set; }
        public int FreelancerId { get; set; }
    }
}
