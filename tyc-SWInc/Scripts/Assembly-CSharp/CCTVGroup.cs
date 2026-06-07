using System.Collections.Generic;
using System.Linq;

public class CCTVGroup
{
	public Dictionary<Furniture, int> CCTVs = new Dictionary<Furniture, int>();

	public HashSet<SurveillanceDesk> Desks = new HashSet<SurveillanceDesk>();

	public List<Furniture> FreeCCTVs = new List<Furniture>();

	public HashSet<Room> Rooms = new HashSet<Room>();

	public bool IsValid = true;

	public void Clear()
	{
		IsValid = true;
		CCTVs.Keys.Where((Furniture x) => x.CCGroup == this).ForEachEnum(delegate(Furniture x)
		{
			x.CCGroup = null;
		});
		Desks.Where((SurveillanceDesk x) => x.Furn.CCGroup == this).ForEachEnum(delegate(SurveillanceDesk x)
		{
			x.Furn.CCGroup = null;
			x.ClearSlots();
		});
		Rooms.Where((Room x) => x.CCGroup == this).ForEachEnum(delegate(Room x)
		{
			x.CCGroup = null;
		});
		CCTVs.Clear();
		Desks.Clear();
		FreeCCTVs.Clear();
		Rooms.Clear();
	}

	public void ClearRooms()
	{
		Rooms.Where((Room x) => x.CCGroup == this).ForEachEnum(delegate(Room x)
		{
			x.CCGroup = null;
		});
		Rooms.Clear();
	}

	public void ClearFurniture()
	{
		CCTVs.Keys.Where((Furniture x) => x.CCGroup == this).ForEachEnum(delegate(Furniture x)
		{
			x.CCGroup = null;
		});
		Desks.Where((SurveillanceDesk x) => x.Furn.CCGroup == this).ForEachEnum(delegate(SurveillanceDesk x)
		{
			x.Furn.CCGroup = null;
			x.ClearSlots();
		});
		CCTVs.Clear();
		Desks.Clear();
		FreeCCTVs.Clear();
	}

	public void UpdateFurniture()
	{
		ClearFurniture();
		foreach (Room room in Rooms)
		{
			if (room.AtriumChildren.Count > 0)
			{
				foreach (Room item in room.GetAtriumChildrenAndSelf())
				{
					UpdateFurnitureSub(item);
				}
			}
			else
			{
				UpdateFurnitureSub(room);
			}
		}
		foreach (KeyValuePair<Furniture, int> cCTV in CCTVs)
		{
			if (Desks.Count > 0)
			{
				HUD.Instance.CCTVNoConnection.Remove(cCTV.Key);
			}
			else
			{
				HUD.Instance.CCTVNoConnection.Add(cCTV.Key);
			}
		}
	}

	public void AssignCCs()
	{
		int num = FindNextFree(0);
		if (num <= -1)
		{
			return;
		}
		foreach (SurveillanceDesk desk in Desks)
		{
			if (desk.Furn.IsOn)
			{
				num = AssignCCs(desk, num);
				if (num == -1)
				{
					break;
				}
			}
		}
	}

	public int AssignCCs(SurveillanceDesk desk, int next = -1)
	{
		if (next == -1)
		{
			next = FindNextFree(0);
		}
		if (next > -1)
		{
			int freeSlot = desk.GetFreeSlot();
			while (freeSlot >= 0 && next > -1)
			{
				desk.AssignSlot(freeSlot, FreeCCTVs[next]);
				FreeCCTVs.RemoveAt(next);
				next = FindNextFree(next);
				freeSlot = desk.GetFreeSlot();
			}
		}
		return next;
	}

	private int FindNextFree(int idx)
	{
		for (int i = idx; i < FreeCCTVs.Count; i++)
		{
			if (!FreeCCTVs[i].upg.Broken)
			{
				return i;
			}
		}
		return -1;
	}

	private void UpdateFurnitureSub(Room room)
	{
		int value = SDateTime.Now().ToInt();
		HashList<Furniture> furniture = room.GetFurniture("CCTV");
		for (int i = 0; i < furniture.Count; i++)
		{
			Furniture furniture2 = furniture[i];
			furniture2.CCGroup = this;
			if (!CCTVs.ContainsKey(furniture2))
			{
				CCTVs.Add(furniture2, value);
				FreeCCTVs.Add(furniture2);
			}
		}
		furniture = room.GetFurniture("SurveillanceDesk");
		for (int j = 0; j < furniture.Count; j++)
		{
			Furniture furniture3 = furniture[j];
			furniture3.CCGroup = this;
			Desks.Add(furniture3.GetComponent<SurveillanceDesk>());
		}
	}
}
