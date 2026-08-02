using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WaterInteractable : MonoBehaviour, IInteractable
{
	public List<CollectableItemData> acceptableLiquids = new List<CollectableItemData>();

	[Header("Water Type")]
	[Tooltip("Is this a clean water source? If false, it's dirty water")]
	public bool isCleanWaterSource;

	[SerializeField]
	private Transform interactionParent;

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

	public bool IsActive { get; set; }

	private void Start()
	{
		DOVirtual.DelayedCall(5f, delegate
		{
			GetComponent<BoxCollider>().enabled = true;
		});
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (isProcessingAction)
		{
			return;
		}
		EastUpPlayerItemManager component = player.GetComponent<EastUpPlayerItemManager>();
		if (component.lastSelectedSlot == null || component.lastSelectedSlot.InventoryItem == null || component.lastSelectedSlot.InventoryItem.collectableItemData == null)
		{
			return;
		}
		CollectableItemData collectableItemData = component.lastSelectedSlot.InventoryItem.collectableItemData;
		InventoryItem inventoryItem = component.lastSelectedSlot.InventoryItem;
		if (!acceptableLiquids.Contains(collectableItemData))
		{
			return;
		}
		WaterBottleData waterBottleData = Singleton<ItemManager>.Instance.GetWaterBottleData(collectableItemData);
		if (!inventoryItem.HasDurability() || inventoryItem.IsDurabilityFull())
		{
			return;
		}
		InteractionPanel.Instance.ShowInteractionOverlayAtHitPoint(hitPoint, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, "Fill Water");
		if (!Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
		{
			return;
		}
		isProcessingAction = true;
		inventoryItem.RepairDurability();
		if (waterBottleData != null)
		{
			if (collectableItemData == waterBottleData.emptyBottle)
			{
				if (isCleanWaterSource)
				{
					Singleton<ItemManager>.Instance.TransformBottleToClean(inventoryItem, collectableItemData);
					TaskEventManager.OnCollectCleanWaterTaskCompleted.Invoke(1);
				}
				else
				{
					Singleton<ItemManager>.Instance.TransformBottleToDirty(inventoryItem, collectableItemData);
					TaskEventManager.OnCollectDirtyWaterTaskCompleted.Invoke(1);
				}
			}
			else if (collectableItemData == waterBottleData.dirtyWaterBottle && isCleanWaterSource)
			{
				Singleton<ItemManager>.Instance.TransformBottleToClean(inventoryItem, collectableItemData);
				TaskEventManager.OnCollectCleanWaterTaskCompleted.Invoke(1);
			}
		}
		StopInteract();
		StartCoroutine(ResetProcessingFlag());
	}

	public void StopInteract()
	{
		InteractionPanel.Instance.HideInteraction();
	}

	private IEnumerator ResetProcessingFlag()
	{
		yield return new WaitForSeconds(0.5f);
		isProcessingAction = false;
	}
}
