using System;
using System.Collections.Generic;

[Serializable]
public class SingleFurnitureNotification : SingleSelectableNotification<Furniture>
{
	public SingleFurnitureNotification()
	{
	}

	public SingleFurnitureNotification(Furniture furniture, string msg, string icon, SDateTime date, NotificationManager.NotificationType type)
		: base(furniture, msg, icon, date, type)
	{
	}

	public SingleFurnitureNotification(Furniture furniture, string msg, string details, string icon, SDateTime date, NotificationManager.NotificationType type)
		: base(furniture, msg, details, icon, date, type)
	{
	}

	public override IEnumerable<Furniture> GetSelectables()
	{
		return GameSettings.Instance.sRoomManager.AllFurniture;
	}
}
