using MediatR;

namespace DevFreela.Application.Notification.ProjectCreated
{
    public class FreelanceNotificationHandle : INotificationHandler<ProjectCreatedNotification>
    {
        public Task Handle(ProjectCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notificando Freelancers sobre o projeto{notification.Title}");

            return Task.CompletedTask;

        }
    }
}
