using DevFreela.Application.Models;
using DevFreela.Core.Repository;
using MediatR;

namespace DevFreela.Application.Queries.GetlProjectById
{
    public class GetByIdProjectHandler : IRequestHandler<GetByIdProjectQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly IProjectRepository _repositoy;
        public GetByIdProjectHandler(IProjectRepository repository)
        {
            _repositoy = repository;
        }
        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _repositoy.GetDetailsById(request.Id);

            if (project is null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não encontrado");
            }

            var model = ProjectViewModel.FromEntity(project);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}

