using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class ChestController : NetworkBehaviour, IInventorySlotContainer, IInteractable
{
	[Serializable]
	private class ChestSaveData
	{
		public List<ChestSlotSaveData> slots = new List<ChestSlotSaveData>();
	}

	[Serializable]
	private class ChestSlotSaveData
	{
		public string itemName;

		public int slotID;

		public int itemCountInSlot;

		public int maxCapacity;

		public int currentMagazineCount;

		public float currentDurability;
	}

	[SerializeField]
	private bool isActive;

	public int inventorySlotMaxCapacity = 32;

	public int slotCount = 20;

	protected ChestUIManager chestUIManager;

	public Transform chestCap;

	public Vector3 chestOpeningRotation;

	[Header("Optional Features")]
	[Tooltip("Kapak animasyonu kullanilsin mi")]
	public bool useChestCap = true;

	[Tooltip("Acma/kapama sesleri calinsin mi")]
	public bool useOpeningSound = true;

	[Tooltip("Remove interaction gosterilsin mi")]
	public bool useRemove = true;

	[SyncVar]
	public bool isOpen;

	private NetworkConnectionToClient openerConnection;

	public SyncList<InventorySlotsDataNetwork> inventorySlotsData = new SyncList<InventorySlotsDataNetwork>();

	[SerializeField]
	private Transform interactionParent;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString openChestLocalized;

	private bool isShowingInteraction;

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

	public bool NetworkisOpen
	{
		get
		{
			return isOpen;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isOpen, 1uL, null);
		}
	}

	private void Awake()
	{
		chestUIManager = UnityEngine.Object.FindObjectOfType<ChestUIManager>();
		isActive = true;
	}

	private void Start()
	{
		if (base.isServer && inventorySlotsData.Count == 0)
		{
			inventorySlotsData.Clear();
			for (int i = 0; i < slotCount; i++)
			{
				inventorySlotsData.Add(new InventorySlotsDataNetwork
				{
					itemName = "",
					slotID = i + 1,
					itemCountInSlot = 0,
					maxCapacity = inventorySlotMaxCapacity
				});
			}
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		inventorySlotsData.Callback += OnInventoryDataChanged;
	}

	private void OnInventoryDataChanged(SyncList<InventorySlotsDataNetwork>.Operation op, int index, InventorySlotsDataNetwork oldItem, InventorySlotsDataNetwork newItem)
	{
		if (chestUIManager != null && chestUIManager.isPanelOpen && chestUIManager.openedChest == this)
		{
			if ((uint)op == 4u)
			{
				UpdateSingleSlotUI(index, newItem);
			}
			else
			{
				chestUIManager.LoadChestData();
			}
		}
	}

	private void UpdateSingleSlotUI(int index, InventorySlotsDataNetwork networkSlot)
	{
		if (chestUIManager == null || !chestUIManager.isPanelOpen)
		{
			return;
		}
		InventorySlot[] componentsInChildren = chestUIManager.GetComponentsInChildren<InventorySlot>();
		if (index >= 0 && index < componentsInChildren.Length)
		{
			InventorySlot inventorySlot = componentsInChildren[index];
			InventorySlotsData inventorySlotsData = networkSlot.ToInventorySlot();
			if (inventorySlotsData.item != null && inventorySlotsData.itemCountInSlot > 0)
			{
				inventorySlot.InventoryItem.inventoryData = inventorySlotsData;
				inventorySlot.InventoryItem.collectableItemData = inventorySlotsData.item;
				inventorySlot.InventoryItem.collectedCount = inventorySlotsData.itemCountInSlot;
				inventorySlot.InventoryItem.isEmpty = false;
				inventorySlot.InventoryItem.UpdateInventoryData(inventorySlotsData, silent: true);
				inventorySlot.HasItem = true;
				inventorySlot.inventoryCount = inventorySlotsData.itemCountInSlot;
			}
			else
			{
				inventorySlot.Clear(silent: true);
				inventorySlot.InventoryItem.inventoryData = inventorySlotsData;
				inventorySlot.HasItem = false;
				inventorySlot.inventoryCount = 0;
			}
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (IsActive && !isOpen)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(openChestLocalized, "Open Chest"));
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) && !Singleton<MainUIManager>.Instance.isInGamePanelOpened && chestUIManager.closeCooldown <= 0f)
			{
				chestUIManager.openedChest = this;
				Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(chestUIManager);
				CmdOpenChest();
				chestUIManager.ShowPanel();
			}
			if (!isShowingInteraction && useRemove)
			{
				ShowRemoveInteraction(player.transform);
				isShowingInteraction = true;
			}
		}
	}

	public void StopInteract()
	{
		isShowingInteraction = false;
		InteractionPanel.Instance.HidePanels();
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

	private void ShowRemoveInteraction(Transform player)
	{
		_ = InteractionPanel.Instance == null;
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

	[Command(requiresAuthority = false)]
	public void CmdOpenChest(NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ChestController::CmdOpenChest(Mirror.NetworkConnectionToClient)", 1149549684, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdCloseChest(NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ChestController::CmdCloseChest(Mirror.NetworkConnectionToClient)", -392515608, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void Update()
	{
		if (base.isServer && isOpen && (openerConnection == null || !openerConnection.isReady))
		{
			Debug.Log("[CHEST] Opener disconnected, auto-closing chest: " + base.gameObject.name);
			NetworkisOpen = false;
			openerConnection = null;
			RpcCloseChestAnimation();
		}
	}

	[ClientRpc]
	private void RpcOpenChestAnimation()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ChestController::RpcOpenChestAnimation()", -1274559046, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCloseChestAnimation()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ChestController::RpcCloseChestAnimation()", 748675024, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OpenChestAnimation()
	{
		if (useChestCap && chestCap != null)
		{
			chestCap.DOKill();
			chestCap.DOLocalRotate(chestOpeningRotation, 1f).SetEase(Ease.Linear);
		}
		if (useOpeningSound)
		{
			PlayChestSound(GameAudios.WoodenDoorOpen);
		}
	}

	private void CloseChestAnimation()
	{
		if (useChestCap && chestCap != null)
		{
			chestCap.DOKill();
			chestCap.DOLocalRotateQuaternion(Quaternion.identity, 1f);
		}
		if (useOpeningSound)
		{
			PlayChestSound(GameAudios.WoodenDoorClose);
		}
	}

	private void PlayChestSound(GameAudios audio)
	{
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySoundLocalOnly(audio, base.transform.position);
		}
	}

	public void OnSlotsChanged()
	{
		int num = 0;
		foreach (InventorySlotsDataNetwork inventorySlotsDatum in inventorySlotsData)
		{
			if (!string.IsNullOrEmpty(inventorySlotsDatum.itemName))
			{
				num += inventorySlotsDatum.itemCountInSlot;
				Debug.Log($"Slot {inventorySlotsDatum.slotID}: {inventorySlotsDatum.itemName} x{inventorySlotsDatum.itemCountInSlot}");
			}
		}
	}

	public void RequestCloseChest()
	{
		CmdCloseChest();
	}

	public List<InventorySlotsData> GetInventorySlots()
	{
		List<InventorySlotsData> list = new List<InventorySlotsData>();
		foreach (InventorySlotsDataNetwork inventorySlotsDatum in inventorySlotsData)
		{
			list.Add(inventorySlotsDatum.ToInventorySlot());
		}
		return list;
	}

	[Server]
	public void UpdateSlot(int index, InventorySlotsData slotData)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ChestController::UpdateSlot(System.Int32,InventorySlotsData)' called when server was not active");
		}
		else if (index >= 0 && index < inventorySlotsData.Count)
		{
			inventorySlotsData[index] = InventorySlotsDataNetwork.FromInventorySlot(slotData);
		}
	}

	[Server]
	public void SetInventoryDataFromPlayer(List<InventorySlotsData> playerInventorySlots)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ChestController::SetInventoryDataFromPlayer(System.Collections.Generic.List`1<InventorySlotsData>)' called when server was not active");
			return;
		}
		this.inventorySlotsData.Clear();
		for (int i = 0; i < slotCount; i++)
		{
			if (i < playerInventorySlots.Count && playerInventorySlots[i].item != null && playerInventorySlots[i].itemCountInSlot > 0)
			{
				InventorySlotsData inventorySlotsData = playerInventorySlots[i];
				this.inventorySlotsData.Add(new InventorySlotsDataNetwork
				{
					itemName = inventorySlotsData.item.name,
					slotID = i + 1,
					itemCountInSlot = inventorySlotsData.itemCountInSlot,
					maxCapacity = inventorySlotsData.maxCapacity,
					currentMagazineCount = inventorySlotsData.currentMagazineCount,
					currentDurability = inventorySlotsData.currentDurability
				});
			}
			else
			{
				this.inventorySlotsData.Add(new InventorySlotsDataNetwork
				{
					itemName = "",
					slotID = i + 1,
					itemCountInSlot = 0,
					maxCapacity = inventorySlotMaxCapacity,
					currentMagazineCount = 0,
					currentDurability = 0f
				});
			}
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

	[Command(requiresAuthority = false)]
	public void CmdUpdateSlot(int index, string itemName, int count, float durability, int magazineCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteString(itemName);
		writer.WriteInt(count);
		writer.WriteFloat(durability);
		writer.WriteInt(magazineCount);
		SendCommandInternal("System.Void ChestController::CmdUpdateSlot(System.Int32,System.String,System.Int32,System.Single,System.Int32)", 1150561905, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public string SaveState()
	{
		ChestSaveData chestSaveData = new ChestSaveData();
		foreach (InventorySlotsDataNetwork inventorySlotsDatum in inventorySlotsData)
		{
			chestSaveData.slots.Add(new ChestSlotSaveData
			{
				itemName = inventorySlotsDatum.itemName,
				slotID = inventorySlotsDatum.slotID,
				itemCountInSlot = inventorySlotsDatum.itemCountInSlot,
				maxCapacity = inventorySlotsDatum.maxCapacity,
				currentMagazineCount = inventorySlotsDatum.currentMagazineCount,
				currentDurability = inventorySlotsDatum.currentDurability
			});
		}
		return JsonUtility.ToJson(chestSaveData);
	}

	public void LoadState(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			return;
		}
		try
		{
			ChestSaveData chestSaveData = JsonUtility.FromJson<ChestSaveData>(data);
			if (chestSaveData == null || chestSaveData.slots == null || !base.isServer)
			{
				return;
			}
			inventorySlotsData.Clear();
			foreach (ChestSlotSaveData slot in chestSaveData.slots)
			{
				inventorySlotsData.Add(new InventorySlotsDataNetwork
				{
					itemName = slot.itemName,
					slotID = slot.slotID,
					itemCountInSlot = slot.itemCountInSlot,
					maxCapacity = slot.maxCapacity,
					currentMagazineCount = slot.currentMagazineCount,
					currentDurability = slot.currentDurability
				});
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[CHEST] LoadState hata: " + ex.Message);
		}
	}

	public ChestController()
	{
		InitSyncObject(inventorySlotsData);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdOpenChest__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (!isOpen)
		{
			NetworkisOpen = true;
			openerConnection = sender;
			RpcOpenChestAnimation();
		}
	}

	protected static void InvokeUserCode_CmdOpenChest__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdOpenChest called on client.");
		}
		else
		{
			((ChestController)obj).UserCode_CmdOpenChest__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdCloseChest__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		NetworkisOpen = false;
		openerConnection = null;
		RpcCloseChestAnimation();
	}

	protected static void InvokeUserCode_CmdCloseChest__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCloseChest called on client.");
		}
		else
		{
			((ChestController)obj).UserCode_CmdCloseChest__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcOpenChestAnimation()
	{
		OpenChestAnimation();
	}

	protected static void InvokeUserCode_RpcOpenChestAnimation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOpenChestAnimation called on server.");
		}
		else
		{
			((ChestController)obj).UserCode_RpcOpenChestAnimation();
		}
	}

	protected void UserCode_RpcCloseChestAnimation()
	{
		CloseChestAnimation();
	}

	protected static void InvokeUserCode_RpcCloseChestAnimation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCloseChestAnimation called on server.");
		}
		else
		{
			((ChestController)obj).UserCode_RpcCloseChestAnimation();
		}
	}

	protected void UserCode_CmdUpdateSlot__Int32__String__Int32__Single__Int32(int index, string itemName, int count, float durability, int magazineCount)
	{
		if (index >= 0 && index < inventorySlotsData.Count)
		{
			InventorySlotsDataNetwork value = inventorySlotsData[index];
			value.itemName = itemName;
			value.itemCountInSlot = count;
			value.currentDurability = durability;
			value.currentMagazineCount = magazineCount;
			inventorySlotsData[index] = value;
		}
	}

	protected static void InvokeUserCode_CmdUpdateSlot__Int32__String__Int32__Single__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateSlot called on client.");
		}
		else
		{
			((ChestController)obj).UserCode_CmdUpdateSlot__Int32__String__Int32__Single__Int32(reader.ReadInt(), reader.ReadString(), reader.ReadInt(), reader.ReadFloat(), reader.ReadInt());
		}
	}

	static ChestController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ChestController), "System.Void ChestController::CmdOpenChest(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdOpenChest__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChestController), "System.Void ChestController::CmdCloseChest(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdCloseChest__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ChestController), "System.Void ChestController::CmdUpdateSlot(System.Int32,System.String,System.Int32,System.Single,System.Int32)", InvokeUserCode_CmdUpdateSlot__Int32__String__Int32__Single__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ChestController), "System.Void ChestController::RpcOpenChestAnimation()", InvokeUserCode_RpcOpenChestAnimation);
		RemoteProcedureCalls.RegisterRpc(typeof(ChestController), "System.Void ChestController::RpcCloseChestAnimation()", InvokeUserCode_RpcCloseChestAnimation);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(isOpen);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(isOpen);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref isOpen, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isOpen, null, reader.ReadBool());
		}
	}
}
