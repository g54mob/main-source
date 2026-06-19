using System;

[Serializable]
public class AchievementData
{
	public string SteamID;

	public AchievementID AchievementID;

	public int Ps4Id;

	public int Ps5Id;

	public int XboxId;

	public string EpicID;

	public string GOGID;

	public AchievementData(AchievementID achievementID, string steamID, int ps4Id, int ps5Id, int xboxId, string epicID)
	{
		AchievementID = achievementID;
		SteamID = steamID;
		Ps4Id = ps4Id;
		Ps5Id = ps5Id;
		XboxId = xboxId;
		EpicID = epicID;
	}

	public int GetPlatformAchievementId()
	{
		return -1;
	}
}
