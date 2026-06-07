using System;

[Serializable]
public class TaxNotification : NotificationMessage
{
	public TaxNotification()
	{
	}

	public TaxNotification(double tax, double fee, bool illegal)
		: base((illegal ? "TaxNotificationIllegal" : "TaxNotification").Loc(tax.Currency(), fee.Currency()), "Money", illegal ? NotificationManager.NotificationType.Warning : NotificationManager.NotificationType.Neutral)
	{
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override int GetCount()
	{
		return 1;
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.financeWindow.ShowTaxes();
	}
}
