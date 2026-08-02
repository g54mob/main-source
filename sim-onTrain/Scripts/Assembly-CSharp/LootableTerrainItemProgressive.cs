using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class LootableTerrainItemProgressive : BreakableObject, IInteractable
{
	private bool isActive = true;

	[SerializeField]
	private Transform interactionParent;

	[Header("Loot Items")]
	public List<LootableItemEntry> lootableItems = new List<LootableItemEntry>();

	[Header("Loot Timing")]
	[Tooltip("Total time in seconds to loot all items")]
	[SerializeField]
	private float totalLootingTime = 10f;

	[Tooltip("Seconds between each loot tick")]
	[SerializeField]
	private float lootInterval = 2f;

	private int totalTicks;

	private int completedTicks;

	private bool isInteracting;

	private bool isFullyLooted;

	private PlayerInventory player;

	private List<LootableItemEntry> remainingItems = new List<LootableItemEntry>();

	private InteractionData currentLootInteraction;

	private Coroutine soundCoroutine;

	private Coroutine tickCoroutine;

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

	private bool ShouldLog => objectServerData.objectID == 5;

	private void Start()
	{
		Register();
		objectServerData.isLootable = true;
		totalTicks = Mathf.Max(1, Mathf.RoundToInt(totalLootingTime / lootInterval));
		InitializeRemainingItems();
		if (objectServerData.health > 0f)
		{
			int num = Mathf.RoundToInt(objectServerData.health);
			if (num >= totalTicks)
			{
				if (ShouldLog)
				{
					Debug.Log($"[ProgressiveItem] Fully looted from saved state ({num}/{totalTicks}), destroying (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
				}
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			if (num > 0)
			{
				ApplyNetworkState(num);
				if (ShouldLog)
				{
					Debug.Log($"[ProgressiveItem] Restored from saved state: {num}/{totalTicks} ticks completed, {GetRemainingItemCount()} items remaining (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
				}
			}
		}
		if (ShouldLog)
		{
			Debug.Log($"[ProgressiveItem] Initialized: {GetTotalItemCount()} total items, {totalTicks} ticks, completedTicks={completedTicks}, remaining={GetRemainingItemCount()} (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
		}
		StartCoroutine(DelayedCheckNetworkStatus());
	}

	private void InitializeRemainingItems()
	{
		remainingItems.Clear();
		foreach (LootableItemEntry lootableItem in lootableItems)
		{
			if (lootableItem.collectableData != null && lootableItem.count > 0)
			{
				remainingItems.Add(new LootableItemEntry
				{
					collectableData = lootableItem.collectableData,
					count = lootableItem.count
				});
			}
		}
	}

	private int GetTotalItemCount()
	{
		int num = 0;
		foreach (LootableItemEntry lootableItem in lootableItems)
		{
			if (lootableItem.collectableData != null)
			{
				num += lootableItem.count;
			}
		}
		return num;
	}

	private int GetRemainingItemCount()
	{
		int num = 0;
		for (int i = 0; i < remainingItems.Count; i++)
		{
			num += remainingItems[i].count;
		}
		return num;
	}

	private IEnumerator DelayedCheckNetworkStatus()
	{
		yield return new WaitUntil(() => NetworkSceneObjectSpawner.Instance != null);
		if (NetworkServer.active)
		{
			if (!NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded)
			{
				if (ShouldLog)
				{
					Debug.Log($"[ProgressiveItem] Waiting for save data to load... (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
				}
				yield return new WaitUntil(() => NetworkSceneObjectSpawner.Instance == null || NetworkSceneObjectSpawner.Instance.IsSaveDataLoaded);
			}
			if (objectServerData.health <= 0f && completedTicks == 0 && NetworkSceneObjectSpawner.Instance != null)
			{
				WorldObjectSaveData savedObjectState = NetworkSceneObjectSpawner.Instance.GetSavedObjectState(objectServerData.cellID, objectServerData.objectID);
				if (savedObjectState != null)
				{
					if (savedObjectState.isDestroyed)
					{
						if (ShouldLog)
						{
							Debug.Log($"[ProgressiveItem] Destroyed from delayed save check (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
						}
						objectServerData.isDestroyed = true;
						objectServerData.isLootable = true;
						Unregister();
						NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
						UnityEngine.Object.Destroy(base.gameObject);
						yield break;
					}
					if (savedObjectState.health > 0f)
					{
						objectServerData.health = savedObjectState.health;
						int num = Mathf.RoundToInt(savedObjectState.health);
						if (num >= totalTicks)
						{
							if (ShouldLog)
							{
								Debug.Log($"[ProgressiveItem] Fully looted from delayed save check ({num}/{totalTicks}), destroying (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
							}
							objectServerData.isDestroyed = true;
							objectServerData.isLootable = true;
							Unregister();
							NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
							UnityEngine.Object.Destroy(base.gameObject);
							yield break;
						}
						ApplyNetworkState(num);
						NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
						if (ShouldLog)
						{
							Debug.Log($"[ProgressiveItem] Restored from delayed save check: {num}/{totalTicks} ticks, {GetRemainingItemCount()} remaining (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
						}
					}
				}
			}
		}
		CheckNetworkStatus();
		yield return new WaitForSeconds(1f);
		CheckNetworkStatus();
	}

	private void CheckNetworkStatus()
	{
		if (NetworkSceneObjectSpawner.Instance == null || NetworkSceneObjectSpawner.Instance.changedObjectServerDatas == null)
		{
			return;
		}
		foreach (ObjectServerData changedObjectServerData in NetworkSceneObjectSpawner.Instance.changedObjectServerDatas)
		{
			if (changedObjectServerData.cellID != objectServerData.cellID || changedObjectServerData.objectID != objectServerData.objectID)
			{
				continue;
			}
			if (changedObjectServerData.isDestroyed)
			{
				if (ShouldLog)
				{
					Debug.Log($"[ProgressiveItem] Already fully looted in network, destroying (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
				}
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			int num = Mathf.RoundToInt(changedObjectServerData.health);
			if (num > 0)
			{
				if (ShouldLog)
				{
					Debug.Log($"[ProgressiveItem] Network state: {num}/{totalTicks} ticks already completed");
				}
				ApplyNetworkState(num);
			}
			break;
		}
		if (completedTicks >= totalTicks || GetRemainingItemCount() <= 0)
		{
			if (ShouldLog)
			{
				Debug.Log("[ProgressiveItem] All items looted after network sync, destroying");
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void SyncWithNetworkState()
	{
		if (NetworkSceneObjectSpawner.Instance == null || NetworkSceneObjectSpawner.Instance.changedObjectServerDatas == null)
		{
			return;
		}
		foreach (ObjectServerData changedObjectServerData in NetworkSceneObjectSpawner.Instance.changedObjectServerDatas)
		{
			if (changedObjectServerData.cellID != objectServerData.cellID || changedObjectServerData.objectID != objectServerData.objectID)
			{
				continue;
			}
			if (changedObjectServerData.isDestroyed)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				break;
			}
			int num = Mathf.RoundToInt(changedObjectServerData.health);
			if (num > completedTicks)
			{
				if (ShouldLog)
				{
					Debug.Log($"[ProgressiveItem] Syncing before interact: {completedTicks} -> {num} ticks");
				}
				ApplyNetworkState(num);
			}
			break;
		}
	}

	public void UpdateHealthFromServer(float newHealth)
	{
		int num = Mathf.RoundToInt(newHealth);
		if (num > completedTicks)
		{
			if (ShouldLog)
			{
				Debug.Log($"[ProgressiveItem] Server update: {completedTicks} -> {num} ticks");
			}
			ApplyNetworkState(num);
		}
	}

	private void ApplyNetworkState(int networkCompletedTicks)
	{
		InitializeRemainingItems();
		for (int i = 0; i < networkCompletedTicks; i++)
		{
			int remainingItemCount = GetRemainingItemCount();
			if (remainingItemCount <= 0)
			{
				break;
			}
			int num = Mathf.Max(1, totalTicks - i);
			System.Random tickRandom = GetTickRandom(i);
			int count;
			if (num <= 1)
			{
				count = remainingItemCount;
			}
			else
			{
				float num2 = (float)remainingItemCount / (float)num;
				float num3 = num2 * 0.6f;
				float num4 = num2 * 1.4f;
				count = Mathf.RoundToInt((float)(tickRandom.NextDouble() * (double)(num4 - num3) + (double)num3));
				count = Mathf.Clamp(count, 1, remainingItemCount);
			}
			RemoveRandomItems(count, tickRandom);
		}
		completedTicks = networkCompletedTicks;
		if (ShouldLog)
		{
			Debug.Log($"[ProgressiveItem] State applied: {completedTicks}/{totalTicks} ticks, {GetRemainingItemCount()} items remaining");
		}
	}

	private System.Random GetTickRandom(int tickIndex)
	{
		return new System.Random(objectServerData.cellID * 10007 + objectServerData.objectID * 31 + tickIndex * 7919);
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (isFullyLooted)
		{
			return;
		}
		if (NetworkSceneObjectSpawner.Instance != null && NetworkSceneObjectSpawner.Instance.changedObjectServerDatas != null)
		{
			foreach (ObjectServerData changedObjectServerData in NetworkSceneObjectSpawner.Instance.changedObjectServerDatas)
			{
				if (changedObjectServerData.cellID == objectServerData.cellID && changedObjectServerData.objectID == objectServerData.objectID)
				{
					if (changedObjectServerData.isDestroyed)
					{
						UnityEngine.Object.Destroy(base.gameObject);
						return;
					}
					break;
				}
			}
		}
		if (isInteracting)
		{
			return;
		}
		SyncWithNetworkState();
		if (completedTicks >= totalTicks || GetRemainingItemCount() <= 0)
		{
			if (ShouldLog)
			{
				Debug.Log("[ProgressiveItem] No items remaining after sync, finishing");
			}
			FinishLooting(playerInventory);
			return;
		}
		player = playerInventory;
		isInteracting = true;
		float num = (float)(totalTicks - completedTicks) * lootInterval;
		if (ShouldLog)
		{
			Debug.Log($"[ProgressiveItem] Loot started: {completedTicks}/{totalTicks} ticks done, {GetRemainingItemCount()} items left, ~{num}s remaining");
		}
		currentLootInteraction = new InteractionData(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, "Loot", hasHoldAction: true, num, OnAllTicksComplete, OnLootKeyDown, OnLootKeyUp);
		List<InteractionData> interactionDataList = new List<InteractionData> { currentLootInteraction };
		InteractionPanel.Instance.ShowMultipleInteractionOnOverlay(base.transform, playerInventory.transform, interactionDataList);
	}

	public void StopInteract()
	{
		isInteracting = false;
		StopTickCoroutine();
		StopSoundLoop();
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.overlayCanvasCG.alpha = 1f;
			InteractionPanel.Instance.HideInteraction();
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

	private void OnLootKeyDown()
	{
		StartTickCoroutine();
		StartSoundLoop();
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.overlayCanvasCG.alpha = 0f;
		}
	}

	private void OnLootKeyUp()
	{
		StopTickCoroutine();
		StopSoundLoop();
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.overlayCanvasCG.alpha = 1f;
		}
		if (currentLootInteraction != null && !isFullyLooted)
		{
			float holdDuration = (float)(totalTicks - completedTicks) * lootInterval;
			currentLootInteraction.holdDuration = holdDuration;
		}
	}

	private void OnAllTicksComplete()
	{
		if (!isFullyLooted)
		{
			while (completedTicks < totalTicks && GetRemainingItemCount() > 0)
			{
				System.Random tickRandom = GetTickRandom(completedTicks);
				DistributeItemsForTick(tickRandom);
				completedTicks++;
			}
			objectServerData.health = completedTicks;
			if (NetworkSceneObjectSpawner.Instance != null && player != null)
			{
				NetworkSceneObjectSpawner.Instance.NetworkobjectOwner = player.GetComponent<NetworkIdentity>();
				NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
			}
			FinishLooting();
		}
	}

	private void StartTickCoroutine()
	{
		StopTickCoroutine();
		tickCoroutine = StartCoroutine(TickCoroutine());
	}

	private void StopTickCoroutine()
	{
		if (tickCoroutine != null)
		{
			StopCoroutine(tickCoroutine);
			tickCoroutine = null;
		}
	}

	private IEnumerator TickCoroutine()
	{
		while (completedTicks < totalTicks && GetRemainingItemCount() > 0)
		{
			yield return new WaitForSeconds(lootInterval);
			if (isFullyLooted || player == null)
			{
				break;
			}
			System.Random tickRandom = GetTickRandom(completedTicks);
			DistributeItemsForTick(tickRandom);
			completedTicks++;
			objectServerData.health = completedTicks;
			if (NetworkSceneObjectSpawner.Instance != null)
			{
				NetworkSceneObjectSpawner.Instance.NetworkobjectOwner = player.GetComponent<NetworkIdentity>();
				NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
			}
			if (ShouldLog)
			{
				Debug.Log($"[ProgressiveItem] Tick {completedTicks}/{totalTicks} complete, {GetRemainingItemCount()} items remaining");
			}
			if (completedTicks >= totalTicks || GetRemainingItemCount() <= 0)
			{
				FinishLooting();
				break;
			}
		}
	}

	private void DistributeItemsForTick(System.Random rng)
	{
		int remainingItemCount = GetRemainingItemCount();
		if (remainingItemCount > 0)
		{
			int num = Mathf.Max(1, totalTicks - completedTicks);
			int count;
			if (num <= 1)
			{
				count = remainingItemCount;
			}
			else
			{
				float num2 = (float)remainingItemCount / (float)num;
				float num3 = num2 * 0.6f;
				float num4 = num2 * 1.4f;
				count = Mathf.RoundToInt((float)(rng.NextDouble() * (double)(num4 - num3) + (double)num3));
				count = Mathf.Clamp(count, 1, remainingItemCount);
			}
			GiveRandomItems(count, rng);
		}
	}

	private void GiveRandomItems(int count, System.Random rng)
	{
		Dictionary<CollectableItemData, int> dictionary = new Dictionary<CollectableItemData, int>();
		for (int i = 0; i < count; i++)
		{
			int num = 0;
			for (int j = 0; j < remainingItems.Count; j++)
			{
				if (remainingItems[j].count > 0)
				{
					num += remainingItems[j].count;
				}
			}
			if (num <= 0)
			{
				break;
			}
			int num2 = rng.Next(0, num);
			int num3 = 0;
			for (int k = 0; k < remainingItems.Count; k++)
			{
				if (remainingItems[k].count <= 0)
				{
					continue;
				}
				num3 += remainingItems[k].count;
				if (num2 < num3)
				{
					remainingItems[k].count--;
					if (dictionary.ContainsKey(remainingItems[k].collectableData))
					{
						dictionary[remainingItems[k].collectableData]++;
					}
					else
					{
						dictionary[remainingItems[k].collectableData] = 1;
					}
					break;
				}
			}
		}
		bool flag = false;
		foreach (KeyValuePair<CollectableItemData, int> item in dictionary)
		{
			int availableSpaceForItem = player.GetAvailableSpaceForItem(item.Key);
			int num4 = Mathf.Min(item.Value, availableSpaceForItem);
			int num5 = item.Value - num4;
			if (num4 > 0)
			{
				player.AddItemInventory(item.Key, num4);
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("+" + num4 + " " + item.Key.GetLocalizedDisplayName(), item.Key);
			}
			if (num5 > 0)
			{
				DropOverflow(player, item.Key, num5);
				flag = true;
			}
			TaskEventManager.OnLootTaskCompleted.Invoke(item.Key, item.Value);
		}
		if (flag && Singleton<UserMessagePanel>.Instance != null)
		{
			Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
		}
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

	private void RemoveRandomItems(int count, System.Random rng)
	{
		for (int i = 0; i < count; i++)
		{
			int num = 0;
			for (int j = 0; j < remainingItems.Count; j++)
			{
				if (remainingItems[j].count > 0)
				{
					num += remainingItems[j].count;
				}
			}
			if (num <= 0)
			{
				break;
			}
			int num2 = rng.Next(0, num);
			int num3 = 0;
			for (int k = 0; k < remainingItems.Count; k++)
			{
				if (remainingItems[k].count > 0)
				{
					num3 += remainingItems[k].count;
					if (num2 < num3)
					{
						remainingItems[k].count--;
						break;
					}
				}
			}
		}
	}

	private void StartSoundLoop()
	{
		StopSoundLoop();
		soundCoroutine = StartCoroutine(PlayLootSoundLoop());
	}

	private void StopSoundLoop()
	{
		if (soundCoroutine != null)
		{
			StopCoroutine(soundCoroutine);
			soundCoroutine = null;
		}
	}

	private IEnumerator PlayLootSoundLoop()
	{
		float interval = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.progressiveLootSoundInterval : 1f);
		while (true)
		{
			if (NetworkSoundPlayer.Instance != null)
			{
				NetworkSoundPlayer.Instance.PlaySound(GameAudios.ProgressiveLootScrap, base.transform.position);
			}
			if (player != null)
			{
				TSPlayerStatusHolder component = player.GetComponent<TSPlayerStatusHolder>();
				if (component != null)
				{
					component.TriggerLootCameraShake();
				}
			}
			yield return new WaitForSeconds(interval);
		}
	}

	private void FinishLooting()
	{
		FinishLooting(player);
	}

	private void FinishLooting(PlayerInventory lootingPlayer)
	{
		if (!isFullyLooted)
		{
			isFullyLooted = true;
			if (ShouldLog)
			{
				Debug.Log($"[ProgressiveItem] Fully looted after {completedTicks} ticks (cell:{objectServerData.cellID} obj:{objectServerData.objectID})");
			}
			Vector3 position = base.transform.position;
			if (NetworkSoundPlayer.Instance != null)
			{
				NetworkSoundPlayer.Instance.PlaySound(GameAudios.ProgressiveLootScrap, position);
			}
			if (NetworkSceneObjectSpawner.Instance != null)
			{
				NetworkSceneObjectSpawner.Instance.SpawnOreHitParticle(position);
			}
			Collider component = GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = false;
			}
			StopTickCoroutine();
			StopSoundLoop();
			StopInteract();
			objectServerData.isDestroyed = true;
			objectServerData.isLootable = true;
			if (NetworkSceneObjectSpawner.Instance != null && lootingPlayer != null)
			{
				NetworkSceneObjectSpawner.Instance.NetworkobjectOwner = lootingPlayer.GetComponent<NetworkIdentity>();
				NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnDestroy()
	{
		StopTickCoroutine();
		StopSoundLoop();
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.overlayCanvasCG.alpha = 1f;
		}
	}
}
