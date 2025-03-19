using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class CreatedProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public decimal TotalCost { get; set; }
        public int FreelancerId { get; set; }

        public Project ToEntity()
            => new (Title, Description, ClientId, FreelancerId, TotalCost);
    }
}
