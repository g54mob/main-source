using System.Collections;
using UnityEngine;

public class FurnacePlacerController : MonoBehaviour, IInteractable
{
	[Header("Interaction Settings")]
	public FurnaceInteractionType type;

	private FurnaceController furnace;

	private bool isActive = true;

	private bool isInteracting;

	private InGameUIManager uIManager;

	private TSPlayerController player;

	[SerializeField]
	private Transform interactionParent;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	private void Start()
	{
		uIManager = Object.FindObjectOfType<InGameUIManager>(includeInactive: true);
		furnace = GetComponentInParent<FurnaceController>();
		if (furnace == null)
		{
			Debug.LogError("FurnaceController bulunamadı! FurnacePlacerController sadece FurnaceController'ın child'ı olarak çalışır.");
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (!(furnace == null))
		{
			player = playerInventory.GetComponent<TSPlayerController>();
			isInteracting = true;
			CollectableItemData selectedSlotItemData = playerInventory.GetComponent<EastUpPlayerItemManager>().GetSelectedSlotItemData();
			CollectableItemData upgradeableItemInInventory = furnace.GetUpgradeableItemInInventory(playerInventory);
			string interactionMessage = GetInteractionMessage(selectedSlotItemData, upgradeableItemInInventory);
			Color interactionColor = GetInteractionColor(selectedSlotItemData, upgradeableItemInInventory);
			if (!string.IsNullOrEmpty(interactionMessage))
			{
				InteractionPanel.Instance.ShowInteractionOverlay(InteractionParent, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, interactionMessage, hasHoldAction: false, 1f, null, interactionColor);
			}
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				HandleInteraction(playerInventory);
			}
		}
	}

	private string GetInteractionMessage(CollectableItemData selectedItem, CollectableItemData oreInInventory)
	{
		switch (type)
		{
		case FurnaceInteractionType.Fuel:
			if (selectedItem != null && furnace.IsFuelItem(selectedItem))
			{
				if (furnace.CanAddFuel(selectedItem, 1))
				{
					return "To Add " + selectedItem.itemName;
				}
				string cannotAddReason2 = furnace.GetCannotAddReason(selectedItem);
				if (!string.IsNullOrEmpty(cannotAddReason2))
				{
					return cannotAddReason2;
				}
				return "Cannot Add " + selectedItem.itemName;
			}
			break;
		case FurnaceInteractionType.Output:
			if (oreInInventory != null)
			{
				if (furnace.CanAddUpgradeableItem(oreInInventory, 1))
				{
					return "To Add " + oreInInventory.itemName;
				}
				string cannotAddReason = furnace.GetCannotAddReason(oreInInventory);
				if (!string.IsNullOrEmpty(cannotAddReason))
				{
					return cannotAddReason;
				}
				return "Cannot Add " + oreInInventory.itemName;
			}
			if (furnace.HasCompletedItems())
			{
				CollectableItemData completedItemData = furnace.GetCompletedItemData();
				int completedItemCount = furnace.GetCompletedItemCount();
				if (completedItemData != null)
				{
					return "To Take " + completedItemData.itemName + " (" + completedItemCount + ")";
				}
			}
			else if (!string.IsNullOrEmpty(furnace.completedItemName) && furnace.completedItemCount > 0)
			{
				return "To Take " + furnace.completedItemName + " (" + furnace.completedItemCount + ")";
			}
			break;
		}
		return GetDefaultMessage();
	}

	private string GetDefaultMessage()
	{
		return type switch
		{
			FurnaceInteractionType.Fuel => "Add Fuel Here", 
			FurnaceInteractionType.Output => "Add Items or Take Results", 
			_ => "", 
		};
	}

	private Color GetInteractionColor(CollectableItemData selectedItem, CollectableItemData oreInInventory)
	{
		Color positiveColor = InteractionPanel.Instance.positiveColor;
		Color negativeColor = InteractionPanel.Instance.negativeColor;
		switch (type)
		{
		case FurnaceInteractionType.Fuel:
			if (selectedItem != null && furnace.IsFuelItem(selectedItem) && furnace.CanAddFuel(selectedItem, 1))
			{
				return positiveColor;
			}
			return negativeColor;
		case FurnaceInteractionType.Output:
			if (oreInInventory != null && furnace.CanAddUpgradeableItem(oreInInventory, 1))
			{
				return positiveColor;
			}
			if (furnace.HasCompletedItems() || furnace.completedItemCount > 0)
			{
				return positiveColor;
			}
			return negativeColor;
		default:
			return positiveColor;
		}
	}

	private void HandleInteraction(PlayerInventory playerInventory)
	{
		CollectableItemData selectedSlotItemData = playerInventory.GetComponent<EastUpPlayerItemManager>().GetSelectedSlotItemData();
		CollectableItemData upgradeableItemInInventory = furnace.GetUpgradeableItemInInventory(playerInventory);
		EastUpPlayerItemManager component = playerInventory.GetComponent<EastUpPlayerItemManager>();
		switch (type)
		{
		case FurnaceInteractionType.Fuel:
			HandleFuelInteraction(selectedSlotItemData, component, playerInventory);
			break;
		case FurnaceInteractionType.Output:
			HandleOutputInteraction(selectedSlotItemData, upgradeableItemInInventory, component, playerInventory);
			break;
		}
	}

