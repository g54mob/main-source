using System.Collections.Generic;

public class Achievement_LearnTalent : AAchievementDetector
{
	protected override void FullGameDetectStartProc()
	{
	}

	protected override void FullGameDetectStopProc()
	{
	}

	private void OnTalentChanged(eTalentType type)
	{
	}

	protected override void InstantCheckProc()
	{
	}

	protected override List<eAchievementType> GetQualifiedForUnlockAchievementsProc()
	{
		return null;
	}

	protected override void IngameDetectStartProc()
	{
	}

	protected override void IngameDetectStopProc()
	{
	}
}
