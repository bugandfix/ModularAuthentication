namespace ModularAuthentication.Constants;

public static class JwtConst
{
    public const string Secret = "bugandfixportal Training with enough character that should be enough";
    public const string Issuer = "https://bugandfix.com";
    public const string Audience = "https://bugandfix.com";
    public const int ExpiryMinutes = 60;
    public const string UserId = "uid";
    public const string RoleId = "rid";
}