	private void HandleFuelInteraction(CollectableItemData selectedItem, EastUpPlayerItemManager itemChooser, PlayerInventory playerInventory)
	{
		if (selectedItem == null || !furnace.IsFuelItem(selectedItem))
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Bu item yakıt olarak kullanılamaz");
			StopInteract();
			return;
		}
		int totalItemCount = playerInventory.GetTotalItemCount(selectedItem);
		if (totalItemCount <= 0)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Item miktarı yetersiz");
			StopInteract();
			return;
		}
		int a = ((!Input.GetKey(KeyCode.LeftControl)) ? 1 : totalItemCount);
		a = Mathf.Min(a, totalItemCount);
		if (!furnace.CanAddFuel(selectedItem, a))
		{
			string cannotAddReason = furnace.GetCannotAddReason(selectedItem);
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel(string.IsNullOrEmpty(cannotAddReason) ? "Yakıt eklenemedi" : cannotAddReason);
			StopInteract();
		}
		else
		{
			furnace.TryAddFuel(selectedItem.itemName, a);
			Debug.Log($"FurnacePlacer: TryAddFuel çağrıldı - {selectedItem.itemName} x{a}");
			playerInventory.AddItemInventory(selectedItem, -a);
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Eklendi: " + a + " " + selectedItem.itemName);
			StopInteract();
		}
	}

	private void HandleOutputInteraction(CollectableItemData selectedItem, CollectableItemData oreInInventory, EastUpPlayerItemManager itemChooser, PlayerInventory playerInventory)
	{
		if (furnace.HasCompletedItems() || furnace.completedItemCount > 0)
		{
			HandleCompletedItemInteraction(playerInventory);
			return;
		}
		if (oreInInventory != null)
		{
			HandleUpgradeableItemInteraction(oreInInventory, itemChooser, playerInventory);
			return;
		}
		Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Alınacak item yok veya envanterde işlenebilir item yok");
		StopInteract();
	}

	private void HandleUpgradeableItemInteraction(CollectableItemData selectedItem, EastUpPlayerItemManager itemChooser, PlayerInventory playerInventory)
	{
		int totalItemCount = playerInventory.GetTotalItemCount(selectedItem);
		if (totalItemCount <= 0)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Item miktarı yetersiz");
			StopInteract();
			return;
		}
		int a = ((!Input.GetKey(KeyCode.LeftControl)) ? 1 : totalItemCount);
		a = Mathf.Min(a, totalItemCount);
		if (!furnace.CanAddUpgradeableItem(selectedItem, a))
		{
			string cannotAddReason = furnace.GetCannotAddReason(selectedItem);
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel(string.IsNullOrEmpty(cannotAddReason) ? "Item eklenemedi" : cannotAddReason);
			StopInteract();
		}
		else
		{
			furnace.TryAddUpgradeableItem(selectedItem.itemName, a);
			Debug.Log($"FurnacePlacer: TryAddUpgradeableItem çağrıldı - {selectedItem.itemName} x{a}");
			playerInventory.AddItemInventory(selectedItem, -a);
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Eklendi: " + a + " " + selectedItem.itemName);
			StopInteract();
		}
	}

	private void HandleCompletedItemInteraction(PlayerInventory playerInventory)
	{
		if (!furnace.HasCompletedItems() && furnace.completedItemCount <= 0)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Alınacak item yok");
			StopInteract();
			return;
		}
		CollectableItemData collectableItemData = null;
		int num = 0;
		if (furnace.HasCompletedItems())
		{
			collectableItemData = furnace.GetCompletedItemData();
			num = furnace.GetCompletedItemCount();
		}
		else if (!string.IsNullOrEmpty(furnace.completedItemName))
		{
			collectableItemData = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(furnace.completedItemName);
			num = furnace.completedItemCount;
		}
		if (collectableItemData == null || num <= 0)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Alınacak item bulunamadı");
			StopInteract();
			return;
		}
		int a = ((!Input.GetKey(KeyCode.LeftControl)) ? 1 : num);
		a = Mathf.Min(a, num);
		furnace.TryTakeCompletedItem(a);
		StartCoroutine(DelayedAddToInventory(playerInventory, collectableItemData, a));
	}

	private IEnumerator DelayedAddToInventory(PlayerInventory playerInventory, CollectableItemData itemData, int count)
	{
		yield return new WaitForSeconds(0.1f);
		playerInventory.AddItemInventory(itemData, count);
		Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Alındı: " + count + " " + itemData.itemName);
		StopInteract();
	}

	public void StopInteract()
	{
		isInteracting = false;
		if (uIManager != null)
		{
			uIManager.CloseUserInteractPanel();
		}
		if (player != null)
		{
			Interactor component = player.GetComponent<Interactor>();
			if (component != null)
			{
				component.lastInteractable = null;
			}
		}
	}

	private void OnDisable()
	{
		StopInteract();
	}
}
