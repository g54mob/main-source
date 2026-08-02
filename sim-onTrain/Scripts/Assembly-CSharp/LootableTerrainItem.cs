using System.Collections;
using System.Collections.Generic;
using GPUInstancerPro.PrefabModule;
using Mirror;
using UnityEngine;
using UnityEngine.Localization;

public class LootableTerrainItem : BreakableObject, IInteractable
{
	private bool isActive = true;

	private bool isInteracting;

	private bool isCollected;

	private PlayerInventory player;

	private GPUIPrefab gpuiPrefab;

	public List<LootableItemEntry> lootableItems = new List<LootableItemEntry>();

	[SerializeField]
	private Transform interactionParent;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString takeLocalized;

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
		Register();
		objectServerData.isLootable = true;
		StartCoroutine(DelayedCheckNetworkStatus());
		RegisterWithGPUInstancer();
	}

	private IEnumerator DelayedCheckNetworkStatus()
	{
		yield return new WaitUntil(() => NetworkSceneObjectSpawner.Instance != null);
		if (NetworkServer.active)
		{
			if (!NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded)
			{
				yield return new WaitUntil(() => NetworkSceneObjectSpawner.Instance == null || NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded);
			}
			if (NetworkSceneObjectSpawner.Instance != null)
			{
				WorldObjectSaveData savedObjectState = NetworkSceneObjectSpawner.Instance.GetSavedObjectState(objectServerData.cellID, objectServerData.objectID);
				if (savedObjectState != null && savedObjectState.isDestroyed)
				{
					objectServerData.isDestroyed = true;
					objectServerData.isLootable = true;
					Unregister();
					NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
					if (gpuiPrefab != null)
					{
						GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
					}
					Object.Destroy(base.gameObject);
					yield break;
				}
			}
		}
		CheckNetworkStatus();
		yield return new WaitForSeconds(1f);
		CheckNetworkStatus();
	}

	private void RegisterWithGPUInstancer()
	{
		gpuiPrefab = GetComponent<GPUIPrefab>();
		if (gpuiPrefab != null)
		{
			GPUIPrefabAPI.AddPrefabInstance(gpuiPrefab);
		}
	}

	private void CheckNetworkStatus()
	{
		if (NetworkSceneObjectSpawner.Instance == null)
		{
			return;
		}
		ObjectServerData networkObjectState = NetworkSceneObjectSpawner.Instance.GetNetworkObjectState(objectServerData.cellID, objectServerData.objectID);
		if (networkObjectState != null && networkObjectState.isDestroyed)
		{
			if (gpuiPrefab != null)
			{
				GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
			}
			Object.Destroy(base.gameObject);
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (isCollected)
		{
			return;
		}
		if (NetworkSceneObjectSpawner.Instance != null)
		{
			ObjectServerData networkObjectState = NetworkSceneObjectSpawner.Instance.GetNetworkObjectState(objectServerData.cellID, objectServerData.objectID);
			if (networkObjectState != null && networkObjectState.isDestroyed)
			{
				if (gpuiPrefab != null)
				{
					GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
				}
				Object.Destroy(base.gameObject);
				return;
			}
		}
		if (isInteracting)
		{
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				Take(playerInventory);
			}
		}
		else
		{
			player = playerInventory;
			isInteracting = true;
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, playerInventory.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(takeLocalized, "Take"));
		}
	}

	public void StopInteract()
	{
		isInteracting = false;
		InteractionPanel.Instance.HideAllInteractions();
		if (player != null)
		{
			player.GetComponent<Interactor>().lastInteractable = null;
		}
	}

	public void Take(PlayerInventory player)
	{
		if (isCollected || lootableItems == null || lootableItems.Count == 0)
		{
			return;
		}
		isCollected = true;
		foreach (LootableItemEntry lootableItem in lootableItems)
		{
			if (!(lootableItem.collectableData != null) || lootableItem.count <= 0)
			{
				continue;
			}
			int availableSpaceForItem = player.GetAvailableSpaceForItem(lootableItem.collectableData);
			int num = Mathf.Min(lootableItem.count, availableSpaceForItem);
			int num2 = lootableItem.count - num;
			if (num > 0)
			{
				player.AddItemInventory(lootableItem.collectableData, num);
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("+" + num + " " + lootableItem.collectableData.GetLocalizedDisplayName(), lootableItem.collectableData);
			}
			if (num2 > 0)
			{
				DropOverflow(player, lootableItem.collectableData, num2);
				if (Singleton<UserMessagePanel>.Instance != null)
				{
					Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
				}
			}
			TaskEventManager.OnLootTaskCompleted.Invoke(lootableItem.collectableData, lootableItem.count);
		}
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.TakeItemGeneralSound);
		}
		GetComponent<Collider>().enabled = false;
		StopInteract();
		objectServerData.isDestroyed = true;
		objectServerData.isLootable = true;
		Unregister();
		if (gpuiPrefab != null)
		{
			GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
		}
		NetworkSceneObjectSpawner.Instance.NetworkobjectOwner = player.GetComponent<NetworkIdentity>();
		NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
		Object.Destroy(base.gameObject);
	}

	private void DropOverflow(PlayerInventory player, CollectableItemData item, int amount)
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
