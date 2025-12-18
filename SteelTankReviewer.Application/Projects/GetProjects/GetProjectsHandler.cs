using SteelTankReviewer.Application.Abstractions.Persistence;
using SteelTankReviewer.Application.Abstractions.Security;
using SteelTankReviewer.Application.Projects.CreateProject;
using SteelTankReviewer.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelTankReviewer.Application.Projects.GetProjects
{
    public sealed class GetProjectsHandler
    {
        private readonly IEngineerContext _engineerContext;
        private readonly IProjectRepository _projectRepository;

        public GetProjectsHandler(
            IEngineerContext engineerContext,
            IProjectRepository projectRepository)
        {
            _engineerContext = engineerContext;
            _projectRepository = projectRepository;
        }

        public async Task<GetProjectsResult> HandleAsync(
            GetProjectsQuery query,
            CancellationToken cancellationToken = default)
        {

            var engineerId = _engineerContext.EngineerId;

            var projects = await _projectRepository
                .GetByEngineerIdAsync(engineerId, cancellationToken);

            var items = projects
                .Select(p => new ProjectListItem(
                    p.Id,
                    p.Name,
                    p.CreatedAtUtc))
                .ToList()
                .AsReadOnly();

            return new GetProjectsResult(items);
        }
    }
}
