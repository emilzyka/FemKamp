using System.Security.Cryptography.X509Certificates;

namespace FemKampAPI.Models.Dtos
{
    public record ResourceResponse(
        int ResourceId,
        string ResourceName,
        string? TeamCaptain,
        int? Members);
}
