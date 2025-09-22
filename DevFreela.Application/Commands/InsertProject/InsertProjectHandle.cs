using DevFreela.Application.Models;
using DevFreela.Core.Repository;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public class InsertProjectHandle : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly IProjectRepository _repository;

        public InsertProjectHandle(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

           var id = await _repository.Add(project);

            return ResultViewModel<int>.Success(id);
        }
    }
}
