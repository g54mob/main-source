using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class WaterPurifierWaterTaker : MonoBehaviour, IInteractable
{
	[Header("References")]
	public WaterPurifierController waterPurifier;

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	private bool isActive = true;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString takeCleanWaterLocalized;

	private bool isInteracting;

	private TSPlayerController player;

	private bool isProcessingAction;

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

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (waterPurifier == null)
		{
			return;
		}
		if (!isInteracting)
		{
			player = playerInventory.GetComponent<TSPlayerController>();
			isInteracting = true;
		}
		float cleanWaterAmount = waterPurifier.GetCleanWaterAmount();
		float maxCapacity = waterPurifier.maxCapacity;
		float minCleanWaterAmount = waterPurifier.minCleanWaterAmount;
		float cleanWaterPerUse = waterPurifier.cleanWaterPerUse;
		KeyCode interactKey = Singleton<UserPrefencesManager>.Instance.keyData.InteractKey;
		Transform objectTransform = ((interactionParent != null) ? interactionParent : base.transform);
		InventoryItem inventoryItem = null;
		if (cleanWaterAmount >= minCleanWaterAmount)
		{
			foreach (InventorySlotsData slotData in playerInventory.inventorySlotsData)
			{
				if (!(slotData.item == null) && waterPurifier.acceptableCleanWaterItems.Contains(slotData.item) && slotData.item.hasDurability && slotData.currentDurability < slotData.item.maxDurabilityCapacity)
				{
					InventorySlot inventorySlot = playerInventory.mainInventorySlots.Find((InventorySlot x) => x.inventoryID == slotData.slotID);
					if (inventorySlot != null && inventorySlot.InventoryItem != null)
					{
						inventoryItem = inventorySlot.InventoryItem;
					}
					break;
				}
			}
		}
		int num = Mathf.RoundToInt(minCleanWaterAmount);
		int num2 = Mathf.RoundToInt(cleanWaterPerUse);
		int num3 = Mathf.RoundToInt(cleanWaterAmount);
		int a = ((num2 > 0) ? (num3 / num2 * num2) : num3);
		int num4 = ((num3 >= num) ? Mathf.Max(a, num) : 0);
		int num5 = ((maxCapacity > 0f) ? Mathf.Clamp(Mathf.RoundToInt((float)num4 / maxCapacity * 100f), 0, 100) : 0);
		string localizedString = GetLocalizedString(takeCleanWaterLocalized, "Take Clean Water");
		if (inventoryItem != null)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(objectTransform, playerInventory.transform, interactKey, $"{localizedString} ({num5}%)");
			if (!Input.GetKeyDown(interactKey) || isProcessingAction)
			{
				return;
			}
			isProcessingAction = true;
			float num6 = cleanWaterAmount;
			float num7 = 0f;
			foreach (InventorySlotsData slotData2 in playerInventory.inventorySlotsData)
			{
				if (num6 <= 0f)
				{
					break;
				}
				if (!(slotData2.item == null) && waterPurifier.acceptableCleanWaterItems.Contains(slotData2.item) && slotData2.item.hasDurability && !(slotData2.currentDurability >= slotData2.item.maxDurabilityCapacity))
				{
					InventorySlot inventorySlot2 = playerInventory.mainInventorySlots.Find((InventorySlot x) => x.inventoryID == slotData2.slotID);
					if (!(inventorySlot2 == null) && !(inventorySlot2.InventoryItem == null))
					{
						float num8 = Singleton<ItemManager>.Instance.FillBottleWithCleanWater(inventorySlot2.InventoryItem, num6);
						num7 += num8;
						num6 -= num8;
					}
				}
			}
			if (num7 > 0f)
			{
				waterPurifier.CmdRemoveCleanWater(num7);
			}
			StartCoroutine(ResetProcessingFlag());
		}
		else
		{
			Color negativeColor = InteractionPanel.Instance.negativeColor;
			if (cleanWaterAmount >= minCleanWaterAmount)
			{
				InteractionPanel.Instance.ShowInteractionOverlay(objectTransform, playerInventory.transform, interactKey, $"{localizedString} ({num5}%)", hasHoldAction: false, 1f, null, negativeColor);
			}
			else
			{
				InteractionPanel.Instance.ShowInteractionOverlay(objectTransform, playerInventory.transform, interactKey, localizedString, hasHoldAction: false, 1f, null, negativeColor);
			}
		}
	}

	public void StopInteract()
	{
		isInteracting = false;
		InteractionPanel.Instance.HideAllInteractions();
		if (player != null)
		{
			Interactor component = player.GetComponent<Interactor>();
			if (component != null)
			{
				component.lastInteractable = null;
			}
		}
	}

	private IEnumerator ResetProcessingFlag()
	{
		yield return new WaitForSeconds(0.5f);
		isProcessingAction = false;
	}

	private string GetLocalizedString(LocalizedString localizedString, string fallback)
	{
		if (localizedString != null && !localizedString.IsEmpty)
		{
			string localizedString2 = localizedString.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString2))
			{
				return localizedString2;
			}
		}
		return fallback;
	}
}
