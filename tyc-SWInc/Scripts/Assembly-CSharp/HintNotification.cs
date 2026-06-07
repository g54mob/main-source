using System;

[Serializable]
public class HintNotification : NotificationMessage
{
	public HintController.Hints Hint;

	public HintNotification()
	{
	}

	public HintNotification(HintController.Hints hint)
		: base(hint.ToString().LocColor(), "Info", NotificationManager.NotificationType.Hint)
	{
		Hint = hint;
	}

	public override bool AddItem(object item)
	{
		return false;
	}

	public override uint AggregateID()
	{
		return (uint)Hint;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override void OnDismissed()
	{
		Options.UpdateHint(Hint, false);
	}

	public override void RemoveItem(object item)
	{
	}
}
