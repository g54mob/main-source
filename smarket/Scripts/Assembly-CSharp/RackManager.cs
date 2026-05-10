using System;
using System.Collections.Generic;

public class RackManager : NoktaSingleton<RackManager>
{
	private List<RackData> m_RackDatas;

	private List<Rack> m_Racks;

	private List<int> m_FrozenBakeryProductIds;

	private Dictionary<int, List<RackSlot>> m_RackSlots;

	public int testID;

	public Action OnRackCountChanged;

	public List<RackData> Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<int> ProductsInRacks => null;

	public Dictionary<int, List<RackSlot>> RackSlots => null;

	private void Start()
	{
	}

	private void LoadSaveProgress()
	{
	}

	public void AddRackSlot(int productID, RackSlot newSlot)
	{
	}

	public void RemoveRackSlot(int productID, RackSlot slot)
	{
	}

	public void AddRack(Rack rack)
	{
	}

	public void RemoveRack(Rack rack)
	{
	}

	public RackSlot GetRackSlotHasMinBox(List<RackSlot> RackSlots)
	{
		return null;
	}

	public List<RackSlot> GetAllRackslots(int productID)
	{
		return null;
	}

	public int GetProductCountById(int productID)
	{
		return 0;
	}

	public List<RackSlot> GetRackSlotIncludeFreezeBox()
	{
		return null;
	}

	public RackSlot GetRackSlotThatHas(int productID)
	{
		return null;
	}

	public Box GetMinBoxAtRack(RackSlot targetRack)
	{
		return null;
	}

	public List<RackSlot> GetEmptyRacks(int ID)
	{
		return null;
	}

	public RackSlot GetRackSlotThatHasSpaceFor(int productID, int boxID, Restocker restocker)
	{
		return null;
	}

	public RackSlot GetRackSlotThatHasSpaceFor(int productID)
	{
		return null;
	}

	private void LoadRackData()
	{
	}
}
