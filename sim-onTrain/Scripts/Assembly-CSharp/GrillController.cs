using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class GrillController : NetworkBehaviour, IInteractable
{
	[Serializable]
	public class GrillSaveData
	{
		public List<FuelSlotData> fuels;

		public List<CookingSlotData> cookingSlots;
	}

	[Header("Fuel System")]
	public List<FuelData> fuelItems = new List<FuelData>();

	public List<Transform> fuelPoints = new List<Transform>();

	public SyncList<FuelSlotData> fuels = new SyncList<FuelSlotData>();

	public int maxFuelAmount = 4;

	public ParticleSystem fireParticles;

	public GameObject fireLightObject;

	[Header("Audio")]
	[SerializeField]
	private AudioSource burningAudioSource;

	[Header("Cooking System")]
	public List<GrillCookableItem> cookableItems = new List<GrillCookableItem>();

	public List<Transform> cookableItemPoints = new List<Transform>();

	public SyncList<CookingSlotData> cookingSlots = new SyncList<CookingSlotData>();

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	[SerializeField]
	private bool useSphereCast;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString addWoodLocalized;

	[SerializeField]
	private LocalizedString placeFoodLocalized;

	private bool isActive = true;

	private bool isInteracting;

	private bool isShowingInteraction;

	private TSPlayerController player;

	private bool isNetworkReady;

	private float nextSyncTime;

	private readonly float cookingSyncInterval = 0.5f;

	private List<Collider> cookingSlotColliders = new List<Collider>();

	private bool collidersDisabled;

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

	public bool UseSphereCast => useSphereCast;

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

	public bool IsInteracting => isInteracting;

	private void Awake()
	{
		if (burningAudioSource != null)
		{
			burningAudioSource.loop = true;
			burningAudioSource.playOnAwake = false;
		}
		CookingSlot[] componentsInChildren = GetComponentsInChildren<CookingSlot>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Collider component = componentsInChildren[i].GetComponent<Collider>();
			if (component != null)
			{
				cookingSlotColliders.Add(component);
			}
		}
	}

	private void SetCookingSlotCollidersEnabled(bool enabled)
	{
		foreach (Collider cookingSlotCollider in cookingSlotColliders)
		{
			if (cookingSlotCollider != null)
			{
				cookingSlotCollider.enabled = enabled;
			}
		}
		collidersDisabled = !enabled;
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		CheckNetworkReady();
		for (int i = 0; i < fuelPoints.Count; i++)
		{
			fuels.Add(new FuelSlotData());
		}
		for (int j = 0; j < cookableItemPoints.Count; j++)
		{
			cookingSlots.Add(new CookingSlotData());
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		CheckNetworkReady();
		fuels.Callback += OnFuelsUpdated;
		cookingSlots.Callback += OnCookingSlotsUpdated;
		StartCoroutine(InitializeVisuals());
	}

	private void Start()
	{
		StartCoroutine(WaitForNetworkReady());
	}

	private IEnumerator WaitForNetworkReady()
	{
		while (!isNetworkReady)
		{
			CheckNetworkReady();
			if (!isNetworkReady)
			{
				yield return new WaitForSeconds(0.1f);
			}
		}
	}

	private void CheckNetworkReady()
	{
		NetworkIdentity component = GetComponent<NetworkIdentity>();
		isNetworkReady = component != null && (component.netId != 0 || NetworkServer.active);
	}

	private IEnumerator InitializeVisuals()
	{
		yield return new WaitForEndOfFrame();
		while (!isNetworkReady)
		{
			yield return new WaitForSeconds(0.1f);
		}
		for (int i = 0; i < fuels.Count && i < fuelPoints.Count; i++)
		{
			if (fuels[i].isActive)
			{
				UpdateFuelVisual(i, fuels[i]);
			}
		}
		for (int j = 0; j < cookingSlots.Count && j < cookableItemPoints.Count; j++)
		{
			if (cookingSlots[j].isPlaced)
			{
				UpdateCookingVisual(j, cookingSlots[j]);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdAddFuel(string fuelItemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(fuelItemName);
		SendCommandInternal("System.Void GrillController::CmdAddFuel(System.String)", 645713710, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAddCookableItem(string itemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		SendCommandInternal("System.Void GrillController::CmdAddCookableItem(System.String)", -1682485969, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAddCookableItemToSlot(string itemName, int slotIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteInt(slotIndex);
		SendCommandInternal("System.Void GrillController::CmdAddCookableItemToSlot(System.String,System.Int32)", 2014104129, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdRemoveCookedItem(int slotIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(slotIndex);
		SendCommandInternal("System.Void GrillController::CmdRemoveCookedItem(System.Int32)", -1630997516, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnFuelsUpdated(SyncList<FuelSlotData>.Operation op, int index, FuelSlotData oldItem, FuelSlotData newItem)
	{
		if (index >= fuelPoints.Count || fuelPoints[index] == null)
		{
			return;
		}
		switch (op)
		{
		case SyncList<FuelSlotData>.Operation.OP_ADD:
		case SyncList<FuelSlotData>.Operation.OP_INSERT:
			if (newItem.isActive)
			{
				UpdateFuelVisual(index, newItem);
			}
			break;
		case SyncList<FuelSlotData>.Operation.OP_SET:
			if (newItem.isActive)
			{
				UpdateFuelVisual(index, newItem);
			}
			else
			{
				ClearFuelVisual(index);
			}
			break;
		case SyncList<FuelSlotData>.Operation.OP_REMOVEAT:
			ClearFuelVisual(index);
			break;
		case SyncList<FuelSlotData>.Operation.OP_CLEAR:
		{
			for (int i = 0; i < fuelPoints.Count; i++)
			{
				ClearFuelVisual(i);
			}
			break;
		}
		}
		UpdateFireParticles();
	}

	private void OnCookingSlotsUpdated(SyncList<CookingSlotData>.Operation op, int index, CookingSlotData oldItem, CookingSlotData newItem)
	{
		if (index >= cookableItemPoints.Count || cookableItemPoints[index] == null)
		{
			return;
		}
		switch (op)
		{
		case SyncList<CookingSlotData>.Operation.OP_ADD:
		case SyncList<CookingSlotData>.Operation.OP_INSERT:
			if (newItem.isPlaced)
			{
				UpdateCookingVisual(index, newItem);
			}
			break;
		case SyncList<CookingSlotData>.Operation.OP_SET:
			if (newItem.isPlaced)
			{
				UpdateCookingVisual(index, newItem);
			}
			else
			{
				ClearCookingVisual(index);
			}
			break;
		case SyncList<CookingSlotData>.Operation.OP_REMOVEAT:
			ClearCookingVisual(index);
			break;
		case SyncList<CookingSlotData>.Operation.OP_CLEAR:
		{
			for (int i = 0; i < cookableItemPoints.Count; i++)
			{
				ClearCookingVisual(i);
			}
			break;
		}
		}
		UpdateFireParticles();
	}

	private void UpdateFuelVisual(int index, FuelSlotData fuelData)
	{
		ClearFuelVisual(index);
		if (!fuelData.isActive || string.IsNullOrEmpty(fuelData.fuelItemName))
		{
			return;
		}
		CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(fuelData.fuelItemName);
		if (itemFromName == null)
		{
			return;
		}
		ObjectDataEqualityChecker[] componentsInChildren = fuelPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		foreach (ObjectDataEqualityChecker objectDataEqualityChecker in componentsInChildren)
		{
			if (objectDataEqualityChecker.IsEqual(itemFromName))
			{
				objectDataEqualityChecker.OpenObject();
				break;
			}
		}
	}

	private void ClearFuelVisual(int index)
	{
		ObjectDataEqualityChecker[] componentsInChildren = fuelPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].CloseObject();
		}
	}

	private void UpdateCookingVisual(int index, CookingSlotData cookingData)
	{
		ClearCookingVisual(index);
		if (!cookingData.isPlaced || string.IsNullOrEmpty(cookingData.itemName))
		{
			return;
		}
		CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(cookingData.itemName);
		if (itemFromName == null)
		{
			return;
		}
		ObjectDataEqualityChecker[] componentsInChildren = cookableItemPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		foreach (ObjectDataEqualityChecker objectDataEqualityChecker in componentsInChildren)
		{
			if (objectDataEqualityChecker.IsEqual(itemFromName))
			{
				objectDataEqualityChecker.OpenObject();
				UpdateCookingMaterial(objectDataEqualityChecker.dataObject, cookingData.isCooked, itemFromName);
				break;
			}
		}
	}

	private void UpdateCookingMaterial(GameObject cookingObject, bool isCooked, CollectableItemData item)
	{
		if (cookingObject == null || item == null || item.cookableLevelMaterials == null || item.cookableLevelMaterials.Count < 2)
		{
			return;
		}
		Renderer[] componentsInChildren = cookingObject.GetComponentsInChildren<Renderer>();
		Material material = (isCooked ? item.cookableLevelMaterials[1] : item.cookableLevelMaterials[0]);
		Renderer[] array = componentsInChildren;
		foreach (Renderer renderer in array)
		{
			Material[] materials = renderer.materials;
			for (int j = 0; j < materials.Length; j++)
			{
				materials[j] = material;
			}
			renderer.materials = materials;
		}
	}

	private void ClearCookingVisual(int index)
	{
		ObjectDataEqualityChecker[] componentsInChildren = cookableItemPoints[index].GetComponentsInChildren<ObjectDataEqualityChecker>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].CloseObject();
		}
	}

	private void UpdateFireParticles()
	{
		if (fireParticles == null)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < fuels.Count; i++)
		{
			if (fuels[i].isActive)
			{
				flag = true;
				break;
			}
		}
		bool flag2 = false;
		for (int j = 0; j < cookingSlots.Count; j++)
		{
			if (cookingSlots[j].isPlaced && !cookingSlots[j].isCooked)
			{
				flag2 = true;
				break;
			}
		}
		if (flag && flag2)
		{
			if (!fireParticles.isPlaying)
			{
				fireParticles.Play();
			}
			if (fireLightObject != null)
			{
				fireLightObject.SetActive(value: true);
			}
			if (burningAudioSource != null && !burningAudioSource.isPlaying)
			{
				burningAudioSource.Play();
			}
		}
		else
		{
			if (fireParticles.isPlaying)
			{
				fireParticles.Stop();
			}
			if (fireLightObject != null)
			{
				fireLightObject.SetActive(value: false);
			}
			if (burningAudioSource != null && burningAudioSource.isPlaying)
			{
				burningAudioSource.Stop();
			}
		}
	}

	private void Update()
	{
		if (!base.isServer)
		{
			return;
		}
		bool flag = Time.time >= nextSyncTime;
		bool flag2 = false;
		for (int i = 0; i < cookingSlots.Count; i++)
		{
			if (cookingSlots[i].isPlaced && !cookingSlots[i].isCooked)
			{
				flag2 = true;
				break;
			}
		}
		if (flag2)
		{
			for (int j = 0; j < fuels.Count; j++)
			{
				if (fuels[j].isActive)
				{
					FuelSlotData fuelSlotData = fuels[j];
					fuelSlotData.burningTimeRemaining -= Time.deltaTime;
					if (fuelSlotData.burningTimeRemaining <= 0f)
					{
						Debug.Log($"[GRILL] Fuel '{fuelSlotData.fuelItemName}' burned out at slot {j}");
						fuels[j] = new FuelSlotData();
					}
					else
					{
						fuels[j] = fuelSlotData;
					}
					break;
				}
			}
		}
		bool flag3 = false;
		for (int k = 0; k < fuels.Count; k++)
		{
			if (fuels[k].isActive)
			{
				flag3 = true;
				break;
			}
		}
		if (flag3 && flag2)
		{
			for (int l = 0; l < cookingSlots.Count; l++)
			{
				if (!cookingSlots[l].isPlaced || cookingSlots[l].isCooked)
				{
					continue;
				}
				CookingSlotData cookingSlotData = cookingSlots[l];
				bool flag4 = false;
				CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(cookingSlotData.itemName);
				GrillCookableItem grillCookableItem = ((itemFromName != null) ? GetCookableEntry(itemFromName) : null);
				if (grillCookableItem != null && grillCookableItem.cookingDuration > 0f)
				{
					bool isCooked = cookingSlotData.isCooked;
					float num = Time.deltaTime / grillCookableItem.cookingDuration;
					cookingSlotData.cookingProgress += num;
					cookingSlotData.cookingProgress = Mathf.Clamp01(cookingSlotData.cookingProgress);
					if (cookingSlotData.cookingProgress >= 1f)
					{
						cookingSlotData.isCooked = true;
						flag4 = true;
					}
					if (isCooked != cookingSlotData.isCooked || flag)
					{
						flag4 = true;
					}
					if (flag4)
					{
						cookingSlots.RemoveAt(l);
						cookingSlots.Insert(l, cookingSlotData);
					}
				}
			}
		}
		if (flag)
		{
			nextSyncTime = Time.time + cookingSyncInterval;
		}
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (!isInteracting)
		{
			player = playerInventory.GetComponent<TSPlayerController>();
			isInteracting = true;
		}
		EastUpPlayerItemManager component = playerInventory.GetComponent<EastUpPlayerItemManager>();
		CollectableItemData collectableItemData = null;
		InventoryItem inventoryItem = null;
		if (component != null && component.lastSelectedSlot != null && component.lastSelectedSlot.InventoryItem != null)
		{
			collectableItemData = component.lastSelectedSlot.InventoryItem.collectableItemData;
			inventoryItem = component.lastSelectedSlot.InventoryItem;
		}
		List<InteractionData> list = new List<InteractionData>();
		KeyCode addFuelKey = Singleton<UserPrefencesManager>.Instance.keyData.AddFuelKey;
		KeyCode interactKey = Singleton<UserPrefencesManager>.Instance.keyData.InteractKey;
		int num = 0;
		for (int i = 0; i < fuels.Count; i++)
		{
			if (fuels[i].isActive)
			{
				num++;
			}
		}
		bool flag = num < maxFuelAmount;
		CollectableItemData collectableItemData2 = null;
		if (flag)
		{
			for (int j = 0; j < fuelItems.Count; j++)
			{
				if (playerInventory.GetTotalItemCount(fuelItems[j].item) > 0)
				{
					collectableItemData2 = fuelItems[j].item;
					break;
				}
			}
		}
		string localizedString = GetLocalizedString(addWoodLocalized, "Add Wood");
		bool num2 = collectableItemData2 != null && flag;
		list.Add(new InteractionData(messageColor: num2 ? ((Color?)null) : new Color?(InteractionPanel.Instance.negativeColor), keyCode: addFuelKey, message: $"{localizedString} ({num}/{maxFuelAmount})"));
		if (num2 && Input.GetKeyDown(addFuelKey))
		{
			CmdAddFuel(collectableItemData2.itemName);
			playerInventory.AddItemInventory(collectableItemData2, -1);
			InteractionPanel.Instance.HideAllInteractions();
		}
		int num3 = -1;
		string text = "";
		for (int k = 0; k < cookingSlots.Count; k++)
		{
			if (cookingSlots[k].isPlaced && cookingSlots[k].isCooked)
			{
				num3 = k;
				CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(cookingSlots[k].itemName);
				if (itemFromName != null && itemFromName.cookedReward.item != null)
				{
					text = itemFromName.cookedReward.item.itemName;
				}
				else if (itemFromName != null)
				{
					text = itemFromName.itemName;
				}
				break;
			}
		}
		if (num3 != -1)
		{
			list.Add(new InteractionData(interactKey, "Take Item (" + text + ")"));
			if (Input.GetKeyDown(interactKey))
			{
				CollectCookedItemFromSlot(playerInventory, num3);
				InteractionPanel.Instance.HideAllInteractions();
			}
			goto IL_03bd;
		}
		string localizedString2 = GetLocalizedString(placeFoodLocalized, "Place Food");
		bool flag2 = collectableItemData != null && GetCookableEntry(collectableItemData) != null;
		int num4 = -1;
		for (int l = 0; l < cookingSlots.Count; l++)
		{
			if (!cookingSlots[l].isPlaced)
			{
				num4 = l;
				break;
			}
		}
		int num5;
		Color? color;
		if (flag2)
		{
			num5 = ((num4 != -1) ? 1 : 0);
			if (num5 != 0)
			{
				color = null;
				goto IL_0376;
			}
		}
		else
		{
			num5 = 0;
		}
		color = InteractionPanel.Instance.negativeColor;
		goto IL_0376;
		IL_03bd:
		InteractionPanel.Instance.ShowMultipleInteractionOnOverlay(base.transform, playerInventory.transform, list);
		return;
		IL_0376:
		Color? messageColor = color;
		list.Add(new InteractionData(interactKey, localizedString2, hasHoldAction: false, 1f, null, null, null, messageColor));
		if (num5 != 0 && Input.GetKeyDown(interactKey))
		{
			CmdAddCookableItemToSlot(collectableItemData.itemName, num4);
			inventoryItem.DecreaseItemCount(1);
			InteractionPanel.Instance.HideAllInteractions();
		}
		goto IL_03bd;
	}

	public void CollectCookedItemFromSlot(PlayerInventory player, int slotIndex)
	{
		if (slotIndex < 0 || slotIndex >= cookingSlots.Count)
		{
			return;
		}
		CookingSlotData cookingSlotData = cookingSlots[slotIndex];
		CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(cookingSlotData.itemName);
		if (itemFromName != null && itemFromName.cookedReward.item != null && itemFromName.cookedReward.cost > 0)
		{
			CollectableItemData item = itemFromName.cookedReward.item;
			int cost = itemFromName.cookedReward.cost;
			int availableSpaceForItem = player.GetAvailableSpaceForItem(item);
			int num = Mathf.Min(cost, availableSpaceForItem);
			int num2 = cost - num;
			Debug.Log($"[GRILL] CollectCooked - reward: {item.itemName} x{cost} | availableSpace: {availableSpaceForItem} | canFit: {num} | overflow: {num2}");
			if (num > 0)
			{
				player.AddItemInventory(item, num);
			}
			if (num2 > 0)
			{
				DropItemToGround(player, item, num2);
				if (Singleton<UserMessagePanel>.Instance != null)
				{
					Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
				}
			}
		}
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.TakeItemGeneralSound);
		}
		CmdRemoveCookedItem(slotIndex);
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

	private GrillCookableItem GetCookableEntry(CollectableItemData itemData)
	{
		for (int i = 0; i < cookableItems.Count; i++)
		{
			if (cookableItems[i].item == itemData)
			{
				return cookableItems[i];
			}
		}
		return null;
	}

	public int GetCookingSlotIndex(CookingSlot slot)
	{
		for (int i = 0; i < cookableItemPoints.Count; i++)
		{
			if (slot.transform == cookableItemPoints[i] || slot.transform.IsChildOf(cookableItemPoints[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public void StopInteract()
	{
		isInteracting = false;
		isShowingInteraction = false;
		HideInteract();
		InteractionPanel.Instance.HideAllInteractions();
		if (collidersDisabled)
		{
			SetCookingSlotCollidersEnabled(enabled: true);
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

	private void OnDestroy()
	{
		if (isShowingInteraction && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	private void OnDisable()
	{
		if (isShowingInteraction)
		{
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.HideInteraction();
			}
			isShowingInteraction = false;
		}
	}

	private void ShowInteract(Transform playerTransform)
	{
	}

	private void HideInteract()
	{
		isShowingInteraction = false;
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}

	private void Remove(PlayerInventory player)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		if (component != null)
		{
			component.Remove(player);
		}
	}

	private void Dismantle(Transform playerTransform)
	{
		GrabbableObject component = GetComponent<GrabbableObject>();
		Grabber component2 = playerTransform.GetComponent<Grabber>();
		TSPlayerController component3 = playerTransform.GetComponent<TSPlayerController>();
		if (component != null && component2 != null && component3 != null)
		{
			component.Dismantle(component2, component3);
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

	public string SaveState()
	{
		string result = JsonUtility.ToJson(new GrillSaveData
		{
			fuels = new List<FuelSlotData>(fuels),
			cookingSlots = new List<CookingSlotData>(cookingSlots)
		});
		Debug.Log($"[GRILL] Saved state: fuel={fuels.Count}, cooking={cookingSlots.Count}");
		return result;
	}

	public void LoadState(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			Debug.Log("[GRILL] No save data to load");
			return;
		}
		try
		{
			GrillSaveData grillSaveData = JsonUtility.FromJson<GrillSaveData>(data);
			if (grillSaveData == null || !base.isServer)
			{
				return;
			}
			fuels.Clear();
			if (grillSaveData.fuels != null)
			{
				foreach (FuelSlotData fuel in grillSaveData.fuels)
				{
					fuels.Add(fuel);
				}
			}
			cookingSlots.Clear();
			if (grillSaveData.cookingSlots != null)
			{
				foreach (CookingSlotData cookingSlot in grillSaveData.cookingSlots)
				{
					cookingSlots.Add(cookingSlot);
				}
			}
			Debug.Log($"[GRILL] Loaded state: fuel={fuels.Count}, cooking={cookingSlots.Count}");
		}
		catch (Exception ex)
		{
			Debug.LogError("[GRILL] Failed to load save data: " + ex.Message);
		}
	}

	public GrillController()
	{
		InitSyncObject(fuels);
		InitSyncObject(cookingSlots);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddFuel__String(string fuelItemName)
	{
		if (!isNetworkReady)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < fuels.Count; i++)
		{
			if (!fuels[i].isActive)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			return;
		}
		CollectableItemData fuelItem = Singleton<ItemManager>.Instance.GetItemFromName(fuelItemName);
		if (!(fuelItem == null))
		{
			FuelData fuelData = fuelItems.Find((FuelData x) => x.item == fuelItem);
			if (fuelData != null)
			{
				FuelSlotData value = new FuelSlotData
				{
					fuelItemName = fuelItemName,
					isActive = true,
					burningTimeRemaining = fuelData.burningTime
				};
				fuels[num] = value;
			}
		}
	}

	protected static void InvokeUserCode_CmdAddFuel__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddFuel called on client.");
		}
		else
		{
			((GrillController)obj).UserCode_CmdAddFuel__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdAddCookableItem__String(string itemName)
	{
		if (!isNetworkReady)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < cookingSlots.Count; i++)
		{
			if (!cookingSlots[i].isPlaced)
			{
				num = i;
				break;
			}
		}
		if (num != -1 && !(Singleton<ItemManager>.Instance.GetItemFromName(itemName) == null))
		{
			CookingSlotData value = new CookingSlotData
			{
				itemName = itemName,
				isPlaced = true,
				cookingProgress = 0f,
				isCooked = false
			};
			cookingSlots[num] = value;
		}
	}

	protected static void InvokeUserCode_CmdAddCookableItem__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddCookableItem called on client.");
		}
		else
		{
			((GrillController)obj).UserCode_CmdAddCookableItem__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdAddCookableItemToSlot__String__Int32(string itemName, int slotIndex)
	{
		if (isNetworkReady && slotIndex >= 0 && slotIndex < cookingSlots.Count && !cookingSlots[slotIndex].isPlaced)
		{
			CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(itemName);
			if (!(itemFromName == null))
			{
				CookingSlotData value = new CookingSlotData
				{
					itemName = itemName,
					isPlaced = true,
					cookingProgress = 0f,
					isCooked = false
				};
				cookingSlots[slotIndex] = value;
				TaskEventManager.OnCookTaskCompleted.Invoke(itemFromName, 1);
			}
		}
	}

	protected static void InvokeUserCode_CmdAddCookableItemToSlot__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddCookableItemToSlot called on client.");
		}
		else
		{
			((GrillController)obj).UserCode_CmdAddCookableItemToSlot__String__Int32(reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_CmdRemoveCookedItem__Int32(int slotIndex)
	{
		if (isNetworkReady && slotIndex >= 0 && slotIndex < cookingSlots.Count && cookingSlots[slotIndex].isPlaced && cookingSlots[slotIndex].isCooked)
		{
			cookingSlots[slotIndex] = new CookingSlotData();
		}
	}

	protected static void InvokeUserCode_CmdRemoveCookedItem__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRemoveCookedItem called on client.");
		}
		else
		{
			((GrillController)obj).UserCode_CmdRemoveCookedItem__Int32(reader.ReadInt());
		}
	}

	static GrillController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GrillController), "System.Void GrillController::CmdAddFuel(System.String)", InvokeUserCode_CmdAddFuel__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GrillController), "System.Void GrillController::CmdAddCookableItem(System.String)", InvokeUserCode_CmdAddCookableItem__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GrillController), "System.Void GrillController::CmdAddCookableItemToSlot(System.String,System.Int32)", InvokeUserCode_CmdAddCookableItemToSlot__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(GrillController), "System.Void GrillController::CmdRemoveCookedItem(System.Int32)", InvokeUserCode_CmdRemoveCookedItem__Int32, requiresAuthority: false);
	}
}
