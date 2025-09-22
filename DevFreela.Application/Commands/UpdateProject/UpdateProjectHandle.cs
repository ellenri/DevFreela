using DevFreela.Application.Models;
using DevFreela.Core.Repository;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repositoy;
        public UpdateProjectHandler(IProjectRepository repository)
        {
            _repositoy = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repositoy.GetById(request.ProjectId);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.Update(request.Title, request.Description, request.TotalCost);

            await _repositoy.Update(project);

            return ResultViewModel.Success();
        }
    }
}
