using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	public PlayerInventory inventory;

	public List<InventorySlot> inventorySlots = new List<InventorySlot>();

	public List<InventorySlot> addionalSlots = new List<InventorySlot>();

	[SerializeField]
	private CanvasGroup canvasGroup;

	public bool isBottomInventory;

	private bool isInitialized;

	public static bool isOpen;

	private void OnEnable()
	{
		Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.AddListener(delegate
		{
			SetPanelAttiributes();
		});
	}

	private void Initialize(TSPlayerController player)
	{
		DisablePanel();
		if (isInitialized)
		{
			return;
		}
		isInitialized = true;
		inventory = player.GetComponent<PlayerInventory>();
		inventory.OnCollectableCollected.AddListener(delegate
		{
			SetPanelAttiributes();
		});
		InventorySlot[] componentsInChildren = GetComponentsInChildren<InventorySlot>();
		foreach (InventorySlot item in componentsInChildren)
		{
			inventorySlots.Add(item);
		}
		componentsInChildren = Object.FindObjectsOfType<InventorySlot>();
		for (int num = 0; num < componentsInChildren.Length; num++)
		{
			componentsInChildren[num].InventoryItem.Initialize(this);
		}
		int num2 = 1;
		if (!isBottomInventory)
		{
			num2 = inventory.bottomPanelInventory.GetComponentsInChildren<InventorySlot>().Count() + 1;
		}
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.inventoryID = num2;
			inventorySlot.isBottomInventory = isBottomInventory;
			inventorySlot.InventoryItem.Initialize(this);
			num2++;
		}
		foreach (InventorySlot addionalSlot in addionalSlots)
		{
			inventorySlots.Add(addionalSlot);
			addionalSlot.InventoryItem.Initialize(this);
		}
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
		Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.RemoveListener(Initialize);
	}

	private void SetPanelAttiributes()
	{
	}

	public void ShowPanel()
	{
		EnablePanel();
	}

	public void HidePanel()
	{
		DisablePanel();
	}

	private void EnablePanel()
	{
		if (!isBottomInventory)
		{
			isOpen = true;
			canvasGroup.alpha = 1f;
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
	}

	private void DisablePanel()
	{
		if (!isBottomInventory)
		{
			isOpen = false;
			canvasGroup.alpha = 0f;
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}
	}
}
