using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ConveyorBlockedNotification : SelectableNotificationNoDrop<Furniture>
{
	public ConveyorBlockedNotification()
	{
	}

	public ConveyorBlockedNotification(IEnumerable<Furniture> items)
		: base("PartInPortError".Loc(), "Box", SDateTime.Now(), NotificationManager.NotificationType.Issue, Array.Empty<Furniture>())
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
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture = list[i];
			if (furniture == null || !furniture.Conveyor.Blocked)
			{
				RemoveItem(furniture);
			}
		}
		return base.Items.Count == 0;
	}
}
