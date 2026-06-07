public class Quest_NoSellTower : AQuestBase
{
	private bool isSoldTower;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestSellTower(ABaseTower tower)
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
