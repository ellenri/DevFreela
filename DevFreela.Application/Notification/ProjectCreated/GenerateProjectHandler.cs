using MediatR;

namespace DevFreela.Application.Notification.ProjectCreated
{
    public class GenerateProjectHandler : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Criando painel para projeto {notification.Title}!");

            return Task.CompletedTask;
        }
    }
}
