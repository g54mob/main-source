using UnityEngine;

public class XBoxAchievements : MonoBehaviour
{
	public Achievement[] Achievements;

	public const int ACHIVEMENT_COUNT = 14;

	private static XBoxAchievements _instance;

	public static XBoxAchievements Instance => null;

	private void Awake()
	{
	}

	public void UpdateAchievements()
	{
	}

	private Achievement GetAchievement(AchievementId id)
	{
		return null;
	}

	public void UnlockAchievement(AchievementId id, int currentVal = 1, bool managerHoldsValue = false, bool isIncremental = true)
	{
	}
}
