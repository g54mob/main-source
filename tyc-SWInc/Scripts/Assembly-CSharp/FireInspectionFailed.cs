using System;

[Serializable]
public class FireInspectionFailed : NotificationMessage
{
	public readonly FireReport Report;

	public FireInspectionFailed()
	{
	}

	public FireInspectionFailed(FireReport report)
		: base("FireInspectionFailedMessage".Loc(report.Fee.Currency()), "Fire", NotificationManager.NotificationType.Warning)
	{
		Report = report.Copy();
	}

	public override int GetCount()
	{
		return 1;
	}

	public override void Goto(int idx = -1)
	{
		GameSettings.Instance.CreateFireReport(Report);
	}

	public override bool HasGoto()
	{
		return true;
	}
}
