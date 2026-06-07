using M4.Session;
using UnityEngine;

public class StatsAndAchievementsManager : MonoBehaviour
{
	[SerializeField]
	private AchievementBase[] _achievements;

	private void OnDestroy()
	{
		AchievementBase[] achievements = _achievements;
		for (int i = 0; i < achievements.Length; i++)
		{
			achievements[i].Uninitialize();
		}
	}

	public void Initialize()
	{
		AchievementBase[] achievements = _achievements;
		for (int i = 0; i < achievements.Length; i++)
		{
			achievements[i].Initialize(Session.Profile);
		}
	}
}
