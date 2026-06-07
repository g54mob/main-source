public class Quest_LockOneRandomTower : AQuestBase
{
	private bool isTowerBuilt;

	private eItemType bannedTowerType;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnBattleStart()
	{
	}

	protected override void OnSetupProc()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
