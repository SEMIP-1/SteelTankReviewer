using SteelTankReviewer.Application.Abstractions.Security;

namespace SteelTankReviewer.Api.Auth
{
    public class EngineerContext : IEngineerContext
    {
        public Guid EngineerId { get; } =Guid.Parse("11111111-1111-1111-1111-111111111111");
    }
}
