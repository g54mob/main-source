using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class BasicWaterPurifierController : NetworkBehaviour, IInteractable
{
	[Serializable]
	public class WaterPurifierSaveData
	{
		public float dirtyWaterAmount;

		public float cleanWaterAmount;
	}

	[Header("Capacity Settings")]
	[SerializeField]
	private float maxCapacity = 300f;

	[Header("Dirty Water System")]
	public List<CollectableItemData> acceptableDirtyWaterItems = new List<CollectableItemData>();

	[SerializeField]
	private Transform dirtyWaterVisual;

	[SerializeField]
	private float dirtyWaterPerUse = 25f;

	[SyncVar(hook = "OnDirtyWaterChanged")]
	private float dirtyWaterAmount;

	[Header("Clean Water System")]
	public List<CollectableItemData> acceptableCleanWaterItems = new List<CollectableItemData>();

	[SerializeField]
	private SkinnedMeshRenderer cleanWaterRenderer;

	[SerializeField]
	private int cleanWaterBlendShapeIndex;

	[SerializeField]
	private float cleanWaterPerUse = 25f;

	[SerializeField]
	private float minCleanWaterAmount = 25f;

	[SyncVar(hook = "OnCleanWaterChanged")]
	private float cleanWaterAmount;

	[Header("Purification Settings")]
	[SerializeField]
	private float purificationRate = 10f;

	[SerializeField]
	private GameObject purificationParticle;

	[SyncVar(hook = "OnPurifyingChanged")]
	private bool isPurifying;

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	[SerializeField]
	private bool useSphereCast = true;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString addDirtyWaterLocalized;

	[SerializeField]
	private LocalizedString takeCleanWaterLocalized;

	private bool isActive = true;

	private bool isInteracting;

	private bool isShowingInteraction;

	private TSPlayerController player;

	private bool isProcessingAction;

	private bool isNetworkReady;

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

	public bool NetworkisPurifying
	{
		get
		{
			return isPurifying;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isPurifying, 4uL, OnPurifyingChanged);
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
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		CheckNetworkReady();
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
		UpdatePurificationParticle();
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
		UpdateDirtyWaterVisual();
		UpdateCleanWaterVisual();
		UpdatePurificationParticle();
	}

	private void OnDirtyWaterChanged(float oldValue, float newValue)
	{
		NetworkdirtyWaterAmount = newValue;
		UpdateDirtyWaterVisual();
	}

	private void UpdateDirtyWaterVisual()
	{
		if (dirtyWaterVisual != null)
		{
			bool active = dirtyWaterAmount > 0f && cleanWaterAmount < maxCapacity;
			dirtyWaterVisual.gameObject.SetActive(active);
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdAddDirtyWater(float amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(amount);
		SendCommandInternal("System.Void BasicWaterPurifierController::CmdAddDirtyWater(System.Single)", 1399221033, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnCleanWaterChanged(float oldValue, float newValue)
	{
		NetworkcleanWaterAmount = newValue;
		UpdateCleanWaterVisual();
		UpdateDirtyWaterVisual();
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
		SendCommandInternal("System.Void BasicWaterPurifierController::CmdRemoveCleanWater(System.Single)", 538666099, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnPurifyingChanged(bool oldValue, bool newValue)
	{
		NetworkisPurifying = newValue;
		UpdatePurificationParticle();
	}

	private void UpdatePurificationParticle()
	{
		if (purificationParticle != null)
		{
			purificationParticle.SetActive(isPurifying);
		}
	}

	private void Update()
	{
		if (!base.isServer)
		{
			return;
		}
		bool flag = dirtyWaterAmount > 0f && cleanWaterAmount < maxCapacity;
		if (isPurifying != flag)
		{
			NetworkisPurifying = flag;
		}
		if (flag)
		{
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
		Transform objectTransform = ((interactionParent != null) ? interactionParent : base.transform);
		KeyCode interactKey = Singleton<UserPrefencesManager>.Instance.keyData.InteractKey;
		KeyCode addFuelKey = Singleton<UserPrefencesManager>.Instance.keyData.AddFuelKey;
		List<InteractionData> list = new List<InteractionData>();
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
		bool num = inventoryItem != null;
		string localizedString = GetLocalizedString(addDirtyWaterLocalized, "Add Dirty Water");
		int num2 = Mathf.RoundToInt(dirtyWaterAmount / maxCapacity * 100f);
		list.Add(new InteractionData(messageColor: num ? ((Color?)null) : new Color?(InteractionPanel.Instance.negativeColor), keyCode: addFuelKey, message: $"{localizedString} ({num2}%)"));
		if (num && Input.GetKeyDown(addFuelKey) && !isProcessingAction)
		{
			isProcessingAction = true;
			float currentDurability = inventoryItem.GetCurrentDurability();
			float num3 = dirtyWaterAmount + cleanWaterAmount;
			float amount = Mathf.Min(currentDurability, maxCapacity - num3);
			float num4 = Singleton<ItemManager>.Instance.ConsumeWaterFromBottle(inventoryItem, amount);
			if (num4 > 0f)
			{
				CmdAddDirtyWater(num4);
				TaskEventManager.OnCollectDirtyWaterTaskCompleted.Invoke(1);
			}
			StartCoroutine(ResetProcessingFlag());
		}
		InventoryItem inventoryItem2 = null;
		if (cleanWaterAmount >= minCleanWaterAmount)
		{
			foreach (InventorySlotsData slotData2 in playerInventory.inventorySlotsData)
			{
				if (!(slotData2.item == null) && acceptableCleanWaterItems.Contains(slotData2.item) && slotData2.item.hasDurability && slotData2.currentDurability < slotData2.item.maxDurabilityCapacity)
				{
					InventorySlot inventorySlot2 = playerInventory.mainInventorySlots.Find((InventorySlot x) => x.inventoryID == slotData2.slotID);
					if (inventorySlot2 != null && inventorySlot2.InventoryItem != null)
					{
						inventoryItem2 = inventorySlot2.InventoryItem;
					}
					break;
				}
			}
		}
		int num5 = Mathf.RoundToInt(minCleanWaterAmount);
		int num6 = Mathf.RoundToInt(cleanWaterPerUse);
		int num7 = Mathf.RoundToInt(cleanWaterAmount);
		int a = ((num6 > 0) ? (num7 / num6 * num6) : num7);
		int num8 = ((num7 >= num5) ? Mathf.Max(a, num5) : 0);
		int num9 = ((maxCapacity > 0f) ? Mathf.Clamp(Mathf.RoundToInt((float)num8 / maxCapacity * 100f), 0, 100) : 0);
		string localizedString2 = GetLocalizedString(takeCleanWaterLocalized, "Take Clean Water");
		if (inventoryItem2 != null)
		{
			list.Add(new InteractionData(interactKey, $"{localizedString2} ({num9}%)"));
			if (Input.GetKeyDown(interactKey) && !isProcessingAction)
			{
				isProcessingAction = true;
				float num10 = cleanWaterAmount;
				float num11 = 0f;
				foreach (InventorySlotsData slotData3 in playerInventory.inventorySlotsData)
				{
					if (num10 <= 0f)
					{
						break;
					}
					if (!(slotData3.item == null) && acceptableCleanWaterItems.Contains(slotData3.item) && slotData3.item.hasDurability && !(slotData3.currentDurability >= slotData3.item.maxDurabilityCapacity))
					{
						InventorySlot inventorySlot3 = playerInventory.mainInventorySlots.Find((InventorySlot x) => x.inventoryID == slotData3.slotID);
						if (!(inventorySlot3 == null) && !(inventorySlot3.InventoryItem == null))
						{
							float num12 = Singleton<ItemManager>.Instance.FillBottleWithCleanWater(inventorySlot3.InventoryItem, num10);
							num11 += num12;
							num10 -= num12;
						}
					}
				}
				if (num11 > 0f)
				{
					CmdRemoveCleanWater(num11);
				}
				StartCoroutine(ResetProcessingFlag());
			}
		}
		else
		{
			Color negativeColor = InteractionPanel.Instance.negativeColor;
			if (cleanWaterAmount >= minCleanWaterAmount)
			{
				list.Add(new InteractionData(interactKey, $"{localizedString2} ({num9}%)", hasHoldAction: false, 1f, null, null, null, negativeColor));
			}
			else
			{
				list.Add(new InteractionData(interactKey, localizedString2, hasHoldAction: false, 1f, null, null, null, negativeColor));
			}
		}
		InteractionPanel.Instance.ShowMultipleInteractionOnOverlay(objectTransform, playerInventory.transform, list);
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

	public string SaveState()
	{
		string result = JsonUtility.ToJson(new WaterPurifierSaveData
		{
			dirtyWaterAmount = dirtyWaterAmount,
			cleanWaterAmount = cleanWaterAmount
		});
		Debug.Log($"[WATER_PURIFIER] Saved state: dirty={dirtyWaterAmount:F1}, clean={cleanWaterAmount:F1}");
		return result;
	}

	public void LoadState(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			Debug.Log("[WATER_PURIFIER] No save data to load");
			return;
		}
		try
		{
			WaterPurifierSaveData waterPurifierSaveData = JsonUtility.FromJson<WaterPurifierSaveData>(data);
			if (waterPurifierSaveData != null && base.isServer)
			{
				NetworkdirtyWaterAmount = waterPurifierSaveData.dirtyWaterAmount;
				NetworkcleanWaterAmount = waterPurifierSaveData.cleanWaterAmount;
				Debug.Log($"[WATER_PURIFIER] Loaded state: dirty={dirtyWaterAmount:F1}, clean={cleanWaterAmount:F1}");
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("[WATER_PURIFIER] Failed to load save data: " + ex.Message);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddDirtyWater__Single(float amount)
	{
		if (base.isServer)
		{
			float num = dirtyWaterAmount + cleanWaterAmount;
			float b = maxCapacity - num;
			float num2 = Mathf.Min(amount, b);
			NetworkdirtyWaterAmount = dirtyWaterAmount + num2;
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
			((BasicWaterPurifierController)obj).UserCode_CmdAddDirtyWater__Single(reader.ReadFloat());
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
			((BasicWaterPurifierController)obj).UserCode_CmdRemoveCleanWater__Single(reader.ReadFloat());
		}
	}

	static BasicWaterPurifierController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(BasicWaterPurifierController), "System.Void BasicWaterPurifierController::CmdAddDirtyWater(System.Single)", InvokeUserCode_CmdAddDirtyWater__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BasicWaterPurifierController), "System.Void BasicWaterPurifierController::CmdRemoveCleanWater(System.Single)", InvokeUserCode_CmdRemoveCleanWater__Single, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(dirtyWaterAmount);
			writer.WriteFloat(cleanWaterAmount);
			writer.WriteBool(isPurifying);
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
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(isPurifying);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref dirtyWaterAmount, OnDirtyWaterChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref cleanWaterAmount, OnCleanWaterChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref isPurifying, OnPurifyingChanged, reader.ReadBool());
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
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isPurifying, OnPurifyingChanged, reader.ReadBool());
		}
	}
}
