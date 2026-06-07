using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class PrinterBlockedNotification : SelectableNotificationNoDrop<Furniture>
{
	public PrinterBlockedNotification()
	{
	}

	public PrinterBlockedNotification(IEnumerable<Furniture> items)
		: base("PrinterOutputBlock".Loc(), "Box", SDateTime.Now(), NotificationManager.NotificationType.Issue, Array.Empty<Furniture>())
	{
		foreach (Furniture item in items)
		{
			_items.Add(item);
			_serializedItems.Add(GetID(item));
		}
		_deserialized = true;
	}

	public override IEnumerable<Furniture> GetObjects()
	{
		return GameSettings.Instance.sRoomManager.AllFurniture;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override bool Refresh()
	{
		List<Furniture> list = base.Items.ToList();
		SDateTime now = SDateTime.Now();
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture = list[i];
			if (furniture == null || SDateTime.GetHours(furniture.Printer.LastBlockTime, now) > 6f)
			{
				RemoveItem(furniture);
			}
		}
		return base.Items.Count == 0;
	}
}
