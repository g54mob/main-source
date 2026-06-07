public class Quest_MazeAtLeastXLength : AQuestBase
{
	private int requirement;

	private bool isQuestSuccess;

	private float detectInterval;

	private float detectTimer;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected override void OnSetupProc()
	{
	}

	private void Update()
	{
	}

	private int GetMaxMazeLength()
	{
		return 0;
	}

	public override bool IsQuestSuccess()
	{
		return false;
	}
}
