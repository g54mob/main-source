public class Quest_DrawXCards : AQuestBase
{
	private int cardDrawnCount;

	private int requirement;

	private bool isQuestSuccess;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPlayerDrawCard()
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
