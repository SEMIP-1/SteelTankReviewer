using System;
using System.Collections.Generic;
using System.Text;

namespace SteelTankReviewer.Application.Abstractions.Security
{
    public interface IEngineerContext
    {
        Guid EngineerId { get; }
    }
}
