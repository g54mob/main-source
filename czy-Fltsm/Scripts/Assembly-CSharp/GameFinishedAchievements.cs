using M4.Session;
using UnityEngine;

public class GameFinishedAchievements : MonoBehaviour
{
	[SerializeField]
	private AchievementBase[] _achievements;

	public void Trigger()
	{
		PlayerProfile profile = Session.Profile;
		AchievementBase[] achievements = _achievements;
		for (int i = 0; i < achievements.Length; i++)
		{
			achievements[i].UnlockAchievement(profile);
		}
	}
}
