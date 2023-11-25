namespace ModularAuthentication.Infra;

public record LoginResponse(
    string AccessToken, 
    int? UserId, 
    int? RoleId, 
    string Username);