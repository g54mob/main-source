using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class TrainWaterTank : MonoBehaviour, IInteractable
{
	public List<CollectableItemData> acceptableWaterItems = new List<CollectableItemData>();

	public float waterPerUse = 25f;

	private TrainController trainController;

	[SerializeField]
	private Transform interactionParent;

	[Header("Custom Interaction Distance")]
	[SerializeField]
	private float customInteractionDistance = 2f;

	private bool isProcessingAction;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString addCleanWaterLocalized;

	public InteractionPanel interactionPanel;

	public bool IsActive { get; set; }

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

	public float CustomInteractionDistance => customInteractionDistance;

	private void Start()
	{
		trainController = GetComponentInParent<TrainController>();
		if (trainController == null)
		{
			trainController = Object.FindObjectOfType<TrainController>();
		}
		interactionPanel = InteractionPanel.Instance;
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (isProcessingAction)
		{
			return;
		}
		InventorySlotsData inventorySlotsData = null;
		for (int i = 0; i < player.inventorySlotsData.Count; i++)
		{
			InventorySlotsData inventorySlotsData2 = player.inventorySlotsData[i];
			if (inventorySlotsData2.item != null && acceptableWaterItems.Contains(inventorySlotsData2.item) && inventorySlotsData2.currentDurability > 0f)
			{
				inventorySlotsData = inventorySlotsData2;
				break;
			}
		}
		bool num = inventorySlotsData != null;
		bool flag = trainController != null && trainController.GetWaterLevel() < 1f;
		ShowWaterUI(messageColor: (num && flag) ? InteractionPanel.Instance.positiveColor : InteractionPanel.Instance.negativeColor, player: player.transform);
		if (!(num && flag) || !Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
		{
			return;
		}
		InventorySlot inventorySlot = null;
		for (int j = 0; j < player.mainInventorySlots.Count; j++)
		{
			if (player.mainInventorySlots[j].inventoryID == inventorySlotsData.slotID)
			{
				inventorySlot = player.mainInventorySlots[j];
				break;
			}
		}
		InventoryItem inventoryItem = ((inventorySlot != null) ? inventorySlot.InventoryItem : null);
		if (!(inventoryItem == null))
		{
			float currentDurability = inventorySlotsData.currentDurability;
			float num2 = Mathf.Min(currentDurability, waterPerUse);
			Debug.Log($"[TrainWaterTank] Su ekleniyor - Mevcut Durability: {currentDurability} - Eklenecek: {num2}");
			isProcessingAction = true;
			float num3 = Singleton<ItemManager>.Instance.ConsumeWaterFromBottle(inventoryItem, num2);
			if (num3 > 0f)
			{
				float amount = num3 / waterPerUse * 0.1f;
				trainController.TryAddWater(amount);
				Debug.Log("[TrainWaterTank] Su başarıyla eklendi!");
				TaskEventManager.OnAddWaterToTrainTaskCompleted.Invoke();
			}
			else
			{
				Debug.LogWarning("[TrainWaterTank] Su tüketilemedi!");
			}
			StartCoroutine(ResetProcessingFlag());
		}
	}

	public void StopInteract()
	{
		HideWaterUI();
	}

	private void ShowWaterUI(Transform player, Color messageColor)
	{
		interactionPanel.ShowInteractionOverlay(InteractionParent, player, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(addCleanWaterLocalized, "Add Clean Water"), hasHoldAction: false, 1f, null, messageColor);
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

	private void HideWaterUI()
	{
		interactionPanel.HidePanels();
	}

	private IEnumerator ResetProcessingFlag()
	{
		yield return new WaitForSeconds(0.5f);
		isProcessingAction = false;
	}
}
