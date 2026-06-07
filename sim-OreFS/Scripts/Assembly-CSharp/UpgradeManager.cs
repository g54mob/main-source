using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class UpgradeSaveData
	{
		public List<UpgradeNodeState> globalStates = new List<UpgradeNodeState>();
	}

	[Serializable]
	public class PlayerEquipmentRecord
	{
		public ulong steamId64;

		public List<UpgradeNodeState> equipmentStates = new List<UpgradeNodeState>();
	}

	[Serializable]
	public class ConnMap
	{
		public int connectionId;

		public ulong steamId64;
	}

	[Header("Default Values (No Save/Load)")]
	[SerializeField]
	private List<UpgradeNodeState> defaultUpgradeStates = new List<UpgradeNodeState>();

	private readonly SyncList<UpgradeNodeState> _globalUpgradeStates = new SyncList<UpgradeNodeState>();

	private List<PlayerEquipmentRecord> _playerEquipmentMaster = new List<PlayerEquipmentRecord>();

	private List<ConnMap> _connMap = new List<ConnMap>();

	[HideInInspector]
	public List<UpgradeNodeState> localEquipmentStates = new List<UpgradeNodeState>();

	public UnityEvent<UpgradeType, int> onGlobalUpgradeChanged;

	public UnityEvent<UpgradeType, int> onMyEquipmentUpgradeChanged;

	public static Action<UpgradeType, int> OnAnyUpgradeChanged;

	private Dictionary<UpgradeType, UpgradeGroupSO> _groupCache = new Dictionary<UpgradeType, UpgradeGroupSO>();

	private Dictionary<UpgradeCategory, UpgradeTabSO> _tabCache = new Dictionary<UpgradeCategory, UpgradeTabSO>();

	[Header("Shovel Stats")]
	public ToolLevelTable shovelTable = new ToolLevelTable
	{
		levels = new List<ToolLevelEntry>
		{
			new ToolLevelEntry
			{
				level = 1,
				size = 1.4f,
				speed = 1f,
				damage = 10f
			},
			new ToolLevelEntry
			{
				level = 2,
				size = 1.8f,
				speed = 1.1f,
				damage = 15f
			},
			new ToolLevelEntry
			{
				level = 3,
				size = 2.2f,
				speed = 1.2f,
				damage = 20f
			},
			new ToolLevelEntry
			{
				level = 4,
				size = 2.6f,
				speed = 1.3f,
				damage = 25f
			}
		}
	};

	[Header("Pickaxe Stats")]
	public ToolLevelTable pickaxeTable = new ToolLevelTable
	{
		levels = new List<ToolLevelEntry>
		{
			new ToolLevelEntry
			{
				level = 1,
				size = 1.2f,
				speed = 1f,
				damage = 15f
			},
			new ToolLevelEntry
			{
				level = 2,
				size = 1.6f,
				speed = 1.1f,
				damage = 20f
			},
			new ToolLevelEntry
			{
				level = 3,
				size = 2f,
				speed = 1.2f,
				damage = 25f
			},
			new ToolLevelEntry
			{
				level = 4,
				size = 2.4f,
				speed = 1.3f,
				damage = 30f
			}
		}
	};

	[Header("Jackhammer Stats")]
	public ToolLevelTable jackhammerTable = new ToolLevelTable
	{
		levels = new List<ToolLevelEntry>
		{
			new ToolLevelEntry
			{
				level = 1,
				size = 1f,
				speed = 1.5f,
				damage = 25f
			},
			new ToolLevelEntry
			{
				level = 2,
				size = 1.3f,
				speed = 1.7f,
				damage = 35f
			},
			new ToolLevelEntry
			{
				level = 3,
				size = 1.6f,
				speed = 1.9f,
				damage = 45f
			},
			new ToolLevelEntry
			{
				level = 4,
				size = 1.9f,
				speed = 2.1f,
				damage = 55f
			}
		}
	};

	[Header("Detector Stats")]
	public DetectorLevelTable detectorTable = new DetectorLevelTable
	{
		levels = new List<DetectorLevelEntry>
		{
			new DetectorLevelEntry
			{
				level = 1,
				scanDistance = 5f,
				scanRadius = 1f
			},
			new DetectorLevelEntry
			{
				level = 2,
				scanDistance = 8f,
				scanRadius = 1.5f
			},
			new DetectorLevelEntry
			{
				level = 3,
				scanDistance = 12f,
				scanRadius = 2f
			},
			new DetectorLevelEntry
			{
				level = 4,
				scanDistance = 16f,
				scanRadius = 2.5f
			}
		}
	};

	[Header("Dynamite Stats")]
	public DynamiteLevelTable dynamiteTable = new DynamiteLevelTable
	{
		levels = new List<DynamiteLevelEntry>
		{
			new DynamiteLevelEntry
			{
				level = 1,
				size = 2.5f
			},
			new DynamiteLevelEntry
			{
				level = 2,
				size = 3f
			},
			new DynamiteLevelEntry
			{
				level = 3,
				size = 3.5f
			},
			new DynamiteLevelEntry
			{
				level = 4,
				size = 4f
			}
		}
	};

	[Header("Contract Capacity Stats")]
	public ContractCapacityLevelTable contractCapacityTable = new ContractCapacityLevelTable
	{
		levels = new List<ContractCapacityLevelEntry>
		{
			new ContractCapacityLevelEntry
			{
				level = 1,
				capacity = 3
			},
			new ContractCapacityLevelEntry
			{
				level = 2,
				capacity = 4
			},
			new ContractCapacityLevelEntry
			{
				level = 3,
				capacity = 5
			}
		}
	};

	[Header("Player Damage Values")]
	public float shovelPlayerDamageValue = 10f;

	public float pickaxePlayerDamageValue = 15f;

	public float jackhammerPlayerDamageValue = 25f;

	private ulong _localSteamId;

	private bool _initDone;

	public static UpgradeManager Instance { get; private set; }

	public string SaveID => "upgrade-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(UpgradeSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		InitCache();
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void InitCache()
	{
		ScriptableListManager instance = ScriptableListManager.Instance;
		if (instance == null)
		{
			return;
		}
		_groupCache.Clear();
		_tabCache.Clear();
		foreach (UpgradeGroupSO allUpgradeGroup in instance.AllUpgradeGroups)
		{
			if (allUpgradeGroup != null && allUpgradeGroup.upgradeType != UpgradeType.None)
			{
				_groupCache[allUpgradeGroup.upgradeType] = allUpgradeGroup;
			}
		}
		foreach (UpgradeTabSO allUpgradeTab in instance.AllUpgradeTabs)
		{
			if (allUpgradeTab != null)
			{
				_tabCache[allUpgradeTab.category] = allUpgradeTab;
			}
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		ServerInitGlobalStates();
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		SyncList<UpgradeNodeState> globalUpgradeStates = _globalUpgradeStates;
		globalUpgradeStates.Callback = (Action<SyncList<UpgradeNodeState>.Operation, int, UpgradeNodeState, UpgradeNodeState>)Delegate.Combine(globalUpgradeStates.Callback, new Action<SyncList<UpgradeNodeState>.Operation, int, UpgradeNodeState, UpgradeNodeState>(OnGlobalStatesCallback));
		for (int i = 0; i < _globalUpgradeStates.Count; i++)
		{
			UpgradeNodeState upgradeNodeState = _globalUpgradeStates[i];
			onGlobalUpgradeChanged?.Invoke(upgradeNodeState.upgradeType, upgradeNodeState.currentLevel);
		}
		StartCoroutine(InitEquipmentWhenReady());
	}

	private IEnumerator InitEquipmentWhenReady()
	{
		while (!base.isClient || NetworkClient.connection == null || !NetworkClient.connection.isReady)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0.2f);
		_localSteamId = GetSteamId64();
		CmdRequestEquipmentInit(_localSteamId);
	}

	private void OnGlobalStatesCallback(SyncList<UpgradeNodeState>.Operation op, int index, UpgradeNodeState oldItem, UpgradeNodeState newItem)
	{
		if ((uint)op == 1u || (uint)op == 0u)
		{
			onGlobalUpgradeChanged?.Invoke(newItem.upgradeType, newItem.currentLevel);
			OnAnyUpgradeChanged?.Invoke(newItem.upgradeType, newItem.currentLevel);
		}
	}

	public void RequestUpgrade(UpgradeType upgradeType)
	{
		if (_groupCache.ContainsKey(upgradeType))
		{
			CmdRequestGlobalUpgrade(upgradeType);
		}
	}

	public int GetUpgradeLevel(UpgradeType upgradeType)
	{
		return GetGlobalUpgradeLevel(upgradeType);
	}

	public int GetGlobalUpgradeLevel(UpgradeType upgradeType)
	{
		for (int i = 0; i < _globalUpgradeStates.Count; i++)
		{
			if (_globalUpgradeStates[i].upgradeType == upgradeType)
			{
				return _globalUpgradeStates[i].currentLevel;
			}
		}
		return 0;
	}

	public int GetEquipmentUpgradeLevel(UpgradeType upgradeType)
	{
		if (PlayerProgressManager.Instance != null)
		{
			ItemType itemTypeFromUpgradeType = GetItemTypeFromUpgradeType(upgradeType);
			if (itemTypeFromUpgradeType != ItemType.None)
			{
				return PlayerProgressManager.Instance.GetLevel(itemTypeFromUpgradeType);
			}
		}
		for (int i = 0; i < localEquipmentStates.Count; i++)
		{
			if (localEquipmentStates[i].upgradeType == upgradeType)
			{
				return localEquipmentStates[i].currentLevel;
			}
		}
		return 0;
	}

	private ItemType GetItemTypeFromUpgradeType(UpgradeType upgradeType)
	{
		return upgradeType switch
		{
			UpgradeType.Shovel => ItemType.Shovel, 
			UpgradeType.Pickaxe => ItemType.Pickaxe, 
			UpgradeType.Detector => ItemType.Detector, 
			UpgradeType.Dynamite => ItemType.Dynamite, 
			UpgradeType.Jackhammer => ItemType.Jackhammer, 
			_ => ItemType.None, 
		};
	}

	public bool CanUpgrade(UpgradeType upgradeType)
	{
		if (!_groupCache.TryGetValue(upgradeType, out var value))
		{
			return false;
		}
		int upgradeLevel = GetUpgradeLevel(upgradeType);
		if (upgradeLevel >= value.MaxLevel)
		{
			return false;
		}
		UpgradeLevelData levelData = value.GetLevelData(upgradeLevel + 1);
		if (levelData == null)
		{
			return false;
		}
		if (FactoryManager.Instance == null)
		{
			return false;
		}
		if (FactoryManager.Instance.Level < levelData.requiredFactoryLevel)
		{
			return false;
		}
		if (FactoryManager.Instance.Money < levelData.cost)
		{
			return false;
		}
		return true;
	}

	public UpgradeGroupSO GetGroupSO(UpgradeType upgradeType)
	{
		_groupCache.TryGetValue(upgradeType, out var value);
		return value;
	}

	public UpgradeTabSO GetTabSO(UpgradeCategory category)
	{
		_tabCache.TryGetValue(category, out var value);
		return value;
	}

	public ToolLevelEntry GetShovelStats(int level)
	{
		return shovelTable.GetFor(level);
	}

	public ToolLevelEntry GetPickaxeStats(int level)
	{
		return pickaxeTable.GetFor(level);
	}

	public DetectorLevelEntry GetDetectorStats(int level)
	{
		return detectorTable.GetFor(level);
	}

	public ToolLevelEntry GetJackhammerStats(int level)
	{
		return jackhammerTable.GetFor(level);
	}

	public DynamiteLevelEntry GetDynamiteStats(int level)
	{
		return dynamiteTable.GetFor(level);
	}

	public ContractCapacityLevelEntry GetContractCapacityStats(int level)
	{
		return contractCapacityTable.GetFor(level);
	}

	public ToolLevelEntry GetToolStats(ItemType itemType, int level)
	{
		return itemType switch
		{
			ItemType.Shovel => GetShovelStats(level), 
			ItemType.Pickaxe => GetPickaxeStats(level), 
			ItemType.Jackhammer => GetJackhammerStats(level), 
			_ => new ToolLevelEntry
			{
				level = 1,
				size = 1.5f,
				speed = 1f,
				damage = 1f
			}, 
		};
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestGlobalUpgrade(UpgradeType upgradeType, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestGlobalUpgrade__UpgradeType__NetworkConnectionToClient(upgradeType, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_UpgradeType(writer, upgradeType);
		SendCommandInternal("System.Void UpgradeManager::CmdRequestGlobalUpgrade(UpgradeType,Mirror.NetworkConnectionToClient)", 587726487, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestEquipmentUpgrade(UpgradeType upgradeType, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestEquipmentUpgrade__UpgradeType__NetworkConnectionToClient(upgradeType, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_UpgradeType(writer, upgradeType);
		SendCommandInternal("System.Void UpgradeManager::CmdRequestEquipmentUpgrade(UpgradeType,Mirror.NetworkConnectionToClient)", -1675127210, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestEquipmentInit(ulong steamId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestEquipmentInit__UInt64__NetworkConnectionToClient(steamId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarULong(steamId);
		SendCommandInternal("System.Void UpgradeManager::CmdRequestEquipmentInit(System.UInt64,Mirror.NetworkConnectionToClient)", 1980985915, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerInitGlobalStates()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void UpgradeManager::ServerInitGlobalStates()' called when server was not active");
			return;
		}
		foreach (UpgradeNodeState defaultUpgradeState in defaultUpgradeStates)
		{
			if (defaultUpgradeState.upgradeType != UpgradeType.None && _groupCache.TryGetValue(defaultUpgradeState.upgradeType, out var value) && (value.category == UpgradeCategory.Factory || value.category == UpgradeCategory.Licenses || value.category == UpgradeCategory.Equipments))
			{
				_globalUpgradeStates.Add(new UpgradeNodeState(defaultUpgradeState.upgradeType, defaultUpgradeState.currentLevel));
			}
		}
		foreach (UpgradeGroupSO value2 in _groupCache.Values)
		{
			if (value2.category != UpgradeCategory.Factory && value2.category != UpgradeCategory.Licenses && value2.category != UpgradeCategory.Equipments)
			{
				continue;
			}
			bool flag = false;
			for (int i = 0; i < _globalUpgradeStates.Count; i++)
			{
				if (_globalUpgradeStates[i].upgradeType == value2.upgradeType)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				_globalUpgradeStates.Add(new UpgradeNodeState(value2.upgradeType, 0));
			}
		}
	}

	[Server]
	private void ServerProcessGlobalUpgrade(UpgradeType upgradeType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void UpgradeManager::ServerProcessGlobalUpgrade(UpgradeType)' called when server was not active");
		}
		else
		{
			if (!_groupCache.TryGetValue(upgradeType, out var value))
			{
				return;
			}
			int num = 0;
			int num2 = -1;
			for (int i = 0; i < _globalUpgradeStates.Count; i++)
			{
				if (_globalUpgradeStates[i].upgradeType == upgradeType)
				{
					num = _globalUpgradeStates[i].currentLevel;
					num2 = i;
					break;
				}
			}
			if (num >= value.MaxLevel)
			{
				return;
			}
			UpgradeLevelData levelData = value.GetLevelData(num + 1);
			if (levelData == null || FactoryManager.Instance.Level < levelData.requiredFactoryLevel || !FactoryManager.Instance.TryPurchase(levelData.cost, EconomyType.EconomyType_Upgrade))
			{
				return;
			}
			int num3 = num + 1;
			if (num2 >= 0)
			{
				_globalUpgradeStates[num2] = new UpgradeNodeState(upgradeType, num3);
			}
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				onGlobalUpgradeChanged?.Invoke(upgradeType, num3);
				OnAnyUpgradeChanged?.Invoke(upgradeType, num3);
				if (value.category == UpgradeCategory.Equipments && value.linkedItemType != ItemType.None && PlayerProgressManager.Instance != null)
				{
					PlayerProgressManager.Instance.IncreaseLevel(value.linkedItemType);
				}
			}
		}
	}

	[Server]
	private void ServerProcessEquipmentUpgrade(UpgradeType upgradeType, ulong steamId, NetworkConnectionToClient targetConn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void UpgradeManager::ServerProcessEquipmentUpgrade(UpgradeType,System.UInt64,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (!_groupCache.TryGetValue(upgradeType, out var value) || value.category != UpgradeCategory.Equipments)
			{
				return;
			}
			PlayerEquipmentRecord record = ServerGetOrCreateEquipmentRecord(steamId);
			int num = ServerGetEquipmentLevel(record, upgradeType);
			if (num < value.MaxLevel)
			{
				UpgradeLevelData levelData = value.GetLevelData(num + 1);
				if (levelData != null && FactoryManager.Instance.Level >= levelData.requiredFactoryLevel && FactoryManager.Instance.TryPurchase(levelData.cost, EconomyType.EconomyType_Upgrade))
				{
					int level = num + 1;
					ServerSetEquipmentLevel(record, upgradeType, level);
				}
			}
		}
	}

	[Server]
	private int ServerGetEquipmentLevel(PlayerEquipmentRecord record, UpgradeType upgradeType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 UpgradeManager::ServerGetEquipmentLevel(UpgradeManager/PlayerEquipmentRecord,UpgradeType)' called when server was not active");
			return default(int);
		}
		for (int i = 0; i < record.equipmentStates.Count; i++)
		{
			if (record.equipmentStates[i].upgradeType == upgradeType)
			{
				return record.equipmentStates[i].currentLevel;
			}
		}
		if (PlayerProgressManager.Instance != null)
		{
			ItemType itemTypeFromUpgradeType = GetItemTypeFromUpgradeType(upgradeType);
			if (itemTypeFromUpgradeType != ItemType.None)
			{
				PlayerProgressManager.PlayerRecord playerRecord = FindPlayerRecordBySteamId(record.steamId64);
				if (playerRecord != null)
				{
					for (int j = 0; j < playerRecord.items.Count; j++)
					{
						if (playerRecord.items[j].type == itemTypeFromUpgradeType)
						{
							return playerRecord.items[j].level;
						}
					}
				}
			}
		}
		return 0;
	}

	[Server]
	private PlayerProgressManager.PlayerRecord FindPlayerRecordBySteamId(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'PlayerProgressManager/PlayerRecord UpgradeManager::FindPlayerRecordBySteamId(System.UInt64)' called when server was not active");
			return null;
		}
		if (PlayerProgressManager.Instance == null)
		{
			return null;
		}
		for (int i = 0; i < PlayerProgressManager.Instance.master.Count; i++)
		{
			if (PlayerProgressManager.Instance.master[i].steamId64 == steamId)
			{
				return PlayerProgressManager.Instance.master[i];
			}
		}
		return null;
	}

	[Server]
	private void ServerSetEquipmentLevel(PlayerEquipmentRecord record, UpgradeType upgradeType, int level)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void UpgradeManager::ServerSetEquipmentLevel(UpgradeManager/PlayerEquipmentRecord,UpgradeType,System.Int32)' called when server was not active");
			return;
		}
		for (int i = 0; i < record.equipmentStates.Count; i++)
		{
			if (record.equipmentStates[i].upgradeType == upgradeType)
			{
				record.equipmentStates[i] = new UpgradeNodeState(upgradeType, level);
				return;
			}
		}
		record.equipmentStates.Add(new UpgradeNodeState(upgradeType, level));
	}

	[Server]
	private void ServerSendEquipmentStates(PlayerEquipmentRecord record, NetworkConnectionToClient target)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void UpgradeManager::ServerSendEquipmentStates(UpgradeManager/PlayerEquipmentRecord,Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		List<UpgradeType> list = new List<UpgradeType>(record.equipmentStates.Count);
		List<int> list2 = new List<int>(record.equipmentStates.Count);
		for (int i = 0; i < record.equipmentStates.Count; i++)
		{
			list.Add(record.equipmentStates[i].upgradeType);
			list2.Add(record.equipmentStates[i].currentLevel);
		}
		TargetSyncEquipmentStates(target, list, list2);
	}

	[Server]
	private PlayerEquipmentRecord ServerGetOrCreateEquipmentRecord(ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'UpgradeManager/PlayerEquipmentRecord UpgradeManager::ServerGetOrCreateEquipmentRecord(System.UInt64)' called when server was not active");
			return null;
		}
		for (int i = 0; i < _playerEquipmentMaster.Count; i++)
		{
			if (_playerEquipmentMaster[i].steamId64 == steamId)
			{
				return _playerEquipmentMaster[i];
			}
		}
		PlayerEquipmentRecord playerEquipmentRecord = new PlayerEquipmentRecord
		{
			steamId64 = steamId,
			equipmentStates = new List<UpgradeNodeState>()
		};
		_playerEquipmentMaster.Add(playerEquipmentRecord);
		return playerEquipmentRecord;
	}

	[Server]
	private void ServerMapSet(int connId, ulong steamId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void UpgradeManager::ServerMapSet(System.Int32,System.UInt64)' called when server was not active");
			return;
		}
		for (int i = 0; i < _connMap.Count; i++)
		{
			if (_connMap[i].connectionId == connId)
			{
				_connMap[i].steamId64 = steamId;
				return;
			}
		}
		_connMap.Add(new ConnMap
		{
			connectionId = connId,
			steamId64 = steamId
		});
	}

	[Server]
	private ulong ServerGetSteamId(int connId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.UInt64 UpgradeManager::ServerGetSteamId(System.Int32)' called when server was not active");
			return default(ulong);
		}
		for (int i = 0; i < _connMap.Count; i++)
		{
			if (_connMap[i].connectionId == connId)
			{
				return _connMap[i].steamId64;
			}
		}
		return 0uL;
	}

	[TargetRpc]
	private void TargetSyncEquipmentStates(NetworkConnectionToClient target, List<UpgradeType> types, List<int> levels)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CUpgradeType_003E(writer, types);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, levels);
		SendTargetRPCInternal(target, "System.Void UpgradeManager::TargetSyncEquipmentStates(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<UpgradeType>,System.Collections.Generic.List`1<System.Int32>)", -1398353414, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private ulong GetSteamId64()
	{
		try
		{
			return SteamUser.GetSteamID().m_SteamID;
		}
		catch
		{
			return (ulong)(76561197960265728L + UnityEngine.Random.Range(100000, 999999));
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		UpgradeSaveData upgradeSaveData = new UpgradeSaveData();
		for (int i = 0; i < _globalUpgradeStates.Count; i++)
		{
			upgradeSaveData.globalStates.Add(_globalUpgradeStates[i]);
		}
		Debug.Log($"[UpgradeManager] Save - {upgradeSaveData.globalStates.Count} upgrade kaydedildi");
		return upgradeSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is UpgradeSaveData upgradeSaveData))
		{
			Debug.LogWarning("[UpgradeManager] Load basarisiz - gecersiz data");
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			Debug.Log("[UpgradeManager] Client - load atlaniyor, SyncList ile sync olacak");
			return Task.CompletedTask;
		}
		_globalUpgradeStates.Clear();
		for (int i = 0; i < upgradeSaveData.globalStates.Count; i++)
		{
			_globalUpgradeStates.Add(upgradeSaveData.globalStates[i]);
		}
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			for (int j = 0; j < _globalUpgradeStates.Count; j++)
			{
				UpgradeNodeState upgradeNodeState = _globalUpgradeStates[j];
				onGlobalUpgradeChanged?.Invoke(upgradeNodeState.upgradeType, upgradeNodeState.currentLevel);
				OnAnyUpgradeChanged?.Invoke(upgradeNodeState.upgradeType, upgradeNodeState.currentLevel);
			}
		}
		Debug.Log($"[UpgradeManager] Load - {upgradeSaveData.globalStates.Count} upgrade yuklendi");
		return Task.CompletedTask;
	}

	private void OnEnable()
	{
		SaveLoadManager.Subscribe(this, 35);
		Debug.Log("[UpgradeManager] SaveLoadManager'a subscribe olundu");
	}

	public UpgradeManager()
	{
		InitSyncObject(_globalUpgradeStates);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestGlobalUpgrade__UpgradeType__NetworkConnectionToClient(UpgradeType upgradeType, NetworkConnectionToClient sender)
	{
		ServerProcessGlobalUpgrade(upgradeType);
	}

	protected static void InvokeUserCode_CmdRequestGlobalUpgrade__UpgradeType__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestGlobalUpgrade called on client.");
		}
		else
		{
			((UpgradeManager)obj).UserCode_CmdRequestGlobalUpgrade__UpgradeType__NetworkConnectionToClient(GeneratedNetworkCode._Read_UpgradeType(reader), senderConnection);
		}
	}

	protected void UserCode_CmdRequestEquipmentUpgrade__UpgradeType__NetworkConnectionToClient(UpgradeType upgradeType, NetworkConnectionToClient sender)
	{
		NetworkConnectionToClient networkConnectionToClient = sender;
		int connectionId;
		if (sender == null)
		{
			if (NetworkServer.localConnection == null)
			{
				return;
			}
			networkConnectionToClient = NetworkServer.localConnection;
			connectionId = networkConnectionToClient.connectionId;
		}
		else
		{
			connectionId = sender.connectionId;
		}
		ulong num = ServerGetSteamId(connectionId);
		if (num == 0L)
		{
			if (networkConnectionToClient != NetworkServer.localConnection || _localSteamId == 0L)
			{
				return;
			}
			num = _localSteamId;
			ServerMapSet(connectionId, num);
		}
		ServerProcessEquipmentUpgrade(upgradeType, num, networkConnectionToClient);
	}

	protected static void InvokeUserCode_CmdRequestEquipmentUpgrade__UpgradeType__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestEquipmentUpgrade called on client.");
		}
		else
		{
			((UpgradeManager)obj).UserCode_CmdRequestEquipmentUpgrade__UpgradeType__NetworkConnectionToClient(GeneratedNetworkCode._Read_UpgradeType(reader), senderConnection);
		}
	}

	protected void UserCode_CmdRequestEquipmentInit__UInt64__NetworkConnectionToClient(ulong steamId, NetworkConnectionToClient sender)
	{
		if (sender != null)
		{
			ServerMapSet(sender.connectionId, steamId);
			PlayerEquipmentRecord record = ServerGetOrCreateEquipmentRecord(steamId);
			ServerSendEquipmentStates(record, sender);
		}
	}

	protected static void InvokeUserCode_CmdRequestEquipmentInit__UInt64__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestEquipmentInit called on client.");
		}
		else
		{
			((UpgradeManager)obj).UserCode_CmdRequestEquipmentInit__UInt64__NetworkConnectionToClient(reader.ReadVarULong(), senderConnection);
		}
	}

	protected void UserCode_TargetSyncEquipmentStates__NetworkConnectionToClient__List_00601__List_00601(NetworkConnectionToClient target, List<UpgradeType> types, List<int> levels)
	{
		localEquipmentStates.Clear();
		int num = Mathf.Min(types.Count, levels.Count);
		for (int i = 0; i < num; i++)
		{
			localEquipmentStates.Add(new UpgradeNodeState(types[i], levels[i]));
		}
		_initDone = true;
	}

	protected static void InvokeUserCode_TargetSyncEquipmentStates__NetworkConnectionToClient__List_00601__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetSyncEquipmentStates called on server.");
		}
		else
		{
			((UpgradeManager)obj).UserCode_TargetSyncEquipmentStates__NetworkConnectionToClient__List_00601__List_00601(null, GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CUpgradeType_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader));
		}
	}

	static UpgradeManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(UpgradeManager), "System.Void UpgradeManager::CmdRequestGlobalUpgrade(UpgradeType,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestGlobalUpgrade__UpgradeType__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(UpgradeManager), "System.Void UpgradeManager::CmdRequestEquipmentUpgrade(UpgradeType,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestEquipmentUpgrade__UpgradeType__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(UpgradeManager), "System.Void UpgradeManager::CmdRequestEquipmentInit(System.UInt64,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestEquipmentInit__UInt64__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(UpgradeManager), "System.Void UpgradeManager::TargetSyncEquipmentStates(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<UpgradeType>,System.Collections.Generic.List`1<System.Int32>)", InvokeUserCode_TargetSyncEquipmentStates__NetworkConnectionToClient__List_00601__List_00601);
	}
}
