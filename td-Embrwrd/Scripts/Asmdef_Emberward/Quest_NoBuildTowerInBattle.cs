public class Quest_NoBuildTowerInBattle : AQuestBase
{
	private bool isBuiltInBattle;

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
