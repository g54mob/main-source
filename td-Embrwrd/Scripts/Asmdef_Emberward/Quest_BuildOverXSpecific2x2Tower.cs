public class Quest_BuildOverXSpecific2x2Tower : AQuestBase
{
	private int requirement;

	private eItemType targetTower;

	private int builtCountOnSetup;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	protected override void OnSetupProc()
	{
	}

	private void UpdateQuestStatus()
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
