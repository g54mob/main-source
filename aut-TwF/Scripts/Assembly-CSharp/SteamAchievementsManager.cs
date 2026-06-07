using UnityEngine;

public class SteamAchievementsManager : MonoBehaviour
{
	[SerializeField]
	private SteamAchievement[] achievements;

	private bool hasStarted;

	private void Start()
	{
		hasStarted = true;
		SteamAchievement[] array = achievements;
		foreach (SteamAchievement steamAchievement in array)
		{
			if (!steamAchievement.IsUnlocked())
			{
				steamAchievement.StartAchievement();
			}
		}
	}

	private void OnDestroy()
	{
		if (!hasStarted)
		{
			return;
		}
		SteamAchievement[] array = achievements;
		foreach (SteamAchievement steamAchievement in array)
		{
			if (steamAchievement.IsStarted)
			{
				steamAchievement.EndAchievemet();
			}
		}
	}
}
