public class PlatformSession
{
	public string SessionId { get; set; }

	public string JoinString { get; set; }

	public PlatformSessionParams SessionParams { get; set; }

	public PlatformUserID Host { get; set; }

	public PlatformUserID FriendInSession { get; set; }

	public uint CurrentPlayers { get; set; }

	public bool FriendInSessionIsHosting
	{
		get
		{
			if (Host != null && FriendInSession != null)
			{
				return Host.GetPlatformOnlineId().Equals(FriendInSession.GetPlatformOnlineId());
			}
			return false;
		}
	}
}
