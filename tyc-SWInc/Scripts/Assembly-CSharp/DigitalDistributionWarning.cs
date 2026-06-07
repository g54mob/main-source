using System;

[Serializable]
public class DigitalDistributionWarning : NotificationMessage
{
	public DigitalDistributionWarning()
		: base("DigitalDistributionWarning".Loc(), "Distribution", NotificationManager.NotificationType.Issue)
	{
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.digitalDistributionWindow.Show(true);
	}

	public override bool Refresh()
	{
		return GameSettings.Instance.MyCompany.GetPlatforms().Count > 0;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override int GetCount()
	{
		return 1;
	}
}
