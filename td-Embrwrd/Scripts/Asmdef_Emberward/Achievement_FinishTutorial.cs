using System.Collections.Generic;

public class Achievement_FinishTutorial : AAchievementDetector
{
	protected override void IngameDetectStartProc()
	{
	}

	protected override void IngameDetectStopProc()
	{
	}

	private void OnPlayerVictory()
	{
	}

	protected override void InstantCheckProc()
	{
	}

	protected override List<eAchievementType> GetQualifiedForUnlockAchievementsProc()
	{
		return null;
	}
}
