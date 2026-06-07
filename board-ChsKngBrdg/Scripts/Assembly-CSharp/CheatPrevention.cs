using System.Threading.Tasks;

public class CheatPrevention
{
	public static float minimumTimeToComplete = 44900f;

	public static bool hasCheatedPreviously = false;

	public static async Task<bool> CheckIfPreviouslyCheated()
	{
		return await SteamLeaderboards.TryGetGlobalLeaderboardEntriesAroundUser("CheaterSpeedrunTime", 0, 0) != null;
	}
}
