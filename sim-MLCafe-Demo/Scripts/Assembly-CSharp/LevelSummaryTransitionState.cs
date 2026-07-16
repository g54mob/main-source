public class LevelSummaryTransitionState : TransitionState
{
	public override void OnEnter()
	{
		PopupMessageManager.HideAll();
		TransitionManager.TriggerTransitionEnter(2f, ShowSummary);
	}

	public override void OnExit()
	{
		LevelProgressionSummaryScreen.HideSummary();
	}

	public override void OnUpdate()
	{
	}

	public override bool ExitCondition()
	{
		return false;
	}

	private void ShowSummary()
	{
		if (WalletSystem.CheckBankruptcy())
		{
			LevelProgressionSummaryScreen.ShowBankruptcyScreen();
		}
		else
		{
			LevelProgressionSummaryScreen.ShowSummaryScreen();
		}
	}
}
