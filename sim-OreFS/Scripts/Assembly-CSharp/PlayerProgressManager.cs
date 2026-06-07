using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;

public class PlayerProgressManager : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class ProgressSaveData
	{
		public List<ItemEntry> sharedItems = new List<ItemEntry>();

		public List<PlayerBagRecord> playerBags = new List<PlayerBagRecord>();

		public List<PlayerStatusRecord> playerStatuses = new List<PlayerStatusRecord>();
	}

	[Serializable]
	public class BagItemEntry
	{
		public string itemId;

		public int count;

		public BagItemEntry()
		{
		}

		public BagItemEntry(string id, int c)
		{
			itemId = id;
			count = c;
		}
	}

	[Serializable]
	public class PlayerBagRecord
	{
		public ulong steamId64;

		public List<BagItemEntry> bagItems = new List<BagItemEntry>();
	}

	[Serializable]
	public class ItemEntry
	{
		public ItemType type;

		public int level;
	}

	[Serializable]
	public class PlayerRecord
	{
		public ulong steamId64;

		public List<ItemEntry> items = new List<ItemEntry>();
	}

	[Serializable]
	public class ConnMap
	{
		public int connectionId;

		public ulong steamId64;
	}

	[Serializable]
	public class PlayerStatusRecord
	{
		public ulong steamId64;

		public bool isInDigsite;

		public string customizationIDs;
	}

	public static PlayerProgressManager Instance;

	public bool disableSteamworks;

	public List<PlayerRecord> master = new List<PlayerRecord>();

	[Header("Bag Storage")]
	[SerializeField]
	private List<PlayerBagRecord> playerBagRecords = new List<PlayerBagRecord>();

	[Header("Shared Upgrade System")]
	[Tooltip("True = Tüm oyuncular aynı upgrade seviyelerini paylaşır")]
	public bool useSharedUpgrades = true;

	[SerializeField]
	private List<ItemEntry> sharedItems = new List<ItemEntry>();

	public List<ConnMap> connMap = new List<ConnMap>();

	[Header("Player Status")]
	[SerializeField]
	private List<PlayerStatusRecord> playerStatusRecords = new List<PlayerStatusRecord>();

	public static Action<ulong, bool> OnPlayerDigsiteStatusChanged;

	public List<ItemEntry> localItemLevels = new List<ItemEntry>();

	private ulong localSteamId;

	private bool initDone;

	public static Action<ulong, ItemType, int> OnAnyPlayerLevelChanged;

	public Action<ItemType, int> OnMyLevelChanged;

	public string SaveID => "player-progress-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(ProgressSaveData);

	public LoadMode LoadMode => LoadMode.Greedy;

	[Server]
	public void Server_SetPlayerInDigsite(ulong steamId, bool value)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_SetPlayerInDigsite(System.UInt64,System.Boolean)' called when server was not active");
			return;
		}
		PlayerStatusRecord playerStatusRecord = Server_GetOrCreateStatusRecord(steamId);
		if (playerStatusRecord.isInDigsite != value)
		{
			playerStatusRecord.isInDigsite = value;
			RpcNotifyDigsiteStatusChanged(steamId, value);
		}
	}

	[Server]
	public bool Server_GetPlayerInDigsite(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean PlayerProgressManager::Server_GetPlayerInDigsite(System.UInt64)' called when server was not active");
			return default(bool);
		}
		return Server_FindStatusRecord(steamId)?.isInDigsite ?? false;
	}

	[Server]
	private PlayerStatusRecord Server_GetOrCreateStatusRecord(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/PlayerStatusRecord PlayerProgressManager::Server_GetOrCreateStatusRecord(System.UInt64)' called when server was not active");
			return null;
		}
		PlayerStatusRecord playerStatusRecord = Server_FindStatusRecord(steamId);
		if (playerStatusRecord == null)
		{
			playerStatusRecord = new PlayerStatusRecord
			{
				steamId64 = steamId
			};
			playerStatusRecords.Add(playerStatusRecord);
		}
		return playerStatusRecord;
	}

	[Server]
	private PlayerStatusRecord Server_FindStatusRecord(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/PlayerStatusRecord PlayerProgressManager::Server_FindStatusRecord(System.UInt64)' called when server was not active");
			return null;
		}
		for (int i = 0; i < playerStatusRecords.Count; i++)
		{
			if (playerStatusRecords[i].steamId64 == steamId)
			{
				return playerStatusRecords[i];
			}
		}
		return null;
	}

	[ClientRpc]
	private void RpcNotifyDigsiteStatusChanged(ulong steamId, bool isInDigsite)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarULong(steamId);
		writer.WriteBool(isInDigsite);
		SendRPCInternal("System.Void PlayerProgressManager::RpcNotifyDigsiteStatusChanged(System.UInt64,System.Boolean)", -588999045, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void Server_SetPlayerCustomization(ulong steamId, string customizationIDs)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_SetPlayerCustomization(System.UInt64,System.String)' called when server was not active");
		}
		else
		{
			Server_GetOrCreateStatusRecord(steamId).customizationIDs = customizationIDs;
		}
	}

	[Server]
	public string Server_GetPlayerCustomization(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.String PlayerProgressManager::Server_GetPlayerCustomization(System.UInt64)' called when server was not active");
			return null;
		}
		return Server_FindStatusRecord(steamId)?.customizationIDs;
	}

	[Server]
	public void Server_ResetAllDigsiteStatuses()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_ResetAllDigsiteStatuses()' called when server was not active");
			return;
		}
		for (int i = 0; i < playerStatusRecords.Count; i++)
		{
			playerStatusRecords[i].isInDigsite = false;
		}
	}

	[Server]
	private void Server_MigrateZeroIdRecords(ulong realSteamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_MigrateZeroIdRecords(System.UInt64)' called when server was not active");
			return;
		}
		for (int i = 0; i < playerBagRecords.Count; i++)
		{
			if (playerBagRecords[i].steamId64 == 0L)
			{
				playerBagRecords[i].steamId64 = realSteamId;
				Debug.Log($"[PlayerProgressManager] BagRecord id 0 -> {realSteamId} migrate edildi");
				break;
			}
		}
		for (int j = 0; j < playerStatusRecords.Count; j++)
		{
			if (playerStatusRecords[j].steamId64 == 0L)
			{
				playerStatusRecords[j].steamId64 = realSteamId;
				Debug.Log($"[PlayerProgressManager] StatusRecord id 0 -> {realSteamId} migrate edildi");
				break;
			}
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		StartCoroutine(InitWhenReady());
	}

	private IEnumerator InitWhenReady()
	{
		while (!base.isClient || NetworkClient.connection == null || !NetworkClient.connection.isReady)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0.15f);
		RequestInitForSelf(force: true);
	}

	public void RefreshMyData()
	{
		RequestInitForSelf(force: true);
	}

	private void RequestInitForSelf(bool force = false)
	{
		if (initDone && !force)
		{
			return;
		}
		if (!disableSteamworks)
		{
			localSteamId = GetSteamId64();
		}
		else if (localSteamId == 0L)
		{
			int num = 0;
			if (NetworkClient.localPlayer != null && NetworkClient.localPlayer.connectionToClient != null)
			{
				num = NetworkClient.localPlayer.connectionToClient.connectionId;
			}
			localSteamId = (ulong)num + 1uL;
		}
		CmdRequestInit(localSteamId, NetworkClient.localPlayer.connectionToClient);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestInit(ulong sid, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestInit__UInt64__NetworkConnectionToClient(sid, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarULong(sid);
		SendCommandInternal("System.Void PlayerProgressManager::CmdRequestInit(System.UInt64,Mirror.NetworkConnectionToClient)", -482811215, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetInitLocalData(NetworkConnectionToClient target, List<ItemType> types, List<int> levels)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E(writer, types);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, levels);
		SendTargetRPCInternal(target, "System.Void PlayerProgressManager::TargetInitLocalData(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<ItemType>,System.Collections.Generic.List`1<System.Int32>)", 224129301, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public int GetLevel(ItemType type)
	{
		return FindItem(localItemLevels, type)?.level ?? 0;
	}

	public void IncreaseLevel(ItemType type, int amount = 1)
	{
		if (amount != 0)
		{
			if (!initDone)
			{
				RequestInitForSelf();
			}
			CmdIncreaseLevel(type, amount, NetworkClient.localPlayer.connectionToClient);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdIncreaseLevel(ItemType type, int amount, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdIncreaseLevel__ItemType__Int32__NetworkConnectionToClient(type, amount, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_ItemType(writer, type);
		writer.WriteVarInt(amount);
		SendCommandInternal("System.Void PlayerProgressManager::CmdIncreaseLevel(ItemType,System.Int32,Mirror.NetworkConnectionToClient)", -1689874995, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void Server_IncreaseLevel(ulong sid, ItemType type, int amount, NetworkConnectionToClient targetConn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_IncreaseLevel(System.UInt64,ItemType,System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else if (useSharedUpgrades)
		{
			List<ItemEntry> list = Server_GetSharedItems();
			ItemEntry itemEntry = Server_FindOrCreateItem(list, type);
			itemEntry.level = Mathf.Max(0, itemEntry.level + amount);
			Server_BroadcastSharedLevels(type, itemEntry.level);
		}
		else
		{
			PlayerRecord playerRecord = Server_GetOrCreatePlayer(sid);
			ItemEntry itemEntry2 = Server_FindOrCreateItem(playerRecord.items, type);
			itemEntry2.level = Mathf.Max(0, itemEntry2.level + amount);
			Server_PackForClient(playerRecord, out var types, out var levels);
			TargetInitLocalData(targetConn, types, levels);
			RpcNotifyLevelChanged(sid, type, itemEntry2.level);
		}
	}

	[ClientRpc]
	private void RpcNotifyLevelChanged(ulong sid, ItemType type, int newLevel)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarULong(sid);
		GeneratedNetworkCode._Write_ItemType(writer, type);
		writer.WriteVarInt(newLevel);
		SendRPCInternal("System.Void PlayerProgressManager::RpcNotifyLevelChanged(System.UInt64,ItemType,System.Int32)", 887463901, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void Server_BroadcastSharedLevels(ItemType changedType, int newLevel)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_BroadcastSharedLevels(ItemType,System.Int32)' called when server was not active");
			return;
		}
		Server_PackFromList(sharedItems, out var types, out var levels);
		RpcSyncSharedLevels(types, levels, changedType, newLevel);
	}

	[ClientRpc]
	private void RpcSyncSharedLevels(List<ItemType> types, List<int> levels, ItemType changedType, int newLevel)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E(writer, types);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, levels);
		GeneratedNetworkCode._Write_ItemType(writer, changedType);
		writer.WriteVarInt(newLevel);
		SendRPCInternal("System.Void PlayerProgressManager::RpcSyncSharedLevels(System.Collections.Generic.List`1<ItemType>,System.Collections.Generic.List`1<System.Int32>,ItemType,System.Int32)", 1124820214, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void Server_MapSet(int connId, ulong sid)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_MapSet(System.Int32,System.UInt64)' called when server was not active");
			return;
		}
		for (int i = 0; i < connMap.Count; i++)
		{
			if (connMap[i].connectionId == connId)
			{
				connMap[i].steamId64 = sid;
				return;
			}
		}
		connMap.Add(new ConnMap
		{
			connectionId = connId,
			steamId64 = sid
		});
	}

	[Server]
	private ulong Server_MapGetSteamId(int connId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.UInt64 PlayerProgressManager::Server_MapGetSteamId(System.Int32)' called when server was not active");
			return default(ulong);
		}
		for (int i = 0; i < connMap.Count; i++)
		{
			if (connMap[i].connectionId == connId)
			{
				return connMap[i].steamId64;
			}
		}
		return 0uL;
	}

	[Server]
	private PlayerRecord Server_GetOrCreatePlayer(ulong sid)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/PlayerRecord PlayerProgressManager::Server_GetOrCreatePlayer(System.UInt64)' called when server was not active");
			return null;
		}
		PlayerRecord playerRecord = Server_FindPlayer(sid);
		if (playerRecord == null)
		{
			playerRecord = new PlayerRecord
			{
				steamId64 = sid,
				items = Server_CreateDefaults()
			};
			master.Add(playerRecord);
		}
		return playerRecord;
	}

	[Server]
	private PlayerRecord Server_FindPlayer(ulong sid)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/PlayerRecord PlayerProgressManager::Server_FindPlayer(System.UInt64)' called when server was not active");
			return null;
		}
		for (int i = 0; i < master.Count; i++)
		{
			if (master[i].steamId64 == sid)
			{
				return master[i];
			}
		}
		return null;
	}

	[Server]
	private ItemEntry Server_FindOrCreateItem(List<ItemEntry> list, ItemType type)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/ItemEntry PlayerProgressManager::Server_FindOrCreateItem(System.Collections.Generic.List`1<PlayerProgressManager/ItemEntry>,ItemType)' called when server was not active");
			return null;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].type == type)
			{
				return list[i];
			}
		}
		ItemEntry itemEntry = new ItemEntry
		{
			type = type,
			level = 0
		};
		list.Add(itemEntry);
		return itemEntry;
	}

	[Server]
	private void Server_PackForClient(PlayerRecord rec, out List<ItemType> types, out List<int> levels)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_PackForClient(PlayerProgressManager/PlayerRecord,System.Collections.Generic.List`1<ItemType>&,System.Collections.Generic.List`1<System.Int32>&)' called when server was not active");
			types = null;
			levels = null;
			return;
		}
		types = new List<ItemType>(rec.items.Count);
		levels = new List<int>(rec.items.Count);
		for (int i = 0; i < rec.items.Count; i++)
		{
			types.Add(rec.items[i].type);
			levels.Add(rec.items[i].level);
		}
	}

	[Server]
	private List<ItemEntry> Server_CreateDefaults()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Collections.Generic.List`1<PlayerProgressManager/ItemEntry> PlayerProgressManager::Server_CreateDefaults()' called when server was not active");
			return null;
		}
		return new List<ItemEntry>
		{
			new ItemEntry
			{
				type = ItemType.Shovel,
				level = 1
			},
			new ItemEntry
			{
				type = ItemType.Pickaxe,
				level = 0
			},
			new ItemEntry
			{
				type = ItemType.Dynamite,
				level = 0
			},
			new ItemEntry
			{
				type = ItemType.Detector,
				level = 1
			},
			new ItemEntry
			{
				type = ItemType.Jackhammer,
				level = 0
			}
		};
	}

	[Server]
	private List<ItemEntry> Server_GetSharedItems()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Collections.Generic.List`1<PlayerProgressManager/ItemEntry> PlayerProgressManager::Server_GetSharedItems()' called when server was not active");
			return null;
		}
		if (sharedItems.Count == 0)
		{
			sharedItems = Server_CreateDefaults();
		}
		return sharedItems;
	}

	[Server]
	private void Server_PackFromList(List<ItemEntry> list, out List<ItemType> types, out List<int> levels)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_PackFromList(System.Collections.Generic.List`1<PlayerProgressManager/ItemEntry>,System.Collections.Generic.List`1<ItemType>&,System.Collections.Generic.List`1<System.Int32>&)' called when server was not active");
			types = null;
			levels = null;
			return;
		}
		types = new List<ItemType>(list.Count);
		levels = new List<int>(list.Count);
		for (int i = 0; i < list.Count; i++)
		{
			types.Add(list[i].type);
			levels.Add(list[i].level);
		}
	}

	[Server]
	public void Server_SavePlayerBag(ulong steamId, List<BagItemEntry> bagItems)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerProgressManager::Server_SavePlayerBag(System.UInt64,System.Collections.Generic.List`1<PlayerProgressManager/BagItemEntry>)' called when server was not active");
			return;
		}
		PlayerBagRecord playerBagRecord = Server_GetOrCreateBagRecord(steamId);
		playerBagRecord.bagItems.Clear();
		foreach (BagItemEntry bagItem in bagItems)
		{
			if (!string.IsNullOrEmpty(bagItem.itemId) && bagItem.count > 0)
			{
				playerBagRecord.bagItems.Add(new BagItemEntry(bagItem.itemId, bagItem.count));
			}
		}
	}

	[Server]
	public List<BagItemEntry> Server_GetPlayerBag(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Collections.Generic.List`1<PlayerProgressManager/BagItemEntry> PlayerProgressManager::Server_GetPlayerBag(System.UInt64)' called when server was not active");
			return null;
		}
		return Server_FindBagRecord(steamId)?.bagItems ?? new List<BagItemEntry>();
	}

	[Server]
	private PlayerBagRecord Server_GetOrCreateBagRecord(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/PlayerBagRecord PlayerProgressManager::Server_GetOrCreateBagRecord(System.UInt64)' called when server was not active");
			return null;
		}
		PlayerBagRecord playerBagRecord = Server_FindBagRecord(steamId);
		if (playerBagRecord == null)
		{
			playerBagRecord = new PlayerBagRecord
			{
				steamId64 = steamId
			};
			playerBagRecords.Add(playerBagRecord);
		}
		return playerBagRecord;
	}

	[Server]
	private PlayerBagRecord Server_FindBagRecord(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/PlayerBagRecord PlayerProgressManager::Server_FindBagRecord(System.UInt64)' called when server was not active");
			return null;
		}
		for (int i = 0; i < playerBagRecords.Count; i++)
		{
			if (playerBagRecords[i].steamId64 == steamId)
			{
				return playerBagRecords[i];
			}
		}
		return null;
	}

	[Command(requiresAuthority = false)]
	public void CmdSavePlayerBag(List<string> itemIds, List<int> itemCounts, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSavePlayerBag__List_00601__List_00601__NetworkConnectionToClient(itemIds, itemCounts, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, itemIds);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, itemCounts);
		SendCommandInternal("System.Void PlayerProgressManager::CmdSavePlayerBag(System.Collections.Generic.List`1<System.String>,System.Collections.Generic.List`1<System.Int32>,Mirror.NetworkConnectionToClient)", -2004883480, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdRequestBagLoad(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestBagLoad__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PlayerProgressManager::CmdRequestBagLoad(Mirror.NetworkConnectionToClient)", -888573718, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetLoadBagData(NetworkConnectionToClient target, List<string> itemIds, List<int> itemCounts)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, itemIds);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, itemCounts);
		SendTargetRPCInternal(target, "System.Void PlayerProgressManager::TargetLoadBagData(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<System.String>,System.Collections.Generic.List`1<System.Int32>)", -736866349, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private ItemEntry FindItem(List<ItemEntry> list, ItemType type)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].type == type)
			{
				return list[i];
			}
		}
		return null;
	}

	private ulong GetSteamId64()
	{
		UnityEngine.Random.Range(100000, 999999);
		return SteamUser.GetSteamID().m_SteamID;
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		ProgressSaveData progressSaveData = new ProgressSaveData();
		for (int i = 0; i < sharedItems.Count; i++)
		{
			progressSaveData.sharedItems.Add(new ItemEntry
			{
				type = sharedItems[i].type,
				level = sharedItems[i].level
			});
		}
		foreach (PlayerBagRecord playerBagRecord2 in playerBagRecords)
		{
			PlayerBagRecord playerBagRecord = new PlayerBagRecord
			{
				steamId64 = playerBagRecord2.steamId64,
				bagItems = new List<BagItemEntry>()
			};
			foreach (BagItemEntry bagItem in playerBagRecord2.bagItems)
			{
				playerBagRecord.bagItems.Add(new BagItemEntry(bagItem.itemId, bagItem.count));
			}
			progressSaveData.playerBags.Add(playerBagRecord);
		}
		foreach (PlayerStatusRecord playerStatusRecord in playerStatusRecords)
		{
			progressSaveData.playerStatuses.Add(new PlayerStatusRecord
			{
				steamId64 = playerStatusRecord.steamId64,
				isInDigsite = playerStatusRecord.isInDigsite,
				customizationIDs = playerStatusRecord.customizationIDs
			});
		}
		Debug.Log($"[PlayerProgressManager] Save - {progressSaveData.sharedItems.Count} item, {progressSaveData.playerBags.Count} player bag, {progressSaveData.playerStatuses.Count} player status kaydedildi");
		return progressSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is ProgressSaveData progressSaveData))
		{
			Debug.LogWarning("[PlayerProgressManager] Load basarisiz - gecersiz data");
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			Debug.Log("[PlayerProgressManager] Client - load atlaniyor, RPC ile sync olacak");
			return Task.CompletedTask;
		}
		sharedItems.Clear();
		for (int i = 0; i < progressSaveData.sharedItems.Count; i++)
		{
			sharedItems.Add(new ItemEntry
			{
				type = progressSaveData.sharedItems[i].type,
				level = progressSaveData.sharedItems[i].level
			});
		}
		playerBagRecords.Clear();
		if (progressSaveData.playerBags != null)
		{
			foreach (PlayerBagRecord playerBag in progressSaveData.playerBags)
			{
				PlayerBagRecord playerBagRecord = new PlayerBagRecord
				{
					steamId64 = playerBag.steamId64,
					bagItems = new List<BagItemEntry>()
				};
				foreach (BagItemEntry bagItem in playerBag.bagItems)
				{
					playerBagRecord.bagItems.Add(new BagItemEntry(bagItem.itemId, bagItem.count));
				}
				playerBagRecords.Add(playerBagRecord);
			}
		}
		playerStatusRecords.Clear();
		if (progressSaveData.playerStatuses != null)
		{
			foreach (PlayerStatusRecord playerStatus in progressSaveData.playerStatuses)
			{
				playerStatusRecords.Add(new PlayerStatusRecord
				{
					steamId64 = playerStatus.steamId64,
					isInDigsite = playerStatus.isInDigsite,
					customizationIDs = playerStatus.customizationIDs
				});
			}
		}
		if (NetworkServer.active)
		{
			Server_PackFromList(sharedItems, out var types, out var levels);
			for (int j = 0; j < sharedItems.Count; j++)
			{
				RpcSyncSharedLevels(types, levels, sharedItems[j].type, sharedItems[j].level);
			}
		}
		Debug.Log($"[PlayerProgressManager] Load - {progressSaveData.sharedItems.Count} item, {playerBagRecords.Count} player bag, {playerStatusRecords.Count} player status yuklendi");
		return Task.CompletedTask;
	}

	private void OnEnable()
	{
		SaveLoadManager.Subscribe(this, 30);
		Debug.Log("[PlayerProgressManager] SaveLoadManager'a subscribe olundu");
	}

	private void OnDisable()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcNotifyDigsiteStatusChanged__UInt64__Boolean(ulong steamId, bool isInDigsite)
	{
		OnPlayerDigsiteStatusChanged?.Invoke(steamId, isInDigsite);
	}

	protected static void InvokeUserCode_RpcNotifyDigsiteStatusChanged__UInt64__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyDigsiteStatusChanged called on server.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_RpcNotifyDigsiteStatusChanged__UInt64__Boolean(reader.ReadVarULong(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdRequestInit__UInt64__NetworkConnectionToClient(ulong sid, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			Debug.LogWarning("sender NULL");
			return;
		}
		Server_MapSet(sender.connectionId, sid);
		if (sid != 0L)
		{
			Server_MigrateZeroIdRecords(sid);
		}
		if (useSharedUpgrades)
		{
			List<ItemEntry> list = Server_GetSharedItems();
			Server_PackFromList(list, out var types, out var levels);
			TargetInitLocalData(sender, types, levels);
		}
		else
		{
			PlayerRecord rec = Server_GetOrCreatePlayer(sid);
			Server_PackForClient(rec, out var types2, out var levels2);
			TargetInitLocalData(sender, types2, levels2);
		}
	}

	protected static void InvokeUserCode_CmdRequestInit__UInt64__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestInit called on client.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_CmdRequestInit__UInt64__NetworkConnectionToClient(reader.ReadVarULong(), senderConnection);
		}
	}

	protected void UserCode_TargetInitLocalData__NetworkConnectionToClient__List_00601__List_00601(NetworkConnectionToClient target, List<ItemType> types, List<int> levels)
	{
		localItemLevels.Clear();
		int num = Mathf.Min(types.Count, levels.Count);
		for (int i = 0; i < num; i++)
		{
			localItemLevels.Add(new ItemEntry
			{
				type = types[i],
				level = levels[i]
			});
		}
		initDone = true;
		for (int j = 0; j < localItemLevels.Count; j++)
		{
			OnMyLevelChanged?.Invoke(localItemLevels[j].type, localItemLevels[j].level);
		}
	}

	protected static void InvokeUserCode_TargetInitLocalData__NetworkConnectionToClient__List_00601__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetInitLocalData called on server.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_TargetInitLocalData__NetworkConnectionToClient__List_00601__List_00601(null, GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader));
		}
	}

	protected void UserCode_CmdIncreaseLevel__ItemType__Int32__NetworkConnectionToClient(ItemType type, int amount, NetworkConnectionToClient sender)
	{
		if (sender != null)
		{
			ulong num = Server_MapGetSteamId(sender.connectionId);
			if (num != 0L)
			{
				Server_IncreaseLevel(num, type, amount, sender);
			}
		}
	}

	protected static void InvokeUserCode_CmdIncreaseLevel__ItemType__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdIncreaseLevel called on client.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_CmdIncreaseLevel__ItemType__Int32__NetworkConnectionToClient(GeneratedNetworkCode._Read_ItemType(reader), reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_RpcNotifyLevelChanged__UInt64__ItemType__Int32(ulong sid, ItemType type, int newLevel)
	{
		OnAnyPlayerLevelChanged?.Invoke(sid, type, newLevel);
		if (sid == localSteamId)
		{
			ItemEntry itemEntry = FindItem(localItemLevels, type);
			if (itemEntry != null)
			{
				itemEntry.level = newLevel;
			}
			OnMyLevelChanged?.Invoke(type, newLevel);
		}
	}

	protected static void InvokeUserCode_RpcNotifyLevelChanged__UInt64__ItemType__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyLevelChanged called on server.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_RpcNotifyLevelChanged__UInt64__ItemType__Int32(reader.ReadVarULong(), GeneratedNetworkCode._Read_ItemType(reader), reader.ReadVarInt());
		}
	}

	protected void UserCode_RpcSyncSharedLevels__List_00601__List_00601__ItemType__Int32(List<ItemType> types, List<int> levels, ItemType changedType, int newLevel)
	{
		localItemLevels.Clear();
		int num = Mathf.Min(types.Count, levels.Count);
		for (int i = 0; i < num; i++)
		{
			localItemLevels.Add(new ItemEntry
			{
				type = types[i],
				level = levels[i]
			});
		}
		OnAnyPlayerLevelChanged?.Invoke(0uL, changedType, newLevel);
		OnMyLevelChanged?.Invoke(changedType, newLevel);
	}

	protected static void InvokeUserCode_RpcSyncSharedLevels__List_00601__List_00601__ItemType__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSyncSharedLevels called on server.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_RpcSyncSharedLevels__List_00601__List_00601__ItemType__Int32(GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader), GeneratedNetworkCode._Read_ItemType(reader), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdSavePlayerBag__List_00601__List_00601__NetworkConnectionToClient(List<string> itemIds, List<int> itemCounts, NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			return;
		}
		ulong num = Server_MapGetSteamId(sender.connectionId);
		if (num == 0L)
		{
			num = (ulong)sender.connectionId + 1uL;
			Server_MapSet(sender.connectionId, num);
		}
		List<BagItemEntry> list = new List<BagItemEntry>();
		int num2 = Mathf.Min(itemIds.Count, itemCounts.Count);
		for (int i = 0; i < num2; i++)
		{
			if (!string.IsNullOrEmpty(itemIds[i]) && itemCounts[i] > 0)
			{
				list.Add(new BagItemEntry(itemIds[i], itemCounts[i]));
			}
		}
		Server_SavePlayerBag(num, list);
	}

	protected static void InvokeUserCode_CmdSavePlayerBag__List_00601__List_00601__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSavePlayerBag called on client.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_CmdSavePlayerBag__List_00601__List_00601__NetworkConnectionToClient(GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader), senderConnection);
		}
	}

	protected void UserCode_CmdRequestBagLoad__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			return;
		}
		ulong num = Server_MapGetSteamId(sender.connectionId);
		if (num == 0L)
		{
			num = (ulong)sender.connectionId + 1uL;
			Server_MapSet(sender.connectionId, num);
		}
		List<BagItemEntry> list = Server_GetPlayerBag(num);
		List<string> list2 = new List<string>();
		List<int> list3 = new List<int>();
		foreach (BagItemEntry item in list)
		{
			list2.Add(item.itemId);
			list3.Add(item.count);
		}
		TargetLoadBagData(sender, list2, list3);
	}

	protected static void InvokeUserCode_CmdRequestBagLoad__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestBagLoad called on client.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_CmdRequestBagLoad__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_TargetLoadBagData__NetworkConnectionToClient__List_00601__List_00601(NetworkConnectionToClient target, List<string> itemIds, List<int> itemCounts)
	{
		if (GameManager.Instance?.localBag != null)
		{
			GameManager.Instance.localBag.LoadBagFromServer(itemIds, itemCounts);
		}
		else
		{
			Debug.LogWarning("[PlayerProgressManager] localBag bulunamadı, bag load başarısız");
		}
	}

	protected static void InvokeUserCode_TargetLoadBagData__NetworkConnectionToClient__List_00601__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetLoadBagData called on server.");
		}
		else
		{
			((PlayerProgressManager)obj).UserCode_TargetLoadBagData__NetworkConnectionToClient__List_00601__List_00601(null, GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader));
		}
	}

	static PlayerProgressManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::CmdRequestInit(System.UInt64,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestInit__UInt64__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::CmdIncreaseLevel(ItemType,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdIncreaseLevel__ItemType__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::CmdSavePlayerBag(System.Collections.Generic.List`1<System.String>,System.Collections.Generic.List`1<System.Int32>,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSavePlayerBag__List_00601__List_00601__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::CmdRequestBagLoad(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestBagLoad__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::RpcNotifyDigsiteStatusChanged(System.UInt64,System.Boolean)", InvokeUserCode_RpcNotifyDigsiteStatusChanged__UInt64__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::RpcNotifyLevelChanged(System.UInt64,ItemType,System.Int32)", InvokeUserCode_RpcNotifyLevelChanged__UInt64__ItemType__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::RpcSyncSharedLevels(System.Collections.Generic.List`1<ItemType>,System.Collections.Generic.List`1<System.Int32>,ItemType,System.Int32)", InvokeUserCode_RpcSyncSharedLevels__List_00601__List_00601__ItemType__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::TargetInitLocalData(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<ItemType>,System.Collections.Generic.List`1<System.Int32>)", InvokeUserCode_TargetInitLocalData__NetworkConnectionToClient__List_00601__List_00601);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerProgressManager), "System.Void PlayerProgressManager::TargetLoadBagData(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<System.String>,System.Collections.Generic.List`1<System.Int32>)", InvokeUserCode_TargetLoadBagData__NetworkConnectionToClient__List_00601__List_00601);
	}
}
