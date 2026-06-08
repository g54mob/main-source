public class BardicheExecuteEventController : BaseEventController
{
	private static BardicheExecuteEventController instance;

	public static BardicheExecuteEventController singleton
	{
		get
		{
			if (instance == null)
			{
				instance = new BardicheExecuteEventController();
			}
			return instance;
		}
	}

	public override string GetEventId()
	{
		return "bardiche";
	}

	public override int[] GetProgressThresholds()
	{
		return new int[13]
		{
			1, 10, 10, 50, 50, 50, 250, 250, 250, 250,
			2000, 2000, 2000
		};
	}

	protected override string GetRewardItemId()
	{
		return "bardiche";
	}

	protected override string GetRewardTitleTID()
	{
		return "tid_info_execute_title";
	}

	public void ReportExecute()
	{
		if (EventController.singleton.IsEventActiveAndStarted("bardiche"))
		{
			ImproveReward();
		}
	}
}
