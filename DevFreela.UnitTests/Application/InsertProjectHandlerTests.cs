using DevFreela.Application.Commands.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repository;
using DevFreela.UnitTests.Fakes;
using FluentAssertions;
using Moq;
using NSubstitute;

namespace DevFreela.UnitTests.Application
{
    public class InsertProjectHandlerTests
    {
        [Fact]
        public async Task InputDataAreOk_Insert_Success_Moq()
        {
            // Arrange
            const int ID = 1;

            //1 primeira opcao usando moq
            //var mock = new Mock<IProjectRepository>();
            //mock.Setup(r => r.Add(It.IsAny<Project>())).ReturnsAsync(ID);

            //2 segunda opcao usando moq
            var repository = Mock.Of<IProjectRepository>(r => r.Add(It.IsAny<Project>()) ==  Task.FromResult(1));

            //var command = new InsertProjectCommand
            //{
            //    Title = "Projeto teste",
            //    Description = "Um projeto de teste",
            //    TotalCost = 1000,
            //    ClientId = 2,
            //    FreelancerId = 1
            //    };

            var command = FakeDataHelper.CreateFakeInsertProjectCommand();

            var handler = new InsertProjectHandle(repository);

            // Act

            var result = await handler.Handle(command, new CancellationToken());
            // Assert

            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);

            //Usada com a 1 primeira opcap 
            //mock.Verify(m => m.Add(It.IsAny<Project>()), Times.Once);

            //Usada com a segunda opcao
            Mock.Get(repository).Verify(m => m.Add(It.IsAny<Project>()), Times.Once);

            //Usando Biblioteca FluentAsserts
        }

        public async Task InputDataAreOk_Insert_Success_NSubstitute()
        {
            // Arrange
            const int ID = 1;

            var repository = Substitute.For<IProjectRepository>();
            repository.Add(Arg.Any<Project>()).Returns(Task.FromResult(ID));

            var command = new InsertProjectCommand
            {
                Title = "Projeto teste",
                Description = "Um projeto de teste",
                TotalCost = 1000,
                ClientId = 2,
                FreelancerId = 1
            };

            var handler = new InsertProjectHandle(repository);

            // Act

            var result = await handler.Handle(command, new CancellationToken());
            // Assert

            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);

            await repository.Received(1).Add(Arg.Any<Project>());
        }

        public async Task InputDataAreOk_Insert_Success_FluentAssertions()
        {
            // Arrange
            const int ID = 1;

            var repository = Substitute.For<IProjectRepository>();
            repository.Add(Arg.Any<Project>()).Returns(Task.FromResult(ID));

            var command = new InsertProjectCommand
            {
                Title = "Projeto teste",
                Description = "Um projeto de teste",
                TotalCost = 1000,
                ClientId = 2,
                FreelancerId = 1
            };

            var handler = new InsertProjectHandle(repository);

            // Act

            var result = await handler.Handle(command, new CancellationToken());
            // Assert

            Assert.True(result.IsSuccess);
            result.IsSuccess.Should().BeTrue();

            Assert.Equal(ID, result.Data);
            result.Data.Should().Be(ID);

            await repository.Received(1).Add(Arg.Any<Project>());
        }
    }
}
