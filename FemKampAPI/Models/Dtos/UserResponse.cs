namespace FemKampAPI.Models.Dtos
{
    public record UserResponse(
        int UserId,
        string Username,
        string? Couple,
        int? ResourceId);
}
