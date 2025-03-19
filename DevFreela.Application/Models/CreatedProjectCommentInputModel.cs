namespace DevFreela.Application.Models
{
    public class CreatedProjectCommentInputModel
    {
        public string Content { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
