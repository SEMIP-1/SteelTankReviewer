using SteelTankReviewer.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelTankReviewer.Application.Abstractions.Persistence
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Project>> GetByEngineerIdAsync(Guid engineerId, CancellationToken cancellationToken = default);
    }
}
