public class Quest_OnlyUseThreeTypeTowers : AQuestBase
{
	private bool isFailed;

	private eItemType builtTowerType_1;

	private eItemType builtTowerType_2;

	private eItemType builtTowerType_3;

	private void OnEnable()
	{
	}

	private void OnDisable()
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
