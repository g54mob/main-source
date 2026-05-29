using System;
using System.Collections.Generic;
using MyBox;
using UnityEngine;
using __Project__.Scripts.Computer.Vending_Machine;
using __Project__.Scripts.Vending_Machine;

public class VendingMachineManager : NoktaSingleton<VendingMachineManager>
{
	[Header("[-- Mini map --]")]
	[SerializeField]
	private Transform miniMapObjectParent;

	[SerializeField]
	private VendingMachineMiniMapObject vendingMachineMiniMapObject;

	[SerializeField]
	private List<VendingIdleStrategySO> m_VendingIdleStrategies;

	[SerializeField]
	private MiniMap m_MiniMap;

	private List<VendingData> m_VendingDatas;

	private List<VendingMachine> m_Vendings;

	private Dictionary<int, List<VendingSlot>> _mPlacedProducts;

	private VendingIdleStrategySO m_CurrentVendingIdleStrategy;

	public const int MAX_VENDING_MACHINE_COUNT = 20;

	public bool IsDLCActivated;

	private NetworkVendingMachineManager _networkVendingMachineManager;

	public Action onPurchasedVending;

	public Dictionary<int, VendingMachineMiniMapObject> MiniMapObjects;

	public List<VendingMachineComputerSlot> MyVendingMachineComputerSlots;

	private VendingData[] AllVendingData;

	public List<VendingMachine> Vendings => null;

	public List<VendingData> VendingDataList
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool HasAnythingPlaced => false;

	public Dictionary<int, List<VendingSlot>> PlacedProducts => null;

	public MiniMap MiniMap => null;

	public VendingIdleStrategySO CurrentVendingIdleStrategy => null;

	public NetworkVendingMachineManager NetworkVendingMachineManager => null;

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void DespawnSomeProducts()
	{
	}

	public void ChangeAllVendingData(int index, VendingData data)
	{
	}

	public void SetCurrentVendingIdleStrategy(bool _ = false)
	{
	}

	public VendingMachineMiniMapObject SpawnMiniMapObject(int uniqueID)
	{
		return null;
	}

	public VendingMachineMiniMapObject GetMiniMapObject(int uniqueID)
	{
		return null;
	}

	private void RepairComputerSlot()
	{
	}

	public void DeleteMiniMapObject(int uniqueID)
	{
	}

	public VendingMachine GetVendingMachine(int vendingUniqueID)
	{
		return null;
	}

	public void AddVendingSlot(int productID, VendingSlot newSlot)
	{
	}

	public void RemoveVendingSlot(int productID, VendingSlot slot)
	{
	}

	public int GetVendingSlots(int productID, bool hasProduct, List<VendingSlot> cachedSlots)
	{
		return 0;
	}

	public int GetLabeledEmptyVendingSlots(int productID, List<VendingSlot> cachedSlots)
	{
		return 0;
	}

	public VendingSlot GetRandomVendingSlot()
	{
		return null;
	}

	public VendingSlot GetRandomFilledVending()
	{
		return null;
	}

	public void AddVending(VendingMachine vending)
	{
	}

	public void RemoveVending(VendingMachine vending)
	{
	}

	public int GetVendingedProductCount(int productID)
	{
		return 0;
	}

	public int GetFirstUniqueID()
	{
		return 0;
	}

	private void LoadVendingData()
	{
	}

	public void AddVendingUIButtonToGlobalMap(VendingMachine vendingMachine)
	{
	}

	private void LoadFurnitureID(VendingData VendingData)
	{
	}

	public void SwitchVendingSystem(bool willEnable)
	{
	}

	public void AddVendingProcess(VendingMachine vending)
	{
	}

	public void RemoveVendingProcess(VendingMachine vending)
	{
	}
}
