public class Quest_LockTwoRandomTower : AQuestBase
{
	private bool isTowerBuilt;

	private eItemType bannedTowerType_1;

	private eItemType bannedTowerType_2;

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
