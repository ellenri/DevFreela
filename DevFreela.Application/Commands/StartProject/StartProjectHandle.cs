using DevFreela.Application.Models;
using DevFreela.Core.Repository;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    internal class StartProjectHandle : IRequestHandler<StartProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repositoy;
        public StartProjectHandle(IProjectRepository repository)
        {
            _repositoy = repository;
        }
        public async Task<ResultViewModel> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repositoy.GetById(request.Id);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não encontrado");
            }

            project.Start();
            await _repositoy.Update(project);

            return ResultViewModel.Success();
        }
    }
}
