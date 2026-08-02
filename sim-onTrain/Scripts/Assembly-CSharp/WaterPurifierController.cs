using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class WaterPurifierController : NetworkBehaviour, IInteractable
{
	[Header("Capacity Settings")]
	public float maxCapacity = 300f;

	[Header("Dirty Water System")]
	public List<CollectableItemData> acceptableDirtyWaterItems = new List<CollectableItemData>();

	[SerializeField]
	private Transform dirtyWaterVisual;

	[SerializeField]
	private float dirtyWaterPerUse = 25f;

	[SyncVar(hook = "OnDirtyWaterChanged")]
	private float dirtyWaterAmount;

	[Header("Fuel System")]
	public List<FuelData> fuelItems = new List<FuelData>();

	public List<Transform> fuelPoints = new List<Transform>();

	public SyncList<FuelSlotData> fuels = new SyncList<FuelSlotData>();

	public int maxFuelAmount = 4;

	public ParticleSystem fireParticles;

	public GameObject fireLightObject;

	[Header("Clean Water System")]
	public List<CollectableItemData> acceptableCleanWaterItems = new List<CollectableItemData>();

	[SerializeField]
	private SkinnedMeshRenderer cleanWaterRenderer;

	[SerializeField]
	private int cleanWaterBlendShapeIndex;

	public float cleanWaterPerUse = 25f;

	public float minCleanWaterAmount = 25f;

	[SyncVar(hook = "OnCleanWaterChanged")]
	private float cleanWaterAmount;

	[Header("Purification Settings")]
	[SerializeField]
	private float purificationRate = 10f;

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	private bool isActive = true;

	private bool isInteracting;

	private bool isShowingInteraction;

	private TSPlayerController player;

	private bool isProcessingAction;

	private bool isNetworkReady;

	[SerializeField]
	private bool useSphereCast;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString addWoodLocalized;

	[SerializeField]
	private LocalizedString addDirtyWaterLocalized;

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

	public bool UseSphereCast => useSphereCast;

	public float NetworkdirtyWaterAmount
	{
		get
		{
			return dirtyWaterAmount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref dirtyWaterAmount, 1uL, OnDirtyWaterChanged);
		}
	}

	public float NetworkcleanWaterAmount
	{
		get
		{
			return cleanWaterAmount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref cleanWaterAmount, 2uL, OnCleanWaterChanged);
		}
	}

	public float GetDirtyWaterLevel()
	{
		return dirtyWaterAmount / maxCapacity;
	}

	public float GetCleanWaterLevel()
	{
		return cleanWaterAmount / maxCapacity;
	}

	public float GetCleanWaterAmount()
	{
		return cleanWaterAmount;
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		CheckNetworkReady();
		for (int i = 0; i < fuelPoints.Count; i++)
		{
			fuels.Add(new FuelSlotData());
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		CheckNetworkReady();
		fuels.Callback += OnFuelsUpdated;
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
		UpdateDirtyWaterVisual();
		UpdateCleanWaterVisual();
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
		UpdateDirtyWaterVisual();
		UpdateCleanWaterVisual();
	}

	private void OnDirtyWaterChanged(float oldValue, float newValue)
	{
		NetworkdirtyWaterAmount = newValue;
		UpdateDirtyWaterVisual();
		UpdateFireParticles();
	}

	private void UpdateDirtyWaterVisual()
	{
		if (dirtyWaterVisual != null)
		{
			Vector3 localScale = dirtyWaterVisual.localScale;
			localScale.y = Mathf.Clamp01(dirtyWaterAmount / maxCapacity);
			dirtyWaterVisual.localScale = localScale;
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdAddDirtyWater(float amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(amount);
		SendCommandInternal("System.Void WaterPurifierController::CmdAddDirtyWater(System.Single)", -529625373, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnCleanWaterChanged(float oldValue, float newValue)
	{
		NetworkcleanWaterAmount = newValue;
		UpdateCleanWaterVisual();
		UpdateFireParticles();
	}

	private void UpdateCleanWaterVisual()
	{
		if (cleanWaterRenderer != null)
		{
			float value = ((maxCapacity > 0f) ? (cleanWaterAmount / maxCapacity) : 0f);
			bool flag = cleanWaterAmount >= minCleanWaterAmount;
			cleanWaterRenderer.gameObject.SetActive(flag);
			if (flag)
			{
				float value2 = Mathf.Clamp01(value) * 100f;
				cleanWaterRenderer.SetBlendShapeWeight(cleanWaterBlendShapeIndex, value2);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdRemoveCleanWater(float amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(amount);
		SendCommandInternal("System.Void WaterPurifierController::CmdRemoveCleanWater(System.Single)", 642838137, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAddFuel(string fuelItemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(fuelItemName);
		SendCommandInternal("System.Void WaterPurifierController::CmdAddFuel(System.String)", -915541687, writer, 0, requiresAuthority: false);
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

	private void UpdateFireParticles()
	{
		if (fireParticles == null)
		{
			return;
		}
		bool num = dirtyWaterAmount > 0f && cleanWaterAmount < maxCapacity;
		bool flag = HasActiveFuel();
		if (num && flag)
		{
			if (!fireParticles.isPlaying)
			{
				fireParticles.Play();
			}
			if (fireLightObject != null)
			{
				fireLightObject.SetActive(value: true);
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
		}
	}

	private bool HasActiveFuel()
	{
		for (int i = 0; i < fuels.Count; i++)
		{
			if (fuels[i].isActive)
			{
				return true;
			}
		}
		return false;
	}

	private void Update()
	{
		if (!base.isServer || !(dirtyWaterAmount > 0f) || !(cleanWaterAmount < maxCapacity) || !HasActiveFuel())
		{
			return;
		}
		for (int i = 0; i < fuels.Count; i++)
		{
			if (fuels[i].isActive)
			{
				FuelSlotData fuelSlotData = fuels[i];
				fuelSlotData.burningTimeRemaining -= Time.deltaTime;
				if (fuelSlotData.burningTimeRemaining <= 0f)
				{
					fuels[i] = new FuelSlotData();
				}
				else
				{
					fuels[i] = fuelSlotData;
				}
				break;
			}
		}
		float a = purificationRate * Time.deltaTime;
		a = Mathf.Min(a, dirtyWaterAmount);
		float b = maxCapacity - cleanWaterAmount;
		a = Mathf.Min(a, b);
		if (a > 0f)
		{
			NetworkdirtyWaterAmount = dirtyWaterAmount - a;
			NetworkcleanWaterAmount = cleanWaterAmount + a;
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
		if (component != null && component.lastSelectedSlot != null && component.lastSelectedSlot.InventoryItem != null)
		{
			_ = component.lastSelectedSlot.InventoryItem.collectableItemData;
			_ = component.lastSelectedSlot.InventoryItem;
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
		CollectableItemData collectableItemData = null;
		if (flag)
		{
			for (int j = 0; j < fuelItems.Count; j++)
			{
				if (playerInventory.GetTotalItemCount(fuelItems[j].item) > 0)
				{
					collectableItemData = fuelItems[j].item;
					break;
				}
			}
		}
		bool num2 = collectableItemData != null && flag;
		string localizedString = GetLocalizedString(addWoodLocalized, "Add Wood");
		list.Add(new InteractionData(messageColor: num2 ? ((Color?)null) : new Color?(InteractionPanel.Instance.negativeColor), keyCode: addFuelKey, message: $"{localizedString} ({num}/{maxFuelAmount})"));
		if (num2 && Input.GetKeyDown(addFuelKey))
		{
			CmdAddFuel(collectableItemData.itemName);
			playerInventory.AddItemInventory(collectableItemData, -1);
			InteractionPanel.Instance.HideAllInteractions();
			TaskEventManager.OnAddFuelOnWaterPurifierTaskCompleted.Invoke(collectableItemData, 1);
		}
		bool flag2 = false;
		InventoryItem inventoryItem = null;
		if (dirtyWaterAmount + cleanWaterAmount < maxCapacity)
		{
			foreach (InventorySlotsData slotData in playerInventory.inventorySlotsData)
			{
				if (!(slotData.item == null) && acceptableDirtyWaterItems.Contains(slotData.item) && slotData.item.hasDurability && slotData.currentDurability > 0f)
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
		if (inventoryItem != null)
		{
			flag2 = true;
			string localizedString2 = GetLocalizedString(addDirtyWaterLocalized, "Add Dirty Water");
			int num3 = Mathf.RoundToInt(dirtyWaterAmount / maxCapacity * 100f);
			list.Add(new InteractionData(interactKey, $"{localizedString2} ({num3}%)"));
			if (Input.GetKeyDown(interactKey) && !isProcessingAction)
			{
				isProcessingAction = true;
				float amount = Mathf.Min(inventoryItem.GetCurrentDurability(), maxCapacity - (dirtyWaterAmount + cleanWaterAmount));
				float num4 = Singleton<ItemManager>.Instance.ConsumeWaterFromBottle(inventoryItem, amount);
				if (num4 > 0f)
				{
					CmdAddDirtyWater(num4);
					TaskEventManager.OnCollectDirtyWaterTaskCompleted.Invoke(1);
				}
				StartCoroutine(ResetProcessingFlag());
			}
		}
		if (!flag2)
		{
			string localizedString3 = GetLocalizedString(addDirtyWaterLocalized, "Add Dirty Water");
			Color negativeColor = InteractionPanel.Instance.negativeColor;
			int num5 = Mathf.RoundToInt(dirtyWaterAmount / maxCapacity * 100f);
			list.Add(new InteractionData(interactKey, $"{localizedString3} ({num5}%)", hasHoldAction: false, 1f, null, null, null, negativeColor));
		}
		InteractionPanel.Instance.ShowMultipleInteractionOnOverlay(base.transform, playerInventory.transform, list);
		if (!isShowingInteraction)
		{
			ShowInteract(playerInventory.transform);
			isShowingInteraction = true;
		}
	}

	public void StopInteract()
	{
		isInteracting = false;
		isShowingInteraction = false;
		HideInteract();
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
		_ = InteractionPanel.Instance == null;
	}

	private void HideInteract()
	{
		isShowingInteraction = false;
		if (InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HidePanels();
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

	public WaterPurifierController()
	{
		InitSyncObject(fuels);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddDirtyWater__Single(float amount)
	{
		if (base.isServer)
		{
			float networkdirtyWaterAmount = Mathf.Min(dirtyWaterAmount + amount, maxCapacity);
			NetworkdirtyWaterAmount = networkdirtyWaterAmount;
		}
	}

	protected static void InvokeUserCode_CmdAddDirtyWater__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddDirtyWater called on client.");
		}
		else
		{
			((WaterPurifierController)obj).UserCode_CmdAddDirtyWater__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_CmdRemoveCleanWater__Single(float amount)
	{
		if (base.isServer)
		{
			float networkcleanWaterAmount = Mathf.Max(cleanWaterAmount - amount, 0f);
			NetworkcleanWaterAmount = networkcleanWaterAmount;
		}
	}

	protected static void InvokeUserCode_CmdRemoveCleanWater__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRemoveCleanWater called on client.");
		}
		else
		{
			((WaterPurifierController)obj).UserCode_CmdRemoveCleanWater__Single(reader.ReadFloat());
		}
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
			((WaterPurifierController)obj).UserCode_CmdAddFuel__String(reader.ReadString());
		}
	}

	static WaterPurifierController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(WaterPurifierController), "System.Void WaterPurifierController::CmdAddDirtyWater(System.Single)", InvokeUserCode_CmdAddDirtyWater__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(WaterPurifierController), "System.Void WaterPurifierController::CmdRemoveCleanWater(System.Single)", InvokeUserCode_CmdRemoveCleanWater__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(WaterPurifierController), "System.Void WaterPurifierController::CmdAddFuel(System.String)", InvokeUserCode_CmdAddFuel__String, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(dirtyWaterAmount);
			writer.WriteFloat(cleanWaterAmount);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(dirtyWaterAmount);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(cleanWaterAmount);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref dirtyWaterAmount, OnDirtyWaterChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref cleanWaterAmount, OnCleanWaterChanged, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref dirtyWaterAmount, OnDirtyWaterChanged, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref cleanWaterAmount, OnCleanWaterChanged, reader.ReadFloat());
		}
	}
}
