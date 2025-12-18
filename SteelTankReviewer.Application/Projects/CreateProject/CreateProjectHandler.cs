using SteelTankReviewer.Application.Abstractions.Persistence;
using SteelTankReviewer.Application.Abstractions.Security;
using SteelTankReviewer.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelTankReviewer.Application.Projects.CreateProject
{
    public sealed class CreateProjectHandler
    {
        private readonly IEngineerContext _engineerContext;
        private readonly IProjectRepository _projectRepository;

        public CreateProjectHandler(
            IEngineerContext engineerContext,
            IProjectRepository projectRepository)
        {
            _engineerContext = engineerContext;
            _projectRepository = projectRepository;
        }

        public async Task<CreateProjectResult> HandleAsync(
            CreateProjectCommand command,
            CancellationToken cancellationToken = default)
        {
            // بسيط: validation خفيف هنا، والباقي Domain invariants هتمسكه
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var projectId = Guid.NewGuid();
            var engineerId = _engineerContext.EngineerId;

            var project = new Project(
                id: projectId,
                engineerId: engineerId,
                name: command.Name,
                description: command.Description,
                createdAtUtc: DateTimeOffset.UtcNow);

            await _projectRepository.AddAsync(project, cancellationToken);

            return new CreateProjectResult(projectId);
        }
    }
}
