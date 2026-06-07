namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public enum CreateLobbyResultType
	{
		Unknown = 0,
		Ok = 1,
		Fail = 2,
		NoConnection = 3,
		AccessDenied = 15,
		Timeout = 16,
		LimitExceeded = 25
	}
}
