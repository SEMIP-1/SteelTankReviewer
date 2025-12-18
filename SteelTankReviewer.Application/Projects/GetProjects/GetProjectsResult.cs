using System;
using System.Collections.Generic;
using System.Text;

namespace SteelTankReviewer.Application.Projects.GetProjects
{
    public sealed record ProjectListItem(
        Guid ProjectId,
        string Name,
        DateTimeOffset CreatedAtUtc
    );
    public sealed record GetProjectsResult(IReadOnlyList<ProjectListItem> Projects);
}
