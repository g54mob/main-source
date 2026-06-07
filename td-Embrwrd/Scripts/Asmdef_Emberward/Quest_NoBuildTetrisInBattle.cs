public class Quest_NoBuildTetrisInBattle : AQuestBase
{
	private bool isBuiltInBattle;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
