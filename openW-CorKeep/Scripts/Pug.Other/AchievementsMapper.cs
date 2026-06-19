using UnityEngine;

[CreateAssetMenu(menuName = "Pug/AchievementMapper")]
public class AchievementsMapper : ScriptableObject
{
	[SerializeField]
	private AchievementData[] achievementDataArray;

	public AchievementData[] AchievementDataArray
	{
		get
		{
			return achievementDataArray;
		}
		set
		{
			achievementDataArray = value;
		}
	}

	public string GetSteamAchievement(AchievementID achievementID)
	{
		for (int i = 0; i < achievementDataArray.Length; i++)
		{
			if (achievementDataArray[i].AchievementID == achievementID)
			{
				return achievementDataArray[i].SteamID;
			}
		}
		return achievementID.ToString();
	}

	public int GetPlatformAchievement(AchievementID achievementID)
	{
		for (int i = 0; i < achievementDataArray.Length; i++)
		{
			_ = achievementDataArray[i].AchievementID;
		}
		return -1;
	}

	public AchievementData GetAchievementData(AchievementID achievementID)
	{
		for (int i = 0; i < achievementDataArray.Length; i++)
		{
			if (achievementDataArray[i].AchievementID == achievementID)
			{
				return achievementDataArray[i];
			}
		}
		Debug.LogWarning(string.Format("{0}: missing mapping for achievment with id {1}.", "AchievementsMapper", achievementID));
		return null;
	}
}
