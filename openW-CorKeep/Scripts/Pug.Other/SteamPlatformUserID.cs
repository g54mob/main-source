public class SteamPlatformUserID : PlatformUserID
{
	private readonly ulong platformId;

	public override ulong GetLocalUserId()
	{
		return platformId;
	}

	public override ulong GetPlatformOnlineId()
	{
		return platformId;
	}

	public SteamPlatformUserID(ulong id)
	{
		platformId = id;
	}
}
