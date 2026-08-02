using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class InventorySaver : NetworkBehaviour
{
	[Header("Player Inventories - Server'da sürekli tutulur")]
	[SerializeField]
	private Dictionary<string, List<InventorySaveData>> allPlayerInventories = new Dictionary<string, List<InventorySaveData>>();

	private Dictionary<string, PlayerInventory> activePlayerInventories = new Dictionary<string, PlayerInventory>();

	public SyncList<PlayerInventorySync> syncedPlayerInventories = new SyncList<PlayerInventorySync>();

	[NonSerialized]
	public Dictionary<string, List<InventorySaveData>> clientSyncedPlayerData = new Dictionary<string, List<InventorySaveData>>();

	[Header("Player Status - Server'da sürekli tutulur")]
	private Dictionary<string, PlayerStatusSaveData> allPlayerStatusData = new Dictionary<string, PlayerStatusSaveData>();

	public SyncList<PlayerStatusSync> syncedPlayerStatus = new SyncList<PlayerStatusSync>();

	[NonSerialized]
	public Dictionary<string, PlayerStatusSaveData> clientSyncedStatusData = new Dictionary<string, PlayerStatusSaveData>();

	[Header("Player Tutorial Progress - Server'da sürekli tutulur")]
	private Dictionary<string, PlayerTutorialSaveData> allPlayerTutorialData = new Dictionary<string, PlayerTutorialSaveData>();

	public SyncList<PlayerTutorialSync> syncedPlayerTutorial = new SyncList<PlayerTutorialSync>();

	[NonSerialized]
	public Dictionary<string, PlayerTutorialSaveData> clientSyncedTutorialData = new Dictionary<string, PlayerTutorialSaveData>();

	public SyncList<TutorialTaskEntry> syncedCommonTasks = new SyncList<TutorialTaskEntry>();

	private bool isDataPreloaded;

	public static InventorySaver Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (!isDataPreloaded)
		{
			LoadAllPlayerDataFromDisk();
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		syncedPlayerInventories.Callback += OnSyncedInventoryChanged;
		syncedPlayerStatus.Callback += OnSyncedStatusChanged;
		syncedPlayerTutorial.Callback += OnSyncedTutorialChanged;
		syncedCommonTasks.Callback += OnSyncedCommonTasksChanged;
		RefreshClientCache();
		RefreshClientStatusCache();
		RefreshClientTutorialCache();
	}

	private void Start()
	{
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveAllPlayerDataToDisk);
			Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadAllPlayerDataFromDisk);
			Singleton<ES3SaveManager>.Instance.OnPreLoad.AddListener(PreloadAllPlayerDataFromDisk);
		}
	}

	[Server]
	public void PreloadAllPlayerDataFromDisk()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::PreloadAllPlayerDataFromDisk()' called when server was not active");
		}
		else
		{
			if (isDataPreloaded)
			{
				return;
			}
			allPlayerInventories.Clear();
			syncedPlayerInventories.Clear();
			allPlayerStatusData.Clear();
			syncedPlayerStatus.Clear();
			allPlayerTutorialData.Clear();
			syncedPlayerTutorial.Clear();
			syncedCommonTasks.Clear();
			if (Singleton<ES3SaveManager>.Instance.KeyExists("SavedPlayersList"))
			{
				foreach (string item in Singleton<ES3SaveManager>.Instance.LoadData("SavedPlayersList", new List<string>()))
				{
					string key = "PlayerInventory_" + item;
					if (Singleton<ES3SaveManager>.Instance.KeyExists(key))
					{
						List<InventorySaveData> value = Singleton<ES3SaveManager>.Instance.LoadData(key, new List<InventorySaveData>());
						allPlayerInventories.Add(item, value);
						UpdateSyncListForPlayer(item);
					}
					string key2 = "PlayerStatus_" + item;
					if (Singleton<ES3SaveManager>.Instance.KeyExists(key2))
					{
						PlayerStatusSaveData value2 = Singleton<ES3SaveManager>.Instance.LoadData<PlayerStatusSaveData>(key2);
						allPlayerStatusData[item] = value2;
						UpdateSyncListForPlayerStatus(item);
					}
					string key3 = "PlayerTutorial_" + item;
					if (Singleton<ES3SaveManager>.Instance.KeyExists(key3))
					{
						PlayerTutorialSaveData value3 = Singleton<ES3SaveManager>.Instance.LoadData<PlayerTutorialSaveData>(key3);
						allPlayerTutorialData[item] = value3;
						UpdateSyncListForPlayerTutorial(item);
					}
				}
			}
			if (Singleton<ES3SaveManager>.Instance.KeyExists("CommonTasks"))
			{
				List<TutorialTaskEntry> list = Singleton<ES3SaveManager>.Instance.LoadData("CommonTasks", new List<TutorialTaskEntry>());
				syncedCommonTasks.Clear();
				foreach (TutorialTaskEntry item2 in list)
				{
					syncedCommonTasks.Add(item2);
				}
			}
			isDataPreloaded = true;
		}
	}

	[Server]
	public void RegisterPlayer(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::RegisterPlayer(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (conn == null || conn.identity == null)
		{
			Debug.LogError("[Inventory] RegisterPlayer FAIL - connection veya identity null!");
			return;
		}
		PlayerInventory component = conn.identity.GetComponent<PlayerInventory>();
		TsPlayerNetworkHelper component2 = conn.identity.GetComponent<TsPlayerNetworkHelper>();
		if (component == null || component2 == null)
		{
			Debug.LogError($"[Inventory] RegisterPlayer FAIL - PlayerInventory: {component != null}, NetworkHelper: {component2 != null}");
			return;
		}
		string steamID = component2.steamID;
		if (string.IsNullOrEmpty(steamID))
		{
			Debug.LogError("[Inventory] RegisterPlayer FAIL - steamID boş!");
		}
		else
		{
			if (activePlayerInventories.ContainsKey(steamID))
			{
				return;
			}
			activePlayerInventories[steamID] = component;
			if (allPlayerInventories.ContainsKey(steamID))
			{
				if (component2.isLocalPlayer)
				{
					LoadSpecificPlayerInventory(component, steamID);
				}
			}
			else if (component2.isLocalPlayer)
			{
				InitializeNewPlayerInventory(steamID, component);
			}
			else
			{
				allPlayerInventories[steamID] = new List<InventorySaveData>();
			}
			UpdateSyncListForPlayer(steamID);
			if (!allPlayerStatusData.ContainsKey(steamID))
			{
				allPlayerStatusData[steamID] = new PlayerStatusSaveData
				{
					hasData = false,
					health = 100f,
					food = 100f,
					water = 100f
				};
			}
			UpdateSyncListForPlayerStatus(steamID);
			if (!allPlayerTutorialData.ContainsKey(steamID))
			{
				allPlayerTutorialData[steamID] = new PlayerTutorialSaveData
				{
					hasData = false,
					currentGroupIndex = 0,
					taskEntries = new List<TutorialTaskEntry>()
				};
			}
			UpdateSyncListForPlayerTutorial(steamID);
			SetupPlayerInventoryEvents(steamID, component);
		}
	}

	public void PullInventoryFromSyncData(string playerID)
	{
		StartCoroutine(PullInventoryCoroutine(playerID));
	}

	private IEnumerator PullInventoryCoroutine(string playerID)
	{
		float elapsed = 0f;
		float timeout = 120f;
		float interval = 0.5f;
		WaitForSeconds wait = new WaitForSeconds(interval);
		while (elapsed < timeout)
		{
			RefreshClientCache();
			bool flag = clientSyncedPlayerData.ContainsKey(playerID);
			List<InventorySaveData> list = (flag ? clientSyncedPlayerData[playerID] : null);
			bool flag2 = list != null && list.Count > 0;
			PlayerInventory playerInventory = null;
			if (TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
			{
				playerInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
			}
			bool flag3 = playerInventory != null && playerInventory.inventorySlotsData != null && playerInventory.inventorySlotsData.Count > 0 && playerInventory.inventoryData != null && playerInventory.inventoryData.Count > 0;
			if (flag2 && flag3)
			{
				ApplyLoadedData(playerInventory, list);
				yield break;
			}
			if (flag && !flag2 && flag3)
			{
				yield break;
			}
			elapsed += interval;
			yield return wait;
		}
		Debug.LogError($"[Inventory] PullInventoryCoroutine TIMEOUT ({timeout}s) - '{playerID}'");
	}

	public void OnPlayerDisconnected(NetworkConnectionToClient conn)
	{
		if (base.isServer)
		{
			SaveDisconnectingPlayerStatus(conn);
			StartCoroutine(HandlePlayerDisconnection(conn));
		}
	}

	[Server]
	private void SaveDisconnectingPlayerStatus(NetworkConnectionToClient conn)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::SaveDisconnectingPlayerStatus(Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (conn?.identity == null)
			{
				return;
			}
			TsPlayerNetworkHelper component = conn.identity.GetComponent<TsPlayerNetworkHelper>();
			if (!(component == null) && !string.IsNullOrEmpty(component.steamID))
			{
				string steamID = component.steamID;
				if (component.isLocalPlayer)
				{
					PlayerStatusSaveData value = CollectPlayerStatus(conn.identity.gameObject);
					allPlayerStatusData[steamID] = value;
				}
				else if (allPlayerStatusData.ContainsKey(steamID))
				{
					PlayerStatusSaveData value2 = allPlayerStatusData[steamID];
					value2.hasData = true;
					value2.posX = conn.identity.transform.position.x;
					value2.posY = conn.identity.transform.position.y;
					value2.posZ = conn.identity.transform.position.z;
					value2.rotX = conn.identity.transform.eulerAngles.x;
					value2.rotY = conn.identity.transform.eulerAngles.y;
					value2.rotZ = conn.identity.transform.eulerAngles.z;
					allPlayerStatusData[steamID] = value2;
				}
				UpdateSyncListForPlayerStatus(steamID);
			}
		}
	}

	private IEnumerator HandlePlayerDisconnection(NetworkConnectionToClient conn)
	{
		yield return new WaitForEndOfFrame();
		string text = null;
		PlayerInventory playerInventory = null;
		foreach (KeyValuePair<string, PlayerInventory> item in activePlayerInventories.ToList())
		{
			if (item.Value == null || item.Value.gameObject == null)
			{
				text = item.Key;
				playerInventory = item.Value;
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			if (playerInventory != null)
			{
				UpdatePlayerInventoryInServer(text, playerInventory);
			}
			activePlayerInventories.Remove(text);
		}
	}

	private void SetupPlayerInventoryEvents(string playerID, PlayerInventory playerInventory)
	{
		if (!(playerInventory == null))
		{
			playerInventory.OnCollectableCollected.RemoveListener(delegate
			{
				OnPlayerInventoryChanged(playerID);
			});
			playerInventory.OnCollectableCollected.AddListener(delegate
			{
				OnPlayerInventoryChanged(playerID);
			});
		}
	}

	private void OnPlayerInventoryChanged(string playerID)
	{
		RequestInventoryUpdate(playerID);
	}

	[Server]
	private void InitializeNewPlayerInventory(string playerID, PlayerInventory playerInventory)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::InitializeNewPlayerInventory(System.String,PlayerInventory)' called when server was not active");
			return;
		}
		List<InventorySaveData> value = ConvertToSaveData(playerInventory.inventorySlotsData);
		allPlayerInventories[playerID] = value;
		UpdateSyncListForPlayer(playerID);
	}

	[Server]
	private void UpdatePlayerInventoryInServer(string playerID, PlayerInventory playerInventory)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::UpdatePlayerInventoryInServer(System.String,PlayerInventory)' called when server was not active");
		}
		else if (playerInventory != null && playerInventory.inventorySlotsData != null)
		{
			List<InventorySaveData> value = ConvertToSaveData(playerInventory.inventorySlotsData);
			allPlayerInventories[playerID] = value;
			UpdateSyncListForPlayer(playerID);
		}
	}

	[Server]
	private void UpdateSyncListForPlayer(string playerID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::UpdateSyncListForPlayer(System.String)' called when server was not active");
		}
		else if (allPlayerInventories.ContainsKey(playerID))
		{
			int num = syncedPlayerInventories.FindIndex((PlayerInventorySync x) => x.playerID == playerID);
			PlayerInventorySync playerInventorySync = new PlayerInventorySync
			{
				playerID = playerID,
				inventoryData = allPlayerInventories[playerID]
			};
			if (num >= 0)
			{
				syncedPlayerInventories[num] = playerInventorySync;
			}
			else
			{
				syncedPlayerInventories.Add(playerInventorySync);
			}
		}
	}

	[Server]
	private void LoadSpecificPlayerInventory(PlayerInventory playerInventory, string playerID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::LoadSpecificPlayerInventory(PlayerInventory,System.String)' called when server was not active");
		}
		else if (allPlayerInventories.ContainsKey(playerID))
		{
			ApplyLoadedData(playerInventory, allPlayerInventories[playerID]);
		}
	}

	private void OnSyncedInventoryChanged(SyncList<PlayerInventorySync>.Operation op, int index, PlayerInventorySync oldItem, PlayerInventorySync newItem)
	{
		switch (op)
		{
		case SyncList<PlayerInventorySync>.Operation.OP_ADD:
			HandleNewPlayerInventory(newItem);
			break;
		case SyncList<PlayerInventorySync>.Operation.OP_REMOVEAT:
			HandleRemovedPlayerInventory(oldItem);
			break;
		case SyncList<PlayerInventorySync>.Operation.OP_SET:
			HandleUpdatedPlayerInventory(oldItem, newItem);
			break;
		case SyncList<PlayerInventorySync>.Operation.OP_CLEAR:
			clientSyncedPlayerData.Clear();
			break;
		}
		RefreshClientCache();
	}

	private void HandleNewPlayerInventory(PlayerInventorySync newItem)
	{
		clientSyncedPlayerData[newItem.playerID] = newItem.inventoryData;
	}

	private void HandleRemovedPlayerInventory(PlayerInventorySync removedItem)
	{
		if (clientSyncedPlayerData.ContainsKey(removedItem.playerID))
		{
			clientSyncedPlayerData.Remove(removedItem.playerID);
		}
	}

	private void HandleUpdatedPlayerInventory(PlayerInventorySync oldItem, PlayerInventorySync newItem)
	{
		clientSyncedPlayerData[newItem.playerID] = newItem.inventoryData;
	}

	private void RefreshClientCache()
	{
		clientSyncedPlayerData.Clear();
		foreach (PlayerInventorySync syncedPlayerInventory in syncedPlayerInventories)
		{
			clientSyncedPlayerData[syncedPlayerInventory.playerID] = syncedPlayerInventory.inventoryData;
		}
	}

	public void RequestInventoryUpdate(string playerID)
	{
		if (base.isServer)
		{
			UpdateActivePlayerInventory(playerID);
		}
		else if (!(TrainGameManager.Instance == null) && !(TrainGameManager.Instance.mainPlayer == null))
		{
			PlayerInventory component = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
			if (!(component == null) && component.inventorySlotsData != null)
			{
				List<InventorySaveData> inventoryData = ConvertToSaveData(component.inventorySlotsData);
				CmdSyncPlayerInventoryData(inventoryData);
			}
		}
	}

	[Server]
	public void UpdateActivePlayerInventory(string playerID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::UpdateActivePlayerInventory(System.String)' called when server was not active");
		}
		else if (activePlayerInventories.ContainsKey(playerID) && activePlayerInventories[playerID] != null)
		{
			UpdatePlayerInventoryInServer(playerID, activePlayerInventories[playerID]);
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdSyncPlayerInventoryData(List<InventorySaveData> inventoryData, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E(writer, inventoryData);
		SendCommandInternal("System.Void InventorySaver::CmdSyncPlayerInventoryData(System.Collections.Generic.List`1<InventorySaveData>,Mirror.NetworkConnectionToClient)", -1084866162, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void RemovePlayerFromSync(string playerID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::RemovePlayerFromSync(System.String)' called when server was not active");
			return;
		}
		int num = syncedPlayerInventories.FindIndex((PlayerInventorySync x) => x.playerID == playerID);
		if (num >= 0)
		{
			syncedPlayerInventories.RemoveAt(num);
		}
	}

	[Server]
	public void SaveAllPlayerDataToDisk()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::SaveAllPlayerDataToDisk()' called when server was not active");
			return;
		}
		foreach (KeyValuePair<string, PlayerInventory> activePlayerInventory in activePlayerInventories)
		{
			if (activePlayerInventory.Value != null)
			{
				TsPlayerNetworkHelper component = activePlayerInventory.Value.GetComponent<TsPlayerNetworkHelper>();
				if (component != null && component.isLocalPlayer)
				{
					UpdatePlayerInventoryInServer(activePlayerInventory.Key, activePlayerInventory.Value);
					PlayerStatusSaveData value = CollectPlayerStatus(activePlayerInventory.Value.gameObject);
					allPlayerStatusData[activePlayerInventory.Key] = value;
					UpdateSyncListForPlayerStatus(activePlayerInventory.Key);
				}
			}
		}
		foreach (KeyValuePair<string, List<InventorySaveData>> allPlayerInventory in allPlayerInventories)
		{
			string key = "PlayerInventory_" + allPlayerInventory.Key;
			Singleton<ES3SaveManager>.Instance.SaveData(key, allPlayerInventory.Value);
		}
		foreach (KeyValuePair<string, PlayerStatusSaveData> allPlayerStatusDatum in allPlayerStatusData)
		{
			string key2 = "PlayerStatus_" + allPlayerStatusDatum.Key;
			Singleton<ES3SaveManager>.Instance.SaveData(key2, allPlayerStatusDatum.Value);
		}
		if (TSPlayerTutorialManager.Instance != null)
		{
			string text = null;
			foreach (KeyValuePair<string, PlayerInventory> activePlayerInventory2 in activePlayerInventories)
			{
				if (activePlayerInventory2.Value != null)
				{
					TsPlayerNetworkHelper component2 = activePlayerInventory2.Value.GetComponent<TsPlayerNetworkHelper>();
					if (component2 != null && component2.isLocalPlayer)
					{
						text = activePlayerInventory2.Key;
						break;
					}
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				PlayerTutorialSaveData value2 = TSPlayerTutorialManager.Instance.CollectTutorialSaveData();
				allPlayerTutorialData[text] = value2;
				UpdateSyncListForPlayerTutorial(text);
			}
		}
		foreach (KeyValuePair<string, PlayerTutorialSaveData> allPlayerTutorialDatum in allPlayerTutorialData)
		{
			string key3 = "PlayerTutorial_" + allPlayerTutorialDatum.Key;
			Singleton<ES3SaveManager>.Instance.SaveData(key3, allPlayerTutorialDatum.Value);
		}
		List<TutorialTaskEntry> value3 = new List<TutorialTaskEntry>(syncedCommonTasks);
		Singleton<ES3SaveManager>.Instance.SaveData("CommonTasks", value3);
		HashSet<string> hashSet = new HashSet<string>(allPlayerInventories.Keys);
		foreach (string key4 in allPlayerStatusData.Keys)
		{
			hashSet.Add(key4);
		}
		foreach (string key5 in allPlayerTutorialData.Keys)
		{
			hashSet.Add(key5);
		}
		List<string> value4 = new List<string>(hashSet);
		Singleton<ES3SaveManager>.Instance.SaveData("SavedPlayersList", value4);
	}

	[Server]
	public void LoadAllPlayerDataFromDisk()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::LoadAllPlayerDataFromDisk()' called when server was not active");
			return;
		}
		if (isDataPreloaded)
		{
			foreach (KeyValuePair<string, PlayerInventory> activePlayerInventory in activePlayerInventories)
			{
				if (allPlayerInventories.ContainsKey(activePlayerInventory.Key))
				{
					LoadSpecificPlayerInventory(activePlayerInventory.Value, activePlayerInventory.Key);
				}
			}
			return;
		}
		allPlayerInventories.Clear();
		syncedPlayerInventories.Clear();
		allPlayerStatusData.Clear();
		syncedPlayerStatus.Clear();
		allPlayerTutorialData.Clear();
		syncedPlayerTutorial.Clear();
		syncedCommonTasks.Clear();
		if (Singleton<ES3SaveManager>.Instance.KeyExists("SavedPlayersList"))
		{
			foreach (string item in Singleton<ES3SaveManager>.Instance.LoadData("SavedPlayersList", new List<string>()))
			{
				string key = "PlayerInventory_" + item;
				if (Singleton<ES3SaveManager>.Instance.KeyExists(key))
				{
					List<InventorySaveData> value = Singleton<ES3SaveManager>.Instance.LoadData(key, new List<InventorySaveData>());
					allPlayerInventories.Add(item, value);
					UpdateSyncListForPlayer(item);
				}
				string key2 = "PlayerStatus_" + item;
				if (Singleton<ES3SaveManager>.Instance.KeyExists(key2))
				{
					PlayerStatusSaveData value2 = Singleton<ES3SaveManager>.Instance.LoadData<PlayerStatusSaveData>(key2);
					allPlayerStatusData[item] = value2;
					UpdateSyncListForPlayerStatus(item);
				}
				string key3 = "PlayerTutorial_" + item;
				if (Singleton<ES3SaveManager>.Instance.KeyExists(key3))
				{
					PlayerTutorialSaveData value3 = Singleton<ES3SaveManager>.Instance.LoadData<PlayerTutorialSaveData>(key3);
					allPlayerTutorialData[item] = value3;
					UpdateSyncListForPlayerTutorial(item);
				}
			}
		}
		if (Singleton<ES3SaveManager>.Instance.KeyExists("CommonTasks"))
		{
			List<TutorialTaskEntry> list = Singleton<ES3SaveManager>.Instance.LoadData("CommonTasks", new List<TutorialTaskEntry>());
			syncedCommonTasks.Clear();
			foreach (TutorialTaskEntry item2 in list)
			{
				syncedCommonTasks.Add(item2);
			}
		}
		foreach (KeyValuePair<string, PlayerInventory> activePlayerInventory2 in activePlayerInventories)
		{
			if (allPlayerInventories.ContainsKey(activePlayerInventory2.Key))
			{
				LoadSpecificPlayerInventory(activePlayerInventory2.Value, activePlayerInventory2.Key);
			}
		}
	}

	private List<InventorySaveData> ConvertToSaveData(List<InventorySlotsData> slotsData)
	{
		List<InventorySaveData> list = new List<InventorySaveData>();
		foreach (InventorySlotsData slotsDatum in slotsData)
		{
			if (slotsDatum.item != null)
			{
				InventorySaveData item = new InventorySaveData
				{
					itemID = slotsDatum.item.itemName,
					count = slotsDatum.itemCountInSlot,
					inventoryID = slotsDatum.slotID,
					itemMagazineCount = slotsDatum.currentMagazineCount,
					itemDurability = slotsDatum.currentDurability
				};
				list.Add(item);
			}
		}
		return list;
	}

	private void ApplyLoadedData(PlayerInventory playerInventory, List<InventorySaveData> saveDataList)
	{
		if (playerInventory == null || playerInventory.inventorySlotsData == null)
		{
			return;
		}
		foreach (InventorySlotsData inventorySlotsDatum in playerInventory.inventorySlotsData)
		{
			inventorySlotsDatum.Clear();
		}
		foreach (InventorySaveData saveData in saveDataList)
		{
			InventorySlotsData inventorySlotsData = playerInventory.inventorySlotsData.FirstOrDefault((InventorySlotsData x) => x.slotID == saveData.inventoryID);
			if (inventorySlotsData == null)
			{
				continue;
			}
			CollectableItemData collectableItemData = FindItemByItemName(saveData.itemID, playerInventory);
			if (collectableItemData != null)
			{
				inventorySlotsData.item = collectableItemData;
				inventorySlotsData.itemCountInSlot = saveData.count;
				inventorySlotsData.currentMagazineCount = saveData.itemMagazineCount;
				inventorySlotsData.currentDurability = saveData.itemDurability;
				playerInventory.AddItemInventoryWithoutNotify(collectableItemData, saveData.count);
				InventorySlot inventorySlot = playerInventory.mainInventorySlots.FirstOrDefault((InventorySlot x) => x.inventoryID == saveData.inventoryID);
				if (inventorySlot != null && inventorySlot.InventoryItem != null)
				{
					inventorySlot.InventoryItem.UpdateInventoryData(inventorySlotsData);
					inventorySlot.HasItem = true;
					inventorySlot.inventoryCount = saveData.count;
				}
			}
		}
		EastUpPlayerItemManager component = playerInventory.GetComponent<EastUpPlayerItemManager>();
		if (component != null)
		{
			component.CheckItemSlots();
		}
	}

	private CollectableItemData FindItemByItemName(string itemName, PlayerInventory playerInventory)
	{
		foreach (PlayerInventoryData inventoryDatum in playerInventory.inventoryData)
		{
			if (inventoryDatum.item.itemName == itemName)
			{
				return inventoryDatum.item;
			}
		}
		foreach (CollectableItemData placeableDatum in playerInventory.placeableData)
		{
			if (placeableDatum.itemName == itemName)
			{
				return placeableDatum;
			}
		}
		return null;
	}

	private string GetPlayerID(PlayerInventory playerInventory)
	{
		TsPlayerNetworkHelper component = playerInventory.GetComponent<TsPlayerNetworkHelper>();
		if (!(component != null))
		{
			return "";
		}
		return component.steamID;
	}

	public List<InventorySaveData> GetPlayerInventoryData(string playerID)
	{
		if (base.isServer)
		{
			if (!allPlayerInventories.ContainsKey(playerID))
			{
				return null;
			}
			return allPlayerInventories[playerID];
		}
		if (!clientSyncedPlayerData.ContainsKey(playerID))
		{
			return null;
		}
		return clientSyncedPlayerData[playerID];
	}

	public List<string> GetAllPlayerIDs()
	{
		if (base.isServer)
		{
			return new List<string>(allPlayerInventories.Keys);
		}
		return new List<string>(clientSyncedPlayerData.Keys);
	}

	public void UnregisterPlayerInventory(PlayerInventory playerInventory)
	{
		if (playerInventory != null && base.isServer)
		{
			string playerID = GetPlayerID(playerInventory);
			if (!string.IsNullOrEmpty(playerID) && activePlayerInventories.ContainsKey(playerID))
			{
				UpdatePlayerInventoryInServer(playerID, playerInventory);
				activePlayerInventories.Remove(playerID);
			}
		}
	}

	public void ClearAllSaveData()
	{
		if (ES3.KeyExists("SavedPlayersList"))
		{
			foreach (string item in ES3.Load<List<string>>("SavedPlayersList"))
			{
				string key = "PlayerInventory_" + item;
				if (ES3.KeyExists(key))
				{
					ES3.DeleteKey(key);
				}
				string key2 = "PlayerStatus_" + item;
				if (ES3.KeyExists(key2))
				{
					ES3.DeleteKey(key2);
				}
				string key3 = "PlayerTutorial_" + item;
				if (ES3.KeyExists(key3))
				{
					ES3.DeleteKey(key3);
				}
			}
			ES3.DeleteKey("SavedPlayersList");
		}
		if (ES3.KeyExists("CommonTasks"))
		{
			ES3.DeleteKey("CommonTasks");
		}
		isDataPreloaded = false;
	}

	[ContextMenu("List All Player Data")]
	public void ListAllPlayerData()
	{
		if (base.isServer)
		{
			Debug.Log($"Aktif oyuncu sayısı: {activePlayerInventories.Count}");
			Debug.Log($"Server'da toplam oyuncu verisi: {allPlayerInventories.Count}");
			Debug.Log($"SyncList entry sayısı: {syncedPlayerInventories.Count}");
		}
		else
		{
			Debug.Log($"SyncList entry sayısı: {syncedPlayerInventories.Count}");
			Debug.Log($"Client cache'de oyuncu sayısı: {clientSyncedPlayerData.Count}");
		}
	}

	[ContextMenu("Force Update All Active Players")]
	[Server]
	public void ForceUpdateAllActivePlayers()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::ForceUpdateAllActivePlayers()' called when server was not active");
			return;
		}
		foreach (KeyValuePair<string, PlayerInventory> activePlayerInventory in activePlayerInventories)
		{
			if (activePlayerInventory.Value != null)
			{
				UpdatePlayerInventoryInServer(activePlayerInventory.Key, activePlayerInventory.Value);
			}
		}
	}

	[Server]
	private void UpdateSyncListForPlayerStatus(string playerID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::UpdateSyncListForPlayerStatus(System.String)' called when server was not active");
		}
		else if (allPlayerStatusData.ContainsKey(playerID))
		{
			int num = syncedPlayerStatus.FindIndex((PlayerStatusSync x) => x.playerID == playerID);
			PlayerStatusSync playerStatusSync = new PlayerStatusSync
			{
				playerID = playerID,
				statusData = allPlayerStatusData[playerID]
			};
			if (num >= 0)
			{
				syncedPlayerStatus[num] = playerStatusSync;
			}
			else
			{
				syncedPlayerStatus.Add(playerStatusSync);
			}
		}
	}

	[Server]
	public void SavePlayerStatus(string playerID, PlayerStatusSaveData statusData)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::SavePlayerStatus(System.String,PlayerStatusSaveData)' called when server was not active");
			return;
		}
		allPlayerStatusData[playerID] = statusData;
		UpdateSyncListForPlayerStatus(playerID);
	}

	[Command(requiresAuthority = false)]
	public void CmdSyncPlayerStatus(PlayerStatusSaveData statusData, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PlayerStatusSaveData(writer, statusData);
		SendCommandInternal("System.Void InventorySaver::CmdSyncPlayerStatus(PlayerStatusSaveData,Mirror.NetworkConnectionToClient)", -841311695, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public PlayerStatusSaveData? GetPlayerStatusData(string playerID)
	{
		if (base.isServer)
		{
			if (!allPlayerStatusData.ContainsKey(playerID))
			{
				return null;
			}
			return allPlayerStatusData[playerID];
		}
		if (!clientSyncedStatusData.ContainsKey(playerID))
		{
			return null;
		}
		return clientSyncedStatusData[playerID];
	}

	private PlayerStatusSaveData CollectPlayerStatus(GameObject playerObj)
	{
		TSPlayerStatusHolder component = playerObj.GetComponent<TSPlayerStatusHolder>();
		EastUpPlayerItemManager component2 = playerObj.GetComponent<EastUpPlayerItemManager>();
		return new PlayerStatusSaveData
		{
			hasData = true,
			posX = playerObj.transform.position.x,
			posY = playerObj.transform.position.y,
			posZ = playerObj.transform.position.z,
			rotX = playerObj.transform.eulerAngles.x,
			rotY = playerObj.transform.eulerAngles.y,
			rotZ = playerObj.transform.eulerAngles.z,
			health = ((component != null) ? component.playerHpFuel : 100f),
			food = ((component != null) ? component.playerFoodFuel : 100f),
			water = ((component != null) ? component.playerWaterFuel : 100f),
			lastSelectedSlot = ((!(component2 != null) || component2.LastIndex <= 0) ? 1 : component2.LastIndex)
		};
	}

	private void OnSyncedStatusChanged(SyncList<PlayerStatusSync>.Operation op, int index, PlayerStatusSync oldItem, PlayerStatusSync newItem)
	{
		RefreshClientStatusCache();
	}

	private void RefreshClientStatusCache()
	{
		clientSyncedStatusData.Clear();
		foreach (PlayerStatusSync item in syncedPlayerStatus)
		{
			clientSyncedStatusData[item.playerID] = item.statusData;
		}
	}

	[Server]
	private void UpdateSyncListForPlayerTutorial(string playerID)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::UpdateSyncListForPlayerTutorial(System.String)' called when server was not active");
		}
		else if (allPlayerTutorialData.ContainsKey(playerID))
		{
			int num = syncedPlayerTutorial.FindIndex((PlayerTutorialSync x) => x.playerID == playerID);
			PlayerTutorialSync playerTutorialSync = new PlayerTutorialSync
			{
				playerID = playerID,
				tutorialData = allPlayerTutorialData[playerID]
			};
			if (num >= 0)
			{
				syncedPlayerTutorial[num] = playerTutorialSync;
			}
			else
			{
				syncedPlayerTutorial.Add(playerTutorialSync);
			}
		}
	}

	[Server]
	public void SavePlayerTutorial(string playerID, PlayerTutorialSaveData tutorialData)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::SavePlayerTutorial(System.String,PlayerTutorialSaveData)' called when server was not active");
			return;
		}
		allPlayerTutorialData[playerID] = tutorialData;
		UpdateSyncListForPlayerTutorial(playerID);
	}

	[Command(requiresAuthority = false)]
	public void CmdSyncTutorialProgress(PlayerTutorialSaveData tutorialData, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_PlayerTutorialSaveData(writer, tutorialData);
		SendCommandInternal("System.Void InventorySaver::CmdSyncTutorialProgress(PlayerTutorialSaveData,Mirror.NetworkConnectionToClient)", -235233115, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public PlayerTutorialSaveData? GetPlayerTutorialData(string playerID)
	{
		if (base.isServer)
		{
			if (!allPlayerTutorialData.ContainsKey(playerID))
			{
				return null;
			}
			return allPlayerTutorialData[playerID];
		}
		if (!clientSyncedTutorialData.ContainsKey(playerID))
		{
			return null;
		}
		return clientSyncedTutorialData[playerID];
	}

	[Server]
	public void UpdateCommonTask(int groupIndex, int taskIndex, int progress, bool completed)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void InventorySaver::UpdateCommonTask(System.Int32,System.Int32,System.Int32,System.Boolean)' called when server was not active");
			return;
		}
		int num = -1;
		for (int i = 0; i < syncedCommonTasks.Count; i++)
		{
			if (syncedCommonTasks[i].groupIndex == groupIndex && syncedCommonTasks[i].taskIndex == taskIndex)
			{
				num = i;
				break;
			}
		}
		TutorialTaskEntry tutorialTaskEntry = new TutorialTaskEntry
		{
			groupIndex = groupIndex,
			taskIndex = taskIndex,
			progress = progress,
			completed = completed
		};
		if (num >= 0)
		{
			syncedCommonTasks[num] = tutorialTaskEntry;
		}
		else
		{
			syncedCommonTasks.Add(tutorialTaskEntry);
		}
	}

	private void OnSyncedTutorialChanged(SyncList<PlayerTutorialSync>.Operation op, int index, PlayerTutorialSync oldItem, PlayerTutorialSync newItem)
	{
		RefreshClientTutorialCache();
	}

	private void OnSyncedCommonTasksChanged(SyncList<TutorialTaskEntry>.Operation op, int index, TutorialTaskEntry oldItem, TutorialTaskEntry newItem)
	{
	}

	private void RefreshClientTutorialCache()
	{
		clientSyncedTutorialData.Clear();
		foreach (PlayerTutorialSync item in syncedPlayerTutorial)
		{
			clientSyncedTutorialData[item.playerID] = item.tutorialData;
		}
	}

	public InventorySaver()
	{
		InitSyncObject(syncedPlayerInventories);
		InitSyncObject(syncedPlayerStatus);
		InitSyncObject(syncedPlayerTutorial);
		InitSyncObject(syncedCommonTasks);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSyncPlayerInventoryData__List_00601__NetworkConnectionToClient(List<InventorySaveData> inventoryData, NetworkConnectionToClient sender)
	{
		if (!(sender?.identity == null))
		{
			TsPlayerNetworkHelper component = sender.identity.GetComponent<TsPlayerNetworkHelper>();
			if (!(component == null) && !string.IsNullOrEmpty(component.steamID))
			{
				string steamID = component.steamID;
				allPlayerInventories[steamID] = inventoryData;
				UpdateSyncListForPlayer(steamID);
			}
		}
	}

	protected static void InvokeUserCode_CmdSyncPlayerInventoryData__List_00601__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSyncPlayerInventoryData called on client.");
		}
		else
		{
			((InventorySaver)obj).UserCode_CmdSyncPlayerInventoryData__List_00601__NetworkConnectionToClient(GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E(reader), senderConnection);
		}
	}

	protected void UserCode_CmdSyncPlayerStatus__PlayerStatusSaveData__NetworkConnectionToClient(PlayerStatusSaveData statusData, NetworkConnectionToClient sender)
	{
		if (!(sender?.identity == null))
		{
			TsPlayerNetworkHelper component = sender.identity.GetComponent<TsPlayerNetworkHelper>();
			if (!(component == null) && !string.IsNullOrEmpty(component.steamID))
			{
				string steamID = component.steamID;
				allPlayerStatusData[steamID] = statusData;
				UpdateSyncListForPlayerStatus(steamID);
			}
		}
	}

	protected static void InvokeUserCode_CmdSyncPlayerStatus__PlayerStatusSaveData__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSyncPlayerStatus called on client.");
		}
		else
		{
			((InventorySaver)obj).UserCode_CmdSyncPlayerStatus__PlayerStatusSaveData__NetworkConnectionToClient(GeneratedNetworkCode._Read_PlayerStatusSaveData(reader), senderConnection);
		}
	}

	protected void UserCode_CmdSyncTutorialProgress__PlayerTutorialSaveData__NetworkConnectionToClient(PlayerTutorialSaveData tutorialData, NetworkConnectionToClient sender)
	{
		if (!(sender?.identity == null))
		{
			TsPlayerNetworkHelper component = sender.identity.GetComponent<TsPlayerNetworkHelper>();
			if (!(component == null) && !string.IsNullOrEmpty(component.steamID))
			{
				string steamID = component.steamID;
				allPlayerTutorialData[steamID] = tutorialData;
				UpdateSyncListForPlayerTutorial(steamID);
			}
		}
	}

	protected static void InvokeUserCode_CmdSyncTutorialProgress__PlayerTutorialSaveData__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSyncTutorialProgress called on client.");
		}
		else
		{
			((InventorySaver)obj).UserCode_CmdSyncTutorialProgress__PlayerTutorialSaveData__NetworkConnectionToClient(GeneratedNetworkCode._Read_PlayerTutorialSaveData(reader), senderConnection);
		}
	}

	static InventorySaver()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(InventorySaver), "System.Void InventorySaver::CmdSyncPlayerInventoryData(System.Collections.Generic.List`1<InventorySaveData>,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSyncPlayerInventoryData__List_00601__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventorySaver), "System.Void InventorySaver::CmdSyncPlayerStatus(PlayerStatusSaveData,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSyncPlayerStatus__PlayerStatusSaveData__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(InventorySaver), "System.Void InventorySaver::CmdSyncTutorialProgress(PlayerTutorialSaveData,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdSyncTutorialProgress__PlayerTutorialSaveData__NetworkConnectionToClient, requiresAuthority: false);
	}
}
