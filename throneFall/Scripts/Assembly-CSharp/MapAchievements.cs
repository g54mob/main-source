using System.Collections;
using UnityEngine;

public class MapAchievements : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(GiveMapAchievements());
	}

	private IEnumerator GiveMapAchievements()
	{
		yield return null;
		yield return null;
		AchievementManager.GiveCrownsAchievement(LevelProgressManager.instance.CrownsAchieved());
		bool flag = true;
		foreach (Equippable allEquippable in PerkManager.instance.allEquippables)
		{
			if (!allEquippable.IsUnlocked)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			AchievementManager.UnlockAchievement(AchievementManager.Achievements.MAXLEVEL_REACHED);
		}
	}
}
