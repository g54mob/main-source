using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class FurnitureRepairNotification : SelectableNotificationNoDrop<Furniture>
{
	public enum RepairType
	{
		Computer = 0,
		Janitor = 1,
		IT = 2
	}

	public readonly RepairType RType;

	public FurnitureRepairNotification()
	{
	}

	public static string GetMessage(RepairType rt)
	{
		switch (rt)
		{
		case RepairType.Computer:
			return "ComputerWarning";
		case RepairType.IT:
			return "ITBrokeWarning";
		default:
			return "FurnitureBrokeWarning";
		}
	}

	public static string GetIcon(RepairType rt)
	{
		switch (rt)
		{
		case RepairType.Computer:
			return "Computer";
		case RepairType.IT:
			return "Wires";
		default:
			return "Furniture";
		}
	}

	public FurnitureRepairNotification(RepairType rt, params Furniture[] items)
		: base(GetMessage(rt).Loc(), GetIcon(rt), SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
		RType = rt;
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

	public override uint AggregateID()
	{
		return (uint)RType;
	}

	public override bool Refresh()
	{
		List<Furniture> list = base.Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Furniture furniture = list[i];
			if (furniture == null || furniture.upg == null || furniture.upg.Quality > 0.5f)
			{
				RemoveItem(furniture);
			}
		}
		return base.Items.Count == 0;
	}
}
