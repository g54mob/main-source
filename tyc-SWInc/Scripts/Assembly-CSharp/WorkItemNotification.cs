using System;

[Serializable]
public class WorkItemNotification : NotificationMessage
{
	public WorkItem Item;

	public WorkItemNotification()
	{
	}

	public WorkItemNotification(WorkItem item, string msg, string icon, NotificationManager.NotificationType type)
		: base(msg, icon, type)
	{
		Item = item;
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
		GUIWorkItem guiItem = Item.guiItem;
		if (guiItem != null)
		{
			guiItem.Highlight();
		}
	}
}
