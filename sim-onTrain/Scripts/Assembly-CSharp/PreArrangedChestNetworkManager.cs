using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PreArrangedChestNetworkManager : NetworkBehaviour
{
	public static PreArrangedChestNetworkManager Instance;

	private readonly Dictionary<long, List<InventorySlotsDataNetwork>> chestInventories = new Dictionary<long, List<InventorySlotsDataNetwork>>();

	private readonly Dictionary<long, bool> chestOpenStates = new Dictionary<long, bool>();

	private static readonly Dictionary<long, PreArrangedChestController> registry;

	private static long MakeKey(int chunkID, int objectID)
	{
		return ((long)chunkID << 32) | (uint)objectID;
	}

	private void Awake()
	{
		Instance = this;
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		StartCoroutine(ServerInitialize());
	}

	private IEnumerator ServerInitialize()
	{
		yield return new WaitUntil(() => Singleton<ES3SaveManager>.Instance != null);
		yield return null;
		Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveAllChests);
	}

	private void OnDestroy()
	{
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.RemoveListener(SaveAllChests);
		}
	}

	public static void Register(PreArrangedChestController chest)
	{
		long key = MakeKey(chest.chunkID, chest.objectID);
		registry[key] = chest;
	}

	public static void Unregister(PreArrangedChestController chest)
	{
		long key = MakeKey(chest.chunkID, chest.objectID);
		registry.Remove(key);
	}

	public static PreArrangedChestController Find(int chunkID, int objectID)
	{
		long key = MakeKey(chunkID, objectID);
		registry.TryGetValue(key, out var value);
		return value;
	}

	public void InitializeChest(int chunkID, int objectID, List<PreArrangedItemData> preArrangedItems, int slotCount, int maxCapacity)
	{
		if (NetworkServer.active)
		{
			long key = MakeKey(chunkID, objectID);
			if (!chestInventories.ContainsKey(key))
			{
				StartCoroutine(InitializeChestCoroutine(key, chunkID, objectID, preArrangedItems, slotCount, maxCapacity));
			}
		}
	}

	private IEnumerator InitializeChestCoroutine(long key, int chunkID, int objectID, List<PreArrangedItemData> preArrangedItems, int slotCount, int maxCapacity)
	{
		yield return new WaitUntil(() => Singleton<ES3SaveManager>.Instance != null);
		yield return null;
		string text = $"PreArrangedChest_{chunkID}_{objectID}";
		if (Singleton<ES3SaveManager>.Instance.KeyExists(text))
		{
			LoadChestFromSave(key, text, slotCount, maxCapacity);
		}
		else
		{
			InitializeFromPreArranged(key, preArrangedItems, slotCount, maxCapacity);
		}
		chestOpenStates[key] = false;
	}

	private void InitializeFromPreArranged(long key, List<PreArrangedItemData> preArrangedItems, int slotCount, int maxCapacity)
	{
		List<InventorySlotsDataNetwork> list = new List<InventorySlotsDataNetwork>();
		for (int i = 0; i < slotCount; i++)
		{
			list.Add(new InventorySlotsDataNetwork
			{
				itemName = "",
				slotID = i + 1,
				itemCountInSlot = 0,
				maxCapacity = maxCapacity,
				currentMagazineCount = 0,
				currentDurability = 0f
			});
		}
		if (preArrangedItems != null)
		{
			foreach (PreArrangedItemData preArrangedItem in preArrangedItems)
			{
				if (preArrangedItem.item == null)
				{
					continue;
				}
				int num = preArrangedItem.slotID - 1;
				if (num >= 0 && num < slotCount)
				{
					string itemName = preArrangedItem.item.itemName;
					if (string.IsNullOrEmpty(itemName))
					{
						itemName = preArrangedItem.item.name;
					}
					list[num] = new InventorySlotsDataNetwork
					{
						itemName = itemName,
						slotID = preArrangedItem.slotID,
						itemCountInSlot = preArrangedItem.count,
						maxCapacity = maxCapacity,
						currentMagazineCount = 0,
						currentDurability = 0f
					};
				}
			}
		}
		chestInventories[key] = list;
	}

	private void LoadChestFromSave(long key, string saveKey, int slotCount, int maxCapacity)
	{
		List<ChestSlotSaveData> list = Singleton<ES3SaveManager>.Instance.LoadData<List<ChestSlotSaveData>>(saveKey);
		if (list == null)
		{
			chestInventories[key] = new List<InventorySlotsDataNetwork>();
			return;
		}
		List<InventorySlotsDataNetwork> list2 = new List<InventorySlotsDataNetwork>();
		foreach (ChestSlotSaveData item in list)
		{
			list2.Add(new InventorySlotsDataNetwork
			{
				itemName = item.itemName,
				slotID = item.slotID,
				itemCountInSlot = item.itemCountInSlot,
				maxCapacity = item.maxCapacity,
				currentMagazineCount = item.currentMagazineCount,
				currentDurability = item.currentDurability
			});
		}
		for (int i = list.Count; i < slotCount; i++)
		{
			list2.Add(new InventorySlotsDataNetwork
			{
				itemName = "",
				slotID = i + 1,
				itemCountInSlot = 0,
				maxCapacity = maxCapacity,
				currentMagazineCount = 0,
				currentDurability = 0f
			});
		}
		chestInventories[key] = list2;
	}

	[Command(requiresAuthority = false)]
	public void CmdOpenChest(int chunkID, int objectID, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(chunkID);
		writer.WriteInt(objectID);
		SendCommandInternal("System.Void PreArrangedChestNetworkManager::CmdOpenChest(System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", 117923172, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdCloseChest(int chunkID, int objectID, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(chunkID);
		writer.WriteInt(objectID);
		SendCommandInternal("System.Void PreArrangedChestNetworkManager::CmdCloseChest(System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", 1135115960, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdUpdateSlot(int chunkID, int objectID, int index, string itemName, int count, float durability, int magazineCount, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(chunkID);
		writer.WriteInt(objectID);
		writer.WriteInt(index);
		writer.WriteString(itemName);
		writer.WriteInt(count);
		writer.WriteFloat(durability);
		writer.WriteInt(magazineCount);
		SendCommandInternal("System.Void PreArrangedChestNetworkManager::CmdUpdateSlot(System.Int32,System.Int32,System.Int32,System.String,System.Int32,System.Single,System.Int32,Mirror.NetworkConnectionToClient)", -1953914686, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOpenChestAnimation(int chunkID, int objectID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(chunkID);
		writer.WriteInt(objectID);
		SendRPCInternal("System.Void PreArrangedChestNetworkManager::RpcOpenChestAnimation(System.Int32,System.Int32)", 1859153980, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcCloseChestAnimation(int chunkID, int objectID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(chunkID);
		writer.WriteInt(objectID);
		SendRPCInternal("System.Void PreArrangedChestNetworkManager::RpcCloseChestAnimation(System.Int32,System.Int32)", 1245622726, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	public void TargetSendChestData(NetworkConnection target, int chunkID, int objectID, InventorySlotsDataNetwork[] slots)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(chunkID);
		writer.WriteInt(objectID);
		GeneratedNetworkCode._Write_InventorySlotsDataNetwork_005B_005D(writer, slots);
		SendTargetRPCInternal(target, "System.Void PreArrangedChestNetworkManager::TargetSendChestData(Mirror.NetworkConnection,System.Int32,System.Int32,InventorySlotsDataNetwork[])", 67426028, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSlotUpdated(int chunkID, int objectID, int index, string itemName, int count, float durability, int magazineCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(chunkID);
		writer.WriteInt(objectID);
		writer.WriteInt(index);
		writer.WriteString(itemName);
		writer.WriteInt(count);
		writer.WriteFloat(durability);
		writer.WriteInt(magazineCount);
		SendRPCInternal("System.Void PreArrangedChestNetworkManager::RpcSlotUpdated(System.Int32,System.Int32,System.Int32,System.String,System.Int32,System.Single,System.Int32)", -546758422, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SaveAllChests()
	{
		if (!NetworkServer.active)
		{
			return;
		}
		foreach (KeyValuePair<long, List<InventorySlotsDataNetwork>> chestInventory in chestInventories)
		{
			long key = chestInventory.Key;
			int num = (int)(key >> 32);
			int num2 = (int)(key & 0xFFFFFFFFu);
			string key2 = $"PreArrangedChest_{num}_{num2}";
			List<ChestSlotSaveData> list = new List<ChestSlotSaveData>();
			foreach (InventorySlotsDataNetwork item in chestInventory.Value)
			{
				list.Add(new ChestSlotSaveData
				{
					itemName = item.itemName,
					slotID = item.slotID,
					itemCountInSlot = item.itemCountInSlot,
					maxCapacity = item.maxCapacity,
					currentMagazineCount = item.currentMagazineCount,
					currentDurability = item.currentDurability
				});
			}
			Singleton<ES3SaveManager>.Instance.SaveData(key2, list);
		}
	}

	public List<InventorySlotsDataNetwork> GetChestInventory(int chunkID, int objectID)
	{
		long key = MakeKey(chunkID, objectID);
		if (chestInventories.TryGetValue(key, out var value))
		{
			return value;
		}
		return null;
	}

	static PreArrangedChestNetworkManager()
	{
		registry = new Dictionary<long, PreArrangedChestController>();
		RemoteProcedureCalls.RegisterCommand(typeof(PreArrangedChestNetworkManager), "System.Void PreArrangedChestNetworkManager::CmdOpenChest(System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdOpenChest__Int32__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PreArrangedChestNetworkManager), "System.Void PreArrangedChestNetworkManager::CmdCloseChest(System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdCloseChest__Int32__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PreArrangedChestNetworkManager), "System.Void PreArrangedChestNetworkManager::CmdUpdateSlot(System.Int32,System.Int32,System.Int32,System.String,System.Int32,System.Single,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdUpdateSlot__Int32__Int32__Int32__String__Int32__Single__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PreArrangedChestNetworkManager), "System.Void PreArrangedChestNetworkManager::RpcOpenChestAnimation(System.Int32,System.Int32)", InvokeUserCode_RpcOpenChestAnimation__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PreArrangedChestNetworkManager), "System.Void PreArrangedChestNetworkManager::RpcCloseChestAnimation(System.Int32,System.Int32)", InvokeUserCode_RpcCloseChestAnimation__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PreArrangedChestNetworkManager), "System.Void PreArrangedChestNetworkManager::RpcSlotUpdated(System.Int32,System.Int32,System.Int32,System.String,System.Int32,System.Single,System.Int32)", InvokeUserCode_RpcSlotUpdated__Int32__Int32__Int32__String__Int32__Single__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PreArrangedChestNetworkManager), "System.Void PreArrangedChestNetworkManager::TargetSendChestData(Mirror.NetworkConnection,System.Int32,System.Int32,InventorySlotsDataNetwork[])", InvokeUserCode_TargetSendChestData__NetworkConnection__Int32__Int32__InventorySlotsDataNetwork_005B_005D);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdOpenChest__Int32__Int32__NetworkConnectionToClient(int chunkID, int objectID, NetworkConnectionToClient sender)
	{
		long key = MakeKey(chunkID, objectID);
		if (chestOpenStates.TryGetValue(key, out var value) && value)
		{
			if (sender != null && sender != NetworkServer.localConnection && chestInventories.TryGetValue(key, out var value2))
			{
				TargetSendChestData(sender, chunkID, objectID, value2.ToArray());
			}
			return;
		}
		chestOpenStates[key] = true;
		RpcOpenChestAnimation(chunkID, objectID);
		if (sender != null && sender != NetworkServer.localConnection && chestInventories.TryGetValue(key, out var value3))
		{
			TargetSendChestData(sender, chunkID, objectID, value3.ToArray());
		}
	}

	protected static void InvokeUserCode_CmdOpenChest__Int32__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdOpenChest called on client.");
		}
		else
		{
			((PreArrangedChestNetworkManager)obj).UserCode_CmdOpenChest__Int32__Int32__NetworkConnectionToClient(reader.ReadInt(), reader.ReadInt(), senderConnection);
		}
	}

	protected void UserCode_CmdCloseChest__Int32__Int32__NetworkConnectionToClient(int chunkID, int objectID, NetworkConnectionToClient sender)
	{
		long key = MakeKey(chunkID, objectID);
		chestOpenStates[key] = false;
		RpcCloseChestAnimation(chunkID, objectID);
	}

	protected static void InvokeUserCode_CmdCloseChest__Int32__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCloseChest called on client.");
		}
		else
		{
			((PreArrangedChestNetworkManager)obj).UserCode_CmdCloseChest__Int32__Int32__NetworkConnectionToClient(reader.ReadInt(), reader.ReadInt(), senderConnection);
		}
	}

	protected void UserCode_CmdUpdateSlot__Int32__Int32__Int32__String__Int32__Single__Int32__NetworkConnectionToClient(int chunkID, int objectID, int index, string itemName, int count, float durability, int magazineCount, NetworkConnectionToClient sender)
	{
		long key = MakeKey(chunkID, objectID);
		if (chestInventories.TryGetValue(key, out var value) && index >= 0 && index < value.Count)
		{
			InventorySlotsDataNetwork value2 = value[index];
			value2.itemName = itemName;
			value2.itemCountInSlot = count;
			value2.currentDurability = durability;
			value2.currentMagazineCount = magazineCount;
			value[index] = value2;
			RpcSlotUpdated(chunkID, objectID, index, itemName, count, durability, magazineCount);
		}
	}

	protected static void InvokeUserCode_CmdUpdateSlot__Int32__Int32__Int32__String__Int32__Single__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateSlot called on client.");
		}
		else
		{
			((PreArrangedChestNetworkManager)obj).UserCode_CmdUpdateSlot__Int32__Int32__Int32__String__Int32__Single__Int32__NetworkConnectionToClient(reader.ReadInt(), reader.ReadInt(), reader.ReadInt(), reader.ReadString(), reader.ReadInt(), reader.ReadFloat(), reader.ReadInt(), senderConnection);
		}
	}

	protected void UserCode_RpcOpenChestAnimation__Int32__Int32(int chunkID, int objectID)
	{
		PreArrangedChestController preArrangedChestController = Find(chunkID, objectID);
		if (preArrangedChestController != null)
		{
			preArrangedChestController.isOpen = true;
			preArrangedChestController.OpenChestAnimation();
		}
	}

	protected static void InvokeUserCode_RpcOpenChestAnimation__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOpenChestAnimation called on server.");
		}
		else
		{
			((PreArrangedChestNetworkManager)obj).UserCode_RpcOpenChestAnimation__Int32__Int32(reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_RpcCloseChestAnimation__Int32__Int32(int chunkID, int objectID)
	{
		PreArrangedChestController preArrangedChestController = Find(chunkID, objectID);
		if (preArrangedChestController != null)
		{
			preArrangedChestController.isOpen = false;
			preArrangedChestController.CloseChestAnimation();
		}
	}

	protected static void InvokeUserCode_RpcCloseChestAnimation__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCloseChestAnimation called on server.");
		}
		else
		{
			((PreArrangedChestNetworkManager)obj).UserCode_RpcCloseChestAnimation__Int32__Int32(reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_TargetSendChestData__NetworkConnection__Int32__Int32__InventorySlotsDataNetwork_005B_005D(NetworkConnection target, int chunkID, int objectID, InventorySlotsDataNetwork[] slots)
	{
		PreArrangedChestController preArrangedChestController = Find(chunkID, objectID);
		if (preArrangedChestController != null)
		{
			preArrangedChestController.SetInventoryData(slots);
		}
	}

	protected static void InvokeUserCode_TargetSendChestData__NetworkConnection__Int32__Int32__InventorySlotsDataNetwork_005B_005D(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetSendChestData called on server.");
		}
		else
		{
			((PreArrangedChestNetworkManager)obj).UserCode_TargetSendChestData__NetworkConnection__Int32__Int32__InventorySlotsDataNetwork_005B_005D(null, reader.ReadInt(), reader.ReadInt(), GeneratedNetworkCode._Read_InventorySlotsDataNetwork_005B_005D(reader));
		}
	}

	protected void UserCode_RpcSlotUpdated__Int32__Int32__Int32__String__Int32__Single__Int32(int chunkID, int objectID, int index, string itemName, int count, float durability, int magazineCount)
	{
		PreArrangedChestController preArrangedChestController = Find(chunkID, objectID);
		if (!(preArrangedChestController == null))
		{
			if (index >= 0 && index < preArrangedChestController.localInventoryData.Count)
			{
				InventorySlotsDataNetwork value = preArrangedChestController.localInventoryData[index];
				value.itemName = itemName;
				value.itemCountInSlot = count;
				value.currentDurability = durability;
				value.currentMagazineCount = magazineCount;
				preArrangedChestController.localInventoryData[index] = value;
			}
			ChestUIManager chestUIManager = Object.FindObjectOfType<ChestUIManager>();
			if (chestUIManager != null && chestUIManager.isPanelOpen && chestUIManager.openedPreArrangedChest == preArrangedChestController)
			{
				chestUIManager.UpdateSingleSlotUI(index);
			}
		}
	}

	protected static void InvokeUserCode_RpcSlotUpdated__Int32__Int32__Int32__String__Int32__Single__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSlotUpdated called on server.");
		}
		else
		{
			((PreArrangedChestNetworkManager)obj).UserCode_RpcSlotUpdated__Int32__Int32__Int32__String__Int32__Single__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt(), reader.ReadString(), reader.ReadInt(), reader.ReadFloat(), reader.ReadInt());
		}
	}
}
