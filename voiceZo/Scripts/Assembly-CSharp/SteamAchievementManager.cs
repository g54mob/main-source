using Steamworks;
using UnityEngine;

public class SteamAchievementManager : MonoSingleton<SteamAchievementManager>
{
	private const string FINAL_ACHIEVEMENT = "FINAL";

	[SerializeField]
	private bool _resetStatsOnGameStart;

	[SerializeField]
	private bool _alsoResetAchievements;

	public void Achieve_FinalAchievement()
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetAchievement("FINAL", out var pbAchieved);
			if (!pbAchieved)
			{
				SteamUserStats.SetAchievement("FINAL");
				SteamUserStats.StoreStats();
			}
		}
	}

	private void Start()
	{
		if (SteamManager.Initialized && _resetStatsOnGameStart)
		{
			SteamUserStats.ResetAllStats(_alsoResetAchievements);
		}
	}
}
