using System;
using System.Collections.Generic;

[Serializable]
public class FurnitureAssignmentIssue : SelectableNotification<Furniture>
{
	public FurnitureAssignmentIssue()
	{
	}

	public FurnitureAssignmentIssue(SDateTime date, params Furniture[] items)
		: base("FurnitureAssignmentErrorNotification".Loc(), "Furniture", date, NotificationManager.NotificationType.Issue, items)
	{
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
		return base.Items.Count == 0;
	}
}
