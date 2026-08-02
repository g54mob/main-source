using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Localization;

public class StoryPaper : BreakableObject, IInteractable
{
	private bool isActive = true;

	private bool isInteracting;

	private bool isCollected;

	private PlayerInventory player;

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
					Object.Destroy(base.gameObject);
					yield break;
				}
			}
		}
		CheckNetworkStatus();
		yield return new WaitForSeconds(1f);
		CheckNetworkStatus();
	}

	private void CheckNetworkStatus()
	{
		if (!(NetworkSceneObjectSpawner.Instance == null))
		{
			ObjectServerData networkObjectState = NetworkSceneObjectSpawner.Instance.GetNetworkObjectState(objectServerData.cellID, objectServerData.objectID);
			if (networkObjectState != null && networkObjectState.isDestroyed)
			{
				Object.Destroy(base.gameObject);
			}
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
			if (lootableItem.collectableData != null)
			{
				if (CollectableDataSaver.Instance != null)
				{
					CollectableDataSaver.Instance.SetItemLearned(lootableItem.collectableData.itemName, learned: true);
				}
				TaskEventManager.OnLootTaskCompleted.Invoke(lootableItem.collectableData, lootableItem.count);
			}
		}
		GetComponent<Collider>().enabled = false;
		StopInteract();
		objectServerData.isDestroyed = true;
		objectServerData.isLootable = true;
		Unregister();
		NetworkSceneObjectSpawner.Instance.NetworkobjectOwner = player.GetComponent<NetworkIdentity>();
		NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
		Object.Destroy(base.gameObject);
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
