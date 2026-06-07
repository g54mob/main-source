using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Non Game Scene Achievement")]
public class NonGameSceneAchievement : AchievementBase
{
	public override void Uninitialize()
	{
	}

	protected override void Initialize()
	{
	}

	public override void UnlockAchievement(PlayerProfile playerProfile)
	{
		playerProfile?.UnlockAchievement(this);
	}
}
