using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class UnreachableFurn : SelectableNotification<Furniture>
{
	public UnreachableFurn()
	{
	}

	public UnreachableFurn(params Furniture[] items)
		: base("FurnitureBlockedStaff".Loc(), "Furniture", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
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
		List<Furniture> list = base.Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture = list[i];
			if (furniture == null || furniture.PathFailCount == 0 || furniture.IsUsed())
			{
				RemoveItem(furniture);
			}
		}
		return base.Items.Count == 0;
	}
}
