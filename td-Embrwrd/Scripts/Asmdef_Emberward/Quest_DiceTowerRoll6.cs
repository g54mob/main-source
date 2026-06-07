public class Quest_DiceTowerRoll6 : AQuestBase
{
	private int rolled6Count;

	private int requirement;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDiceTowerRoll(Tower_Dice tower, int value)
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
