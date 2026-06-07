using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class NewUnlockNotification : NotificationMessage
{
	public List<UnlockChecker.UnlockItem> Items;

	public NewUnlockNotification()
	{
	}

	public NewUnlockNotification(List<UnlockChecker.UnlockItem> items)
	{
		Items = items.ToList();
		string text = Newspaper.MakeList((from x in items.Select((UnlockChecker.UnlockItem x) => x.Type).Distinct()
			select x.ToString().Loc()).ToArray(), true, true);
		Message = "NewUnlockNotification".Loc(text);
		Icon = "Lightbulb";
		Type = NotificationManager.NotificationType.Good;
		Date = SDateTime.Now();
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.newUnlockWindow.Show(Items);
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
