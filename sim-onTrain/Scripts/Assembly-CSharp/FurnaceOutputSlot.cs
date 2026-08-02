using UnityEngine;
using UnityEngine.Localization;

public class FurnaceOutputSlot : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Transform interactionParent;

	private bool isActive = true;

	private FurnaceController furnaceController;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString collectLocalized;

	private int slotIndex = -1;

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

	private FurnaceController FurnaceController
	{
		get
		{
			if (!(furnaceController == null))
			{
				return furnaceController;
			}
			return GetComponentInParent<FurnaceController>();
		}
	}

	private void Start()
	{
		if (FurnaceController != null)
		{
			slotIndex = GetOutputSlotIndex();
		}
	}

	private int GetOutputSlotIndex()
	{
		for (int i = 0; i < FurnaceController.outputPoints.Count; i++)
		{
			if (base.transform == FurnaceController.outputPoints[i] || base.transform.IsChildOf(FurnaceController.outputPoints[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (FurnaceController == null || slotIndex == -1 || slotIndex >= FurnaceController.completedQueue.Count)
		{
			return;
		}
		string text = FurnaceController.completedQueue[slotIndex];
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
		if (collectableItemFromName != null)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(collectLocalized, "Collect") + " " + collectableItemFromName.GetLocalizedDisplayName());
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				CollectCompletedItem(playerInventory);
				InteractionPanel.Instance.HideAllInteractions();
			}
		}
	}

	private void CollectCompletedItem(PlayerInventory playerInventory)
	{
		if (slotIndex >= FurnaceController.completedQueue.Count)
		{
			return;
		}
		string text = FurnaceController.completedQueue[slotIndex];
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
		if (collectableItemFromName == null)
		{
			return;
		}
		int availableSpaceForItem = playerInventory.GetAvailableSpaceForItem(collectableItemFromName);
		int num = ((availableSpaceForItem < 1) ? 1 : 0);
		Debug.Log($"[FURNACE] CollectCompleted - item: {collectableItemFromName.itemName} | availableSpace: {availableSpaceForItem} | overflow: {num}");
		if (availableSpaceForItem >= 1)
		{
			playerInventory.AddItemInventory(collectableItemFromName, 1);
		}
		if (num > 0)
		{
			DropItemToGround(playerInventory, collectableItemFromName, num);
			if (Singleton<UserMessagePanel>.Instance != null)
			{
				Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
			}
		}
		TaskEventManager.OnCollectIngotTaskCompleted.Invoke(collectableItemFromName, 1);
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.TakeItemGeneralSound);
		}
		FurnaceController.TryTakeCompletedItem(1);
	}

	public void StopInteract()
	{
		InteractionPanel.Instance.HideAllInteractions();
	}

	private void DropItemToGround(PlayerInventory player, CollectableItemData item, int amount)
	{
		Transform transform = player.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.position + transform.forward;
		Vector3 spawnForward = transform.position + transform.forward * 2f;
		if (item.hasDurability)
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(item.itemName, amount, spawnPoint, spawnForward, item.startDurability);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(item.itemName, amount, spawnPoint, spawnForward);
		}
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
