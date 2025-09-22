using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectIsCreated_Start_Success()
        {
            // Arrange
            var project = new Project("Projeto teste", "Um projeto de teste", 1, 2, 2000);

            // Act
            project.Start();

            // Assert
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartAt);

            Assert.True(project.Status == ProjectStatusEnum.InProgress);
            Assert.False(project.StartAt is null);

        }

        [Fact]
        public void ProjectIsInvalidState_Start_ThrowsException()
        {
            // Arrange
            var project = new Project("Projeto teste", "Um projeto de teste", 1, 2, 2000);
            project.Start();
            // Act
            Action? start = project.Start;

            // Assert
            var exception = Assert.Throws<InvalidOperationException>(start);
            Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);
        }
    }
}
