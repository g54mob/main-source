using System.Collections.Generic;
using CloudOnce.Internal;

public class MobileAchievementStore : AAchievementStore
{
	private Dictionary<AchievementController.Type, UnifiedAchievement> idMap = new Dictionary<AchievementController.Type, UnifiedAchievement>();

	private bool failedToUnlock;

	public override void Init()
	{
	}

	public override bool UnlockAchievement(AchievementController.Type type)
	{
		return false;
	}

	public override void ClearAll()
	{
	}

	private void Update()
	{
	}

	private void InitAndroidAchievements()
	{
	}
}
