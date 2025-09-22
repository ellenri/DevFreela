using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetlProjectById
{
    public class GetByIdProjectQuery : IRequest<ResultViewModel<ProjectViewModel>>
    {
        public GetByIdProjectQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }


}
