public class Achievement_WinLevel : AAchievementDetector
{
	private int tetrisPlacedCount;

	private int towerPlacedCount;

	protected override void IngameDetectStartProc()
	{
	}

	protected override void IngameDetectStopProc()
	{
	}

	private void OnPlayerBuildTetris(Obj_TetrisBlock block)
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnPlayerVictory()
	{
	}

	protected override void InstantCheckProc()
	{
	}
}
