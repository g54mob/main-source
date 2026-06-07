using System;

[Serializable]
public class DigitalDistributionCutChange : NotificationMessage
{
	private DistributionPlatform _platform;

	public DigitalDistributionCutChange()
	{
	}

	public DigitalDistributionCutChange(DistributionPlatform p, float before, float after)
		: base("DistributionRateChange".LocColorAll(p.Owner, p.Software, before.ToPercent(), after.ToPercent()), "Distribution", NotificationManager.NotificationType.Neutral)
	{
		_platform = p;
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.digitalDistributionWindow.Show(true, _platform);
	}

	public override int GetCount()
	{
		return 1;
	}
}
