using System.Collections.Generic;
using MyBox;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Computer.Vending_Machine;

public class VendingMachineTracker : NoktaSingleton<VendingMachineTracker>
{
	[SerializeField]
	private GameObject trackerPanel;

	[SerializeField]
	private GameObject haveNotSlotPanel;

	[SerializeField]
	private GameObject noProductPanel;

	[SerializeField]
	private TextMeshProUGUI vendingMachineName;

	[SerializeField]
	private TextMeshProUGUI vendingMachineCollectedMoneyTmp;

	[SerializeField]
	private Button sellButton;

	[Separator]
	[SerializeField]
	private Transform trackerObjectContent;

	[SerializeField]
	private VendingMachineTrackerObject trackerObject;

	private List<VendingMachineTrackerObject> m_TrackerObjects;

	private int m_TrackedObjectUid;

	private VendingMachine _vendingMachine;

	public int TrackedObjectUid => 0;

	public List<VendingMachineTrackerObject> TrackerObjects => null;

	private void Awake()
	{
	}

	public void SellThisVending()
	{
	}

	public void SellProcess(VendingMachine vendingMachine)
	{
	}

	private bool IsOkSell()
	{
		return false;
	}

	private void Start()
	{
	}

	public void Initialize(VendingMachine vendingMachine)
	{
	}

	public void OpenTracker(VendingMachine vendingMachine)
	{
	}

	public void SetCollectedMoney(float collectedMoney)
	{
	}

	public void TrackerPanelClose()
	{
	}

	public VendingMachineComputerSlot CloseOrNearestOpenTracker()
	{
		return null;
	}

	private void SpawnTrackerObject(int itemID, int totalCount, int slotCount)
	{
	}

	public void SetCollectedMoneyTracker(int uniqueID, float collectedMoney)
	{
	}

	public void RefreshTrackedVendingStock(int uniqueID)
	{
	}

	public void ClientSell()
	{
	}
}
