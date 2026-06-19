public class LeaderboardHelperWrapper
{
	private static ILeaderboardHelper _Instance;

	public static ILeaderboardHelper Instance
	{
		get
		{
			if (_Instance == null)
			{
				Create();
			}
			return _Instance;
		}
	}

	public static void Create()
	{
		_Instance = new SteamLeaderboardHelper();
	}
}
