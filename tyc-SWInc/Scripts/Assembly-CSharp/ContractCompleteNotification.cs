using System;

[Serializable]
public class ContractCompleteNotification : NotificationMessage
{
	public ContractResult Result;

	public ContractCompleteNotification()
	{
	}

	public ContractCompleteNotification(ContractResult result, uint missing)
	{
		Result = result;
		Message = (Result.Contract.Hardware ? "ContractFinishHardware".Loc(result.Status.ToString().Loc(), result.FinalResult.Currency(), missing) : "ContractFinish3".Loc(result.Status.ToString().Loc(), result.FinalResult.Currency(), ContractWindow.QualityAssess(Result).Loc().ToLower()));
		Icon = "Paper";
		Type = ((result.Result < 0f) ? NotificationManager.NotificationType.Warning : NotificationManager.NotificationType.Good);
		Date = SDateTime.Now();
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.contractWindow.Show(false);
		HUD.Instance.contractWindow.SetTab(false);
		HUD.Instance.contractWindow.ContractResults.Select(Result);
	}

	public override int GetCount()
	{
		return 1;
	}

	public override bool HasGoto()
	{
		return true;
	}
}
