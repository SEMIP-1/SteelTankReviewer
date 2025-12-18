using SteelTankReviewer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteelTankReviewer.Domain.Projects
{
    public sealed class Project
    {
        public Guid Id { get; }
        public Guid EngineerId { get; }

        public string Name { get; private set; }
        public string? Description { get; private set; }

        public DateTimeOffset CreatedAtUtc { get; }

        public Project(Guid id, Guid engineerId, string name, string? description, DateTimeOffset createdAtUtc)
        {
            if (id == Guid.Empty) throw new DomainException("Project Id cannot be empty.");
            if (engineerId == Guid.Empty) throw new DomainException("EngineerId cannot be empty.");
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Project name is required.");

            Id = id;
            EngineerId = engineerId;
            Name = name.Trim();
            Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
            CreatedAtUtc = createdAtUtc;
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new DomainException("Project name is required.");
            Name = newName.Trim();
        }

        public void UpdateDescription(string? description)
        {
            Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        }
    }
}
