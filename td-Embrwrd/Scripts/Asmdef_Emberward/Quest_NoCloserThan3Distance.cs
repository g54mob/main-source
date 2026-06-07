public class Quest_NoCloserThan3Distance : AQuestBase
{
	private float distance;

	private bool isFailed;

	private Obj_FireSource fireSource;

	private float updateInterval;

	private float timer;

	private Obj_QuestRangeIndicator rangeIndicator;

	private void OnEnable()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void CheckDistance()
	{
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
