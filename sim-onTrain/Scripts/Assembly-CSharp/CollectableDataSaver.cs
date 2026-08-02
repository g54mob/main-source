using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Localization;

public class CollectableDataSaver : NetworkBehaviour
{
	[SerializeField]
	private CollectableItemData[] allCollectableItems;

	[Header("Localization")]
	public LocalizedString storyPaperFoundLocalized;

	public SyncList<CollectableItemSync> syncedItemStates = new SyncList<CollectableItemSync>();

	public SyncList<CategoryUnlockSync> syncedCategoryStates = new SyncList<CategoryUnlockSync>();

	private Dictionary<string, CollectableItemState> clientSyncedStates = new Dictionary<string, CollectableItemState>();

	private Dictionary<string, bool> clientCategoryStates = new Dictionary<string, bool>();

	private Coroutine pendingItemRefresh;

	private Coroutine pendingCategoryRefresh;

	private CollectableItemData[] allResourceItemsCache;

	public static CollectableDataSaver Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		ConnectSaveListeners();
	}

	private void ConnectSaveListeners()
	{
		if (Singleton<ES3SaveManager>.Instance != null && base.isServer)
		{
			Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveCollectableStates);
			Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadCollectableStates);
			Singleton<ES3SaveManager>.Instance.OnPreLoad.AddListener(LoadCollectableStates);
			Debug.Log("[CollectableDataSaver] Save/Load listeners connected to ES3SaveManager");
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		syncedItemStates.Callback += OnSyncedStatesChanged;
		syncedCategoryStates.Callback += OnSyncedCategoryStatesChanged;
		if (!base.isServer)
		{
			StartCoroutine(ClientInitialization());
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		ConnectSaveListeners();
		InitializeCollectableItems();
		LoadCollectableStates();
	}

	private IEnumerator ClientInitialization()
	{
		yield return new WaitForSeconds(0.5f);
		InitializeCollectableItems();
		yield return new WaitForSeconds(0.5f);
		RefreshClientCache();
		RefreshClientCategoryCache();
		ApplyStatesToItems();
	}

	public void InitializeCollectableItems()
	{
		if (Singleton<DataManager>.Instance != null && Singleton<DataManager>.Instance.collectableDatas != null && Singleton<DataManager>.Instance.collectableDatas.Count > 0)
		{
			allCollectableItems = Singleton<DataManager>.Instance.collectableDatas.ToArray();
		}
		else
		{
			allCollectableItems = Resources.FindObjectsOfTypeAll<CollectableItemData>();
		}
		if (base.isServer)
		{
			return;
		}
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData != null && !collectableItemData.isOpenedInStart)
			{
				collectableItemData.isResearched = false;
				collectableItemData.isLearned = false;
			}
		}
	}

	private void OnSyncedStatesChanged(SyncList<CollectableItemSync>.Operation op, int index, CollectableItemSync oldItem, CollectableItemSync newItem)
	{
		if (pendingItemRefresh == null)
		{
			pendingItemRefresh = StartCoroutine(DeferredItemRefresh());
		}
	}

	private void OnSyncedCategoryStatesChanged(SyncList<CategoryUnlockSync>.Operation op, int index, CategoryUnlockSync oldItem, CategoryUnlockSync newItem)
	{
		if (pendingCategoryRefresh == null)
		{
			pendingCategoryRefresh = StartCoroutine(DeferredCategoryRefresh());
		}
	}

	private IEnumerator DeferredItemRefresh()
	{
		yield return null;
		pendingItemRefresh = null;
		RefreshClientCache();
		ApplyStatesToItems();
	}

	private IEnumerator DeferredCategoryRefresh()
	{
		yield return null;
		pendingCategoryRefresh = null;
		RefreshClientCategoryCache();
		ApplyCategoryStates();
	}

	private void RefreshClientCache()
	{
		clientSyncedStates.Clear();
		foreach (CollectableItemSync syncedItemState in syncedItemStates)
		{
			clientSyncedStates[syncedItemState.itemName] = new CollectableItemState
			{
				isResearched = syncedItemState.isResearched,
				isLearned = syncedItemState.isLearned
			};
		}
	}

	private void RefreshClientCategoryCache()
	{
		clientCategoryStates.Clear();
		foreach (CategoryUnlockSync syncedCategoryState in syncedCategoryStates)
		{
			clientCategoryStates[syncedCategoryState.categoryName] = syncedCategoryState.isUnlocked;
		}
	}

	public void ApplyStatesToItems()
	{
		if (allCollectableItems == null || allCollectableItems.Length == 0)
		{
			InitializeCollectableItems();
		}
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (!(collectableItemData != null))
			{
				continue;
			}
			if (collectableItemData.isOpenedInStart)
			{
				collectableItemData.isResearched = true;
				collectableItemData.isLearned = true;
			}
			else if (!base.isServer)
			{
				if (clientSyncedStates.ContainsKey(collectableItemData.itemName))
				{
					collectableItemData.isResearched = clientSyncedStates[collectableItemData.itemName].isResearched;
					collectableItemData.isLearned = clientSyncedStates[collectableItemData.itemName].isLearned;
				}
				else
				{
					collectableItemData.isResearched = false;
					collectableItemData.isLearned = false;
				}
			}
		}
		ApplyCategoryStates();
		ResearchUIManager researchUIManager = Object.FindObjectOfType<ResearchUIManager>();
		if (researchUIManager != null)
		{
			researchUIManager.UpdateReseachStatus();
			researchUIManager.SetResearchStatus();
		}
		CraftInfoPanel craftInfoPanel = Object.FindObjectOfType<CraftInfoPanel>();
		if (craftInfoPanel != null)
		{
			craftInfoPanel.SetPanel();
		}
	}

	public void ApplyCategoryStates()
	{
		ResearchUIManager instance = ResearchUIManager.Instance;
		if (instance == null || instance.categorizers == null)
		{
			return;
		}
		foreach (ResearchSystemCategorizer categorizer in instance.categorizers)
		{
			if (categorizer == null)
			{
				continue;
			}
			if (categorizer.isUnlockedByDefault)
			{
				categorizer.isUnlocked = true;
			}
			else if (base.isServer)
			{
				foreach (CategoryUnlockSync syncedCategoryState in syncedCategoryStates)
				{
					if (syncedCategoryState.categoryName == categorizer.categoryName)
					{
						categorizer.isUnlocked = syncedCategoryState.isUnlocked;
						break;
					}
				}
			}
			else if (clientCategoryStates.ContainsKey(categorizer.categoryName))
			{
				categorizer.isUnlocked = clientCategoryStates[categorizer.categoryName];
			}
			else
			{
				categorizer.isUnlocked = false;
			}
		}
		if (instance != null && instance.isPanelOpen)
		{
			instance.RefreshCurrentCategory();
		}
	}

	[Server]
	private void UpdateSyncList()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::UpdateSyncList()' called when server was not active");
			return;
		}
		syncedItemStates.Clear();
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData != null)
			{
				syncedItemStates.Add(new CollectableItemSync
				{
					itemName = collectableItemData.itemName,
					isResearched = collectableItemData.isResearched,
					isLearned = collectableItemData.isLearned
				});
			}
		}
	}

	[Server]
	public void SaveCollectableStates()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::SaveCollectableStates()' called when server was not active");
			return;
		}
		Debug.Log("[CollectableDataSaver] SaveCollectableStates called!");
		Dictionary<string, CollectableItemState> dictionary = new Dictionary<string, CollectableItemState>();
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData != null)
			{
				if (collectableItemData.isOpenedInStart)
				{
					collectableItemData.isResearched = true;
					collectableItemData.isLearned = true;
				}
				dictionary[collectableItemData.itemName] = new CollectableItemState
				{
					isResearched = collectableItemData.isResearched,
					isLearned = collectableItemData.isLearned
				};
			}
		}
		Singleton<ES3SaveManager>.Instance.SaveData("CollectableItemStates", dictionary);
		SaveCategoryStates();
	}

	[Server]
	private void SaveCategoryStates()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::SaveCategoryStates()' called when server was not active");
			return;
		}
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		foreach (CategoryUnlockSync syncedCategoryState in syncedCategoryStates)
		{
			dictionary[syncedCategoryState.categoryName] = syncedCategoryState.isUnlocked;
		}
		Singleton<ES3SaveManager>.Instance.SaveData("CategoryUnlockStates", dictionary);
	}

	[Server]
	public void LoadCollectableStates()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::LoadCollectableStates()' called when server was not active");
			return;
		}
		if (allCollectableItems == null || allCollectableItems.Length == 0)
		{
			InitializeCollectableItems();
		}
		Dictionary<string, CollectableItemState> dictionary = Singleton<ES3SaveManager>.Instance.LoadData("CollectableItemStates", new Dictionary<string, CollectableItemState>());
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData != null)
			{
				if (collectableItemData.isOpenedInStart)
				{
					collectableItemData.isResearched = true;
					collectableItemData.isLearned = true;
				}
				else if (dictionary.ContainsKey(collectableItemData.itemName))
				{
					collectableItemData.isResearched = dictionary[collectableItemData.itemName].isResearched;
					collectableItemData.isLearned = dictionary[collectableItemData.itemName].isLearned;
				}
				else
				{
					collectableItemData.isResearched = false;
					collectableItemData.isLearned = false;
				}
			}
		}
		UpdateSyncList();
		LoadCategoryStates();
	}

	[Server]
	private void LoadCategoryStates()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::LoadCategoryStates()' called when server was not active");
			return;
		}
		Dictionary<string, bool> dictionary = Singleton<ES3SaveManager>.Instance.LoadData("CategoryUnlockStates", new Dictionary<string, bool>());
		syncedCategoryStates.Clear();
		foreach (KeyValuePair<string, bool> item in dictionary)
		{
			syncedCategoryStates.Add(new CategoryUnlockSync
			{
				categoryName = item.Key,
				isUnlocked = item.Value
			});
		}
		ApplyCategoryStates();
	}

	public void SetItemResearched(string itemName, bool researched)
	{
		if (base.isServer)
		{
			ServerSetItemResearched(itemName, researched);
		}
		else
		{
			CmdSetItemResearched(itemName, researched);
		}
	}

	public void SetItemLearned(string itemName, bool learned)
	{
		if (base.isServer)
		{
			ServerSetItemLearned(itemName, learned);
		}
		else
		{
			CmdSetItemLearned(itemName, learned);
		}
	}

	public void SetCategoryUnlocked(string categoryName, bool unlocked)
	{
		if (base.isServer)
		{
			ServerSetCategoryUnlocked(categoryName, unlocked);
		}
		else
		{
			CmdSetCategoryUnlocked(categoryName, unlocked);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdSetCategoryUnlocked(string categoryName, bool unlocked)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(categoryName);
		writer.WriteBool(unlocked);
		SendCommandInternal("System.Void CollectableDataSaver::CmdSetCategoryUnlocked(System.String,System.Boolean)", 229616688, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetCategoryUnlocked(string categoryName, bool unlocked)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::ServerSetCategoryUnlocked(System.String,System.Boolean)' called when server was not active");
			return;
		}
		int num = -1;
		for (int i = 0; i < syncedCategoryStates.Count; i++)
		{
			if (syncedCategoryStates[i].categoryName == categoryName)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			syncedCategoryStates[num] = new CategoryUnlockSync
			{
				categoryName = categoryName,
				isUnlocked = unlocked
			};
		}
		else
		{
			syncedCategoryStates.Add(new CategoryUnlockSync
			{
				categoryName = categoryName,
				isUnlocked = unlocked
			});
		}
		ApplyCategoryStates();
		if (unlocked)
		{
			RpcNotifyCategoryUnlocked(categoryName);
		}
	}

	[ClientRpc]
	private void RpcNotifyCategoryUnlocked(string categoryName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(categoryName);
		SendRPCInternal("System.Void CollectableDataSaver::RpcNotifyCategoryUnlocked(System.String)", 1934238173, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public bool IsCategoryUnlocked(string categoryName)
	{
		if (base.isServer)
		{
			foreach (CategoryUnlockSync syncedCategoryState in syncedCategoryStates)
			{
				if (syncedCategoryState.categoryName == categoryName)
				{
					return syncedCategoryState.isUnlocked;
				}
			}
			return false;
		}
		if (clientCategoryStates.ContainsKey(categoryName))
		{
			return clientCategoryStates[categoryName];
		}
		return false;
	}

	[Command(requiresAuthority = false)]
	private void CmdSetItemResearched(string itemName, bool researched)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteBool(researched);
		SendCommandInternal("System.Void CollectableDataSaver::CmdSetItemResearched(System.String,System.Boolean)", -812255012, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdSetItemLearned(string itemName, bool learned)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteBool(learned);
		SendCommandInternal("System.Void CollectableDataSaver::CmdSetItemLearned(System.String,System.Boolean)", -575264519, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSetItemResearched(string itemName, bool researched)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::ServerSetItemResearched(System.String,System.Boolean)' called when server was not active");
			return;
		}
		CollectableItemData itemByName = GetItemByName(itemName);
		if (!(itemByName != null))
		{
			return;
		}
		bool isResearched = itemByName.isResearched;
		itemByName.isResearched = researched;
		int num = -1;
		for (int i = 0; i < syncedItemStates.Count; i++)
		{
			if (syncedItemStates[i].itemName == itemName)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			CollectableItemSync collectableItemSync = syncedItemStates[num];
			syncedItemStates[num] = new CollectableItemSync
			{
				itemName = itemName,
				isResearched = researched,
				isLearned = collectableItemSync.isLearned
			};
		}
		else
		{
			syncedItemStates.Add(new CollectableItemSync
			{
				itemName = itemName,
				isResearched = researched,
				isLearned = false
			});
		}
		if (researched && !isResearched)
		{
			RpcNotifyItemResearched(itemName);
		}
	}

	[Server]
	private void ServerSetItemLearned(string itemName, bool learned)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableDataSaver::ServerSetItemLearned(System.String,System.Boolean)' called when server was not active");
			return;
		}
		CollectableItemData itemByName = GetItemByName(itemName);
		if (!(itemByName != null))
		{
			return;
		}
		bool isLearned = itemByName.isLearned;
		itemByName.isLearned = learned;
		int num = -1;
		for (int i = 0; i < syncedItemStates.Count; i++)
		{
			if (syncedItemStates[i].itemName == itemName)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			CollectableItemSync collectableItemSync = syncedItemStates[num];
			syncedItemStates[num] = new CollectableItemSync
			{
				itemName = itemName,
				isResearched = collectableItemSync.isResearched,
				isLearned = learned
			};
		}
		else
		{
			syncedItemStates.Add(new CollectableItemSync
			{
				itemName = itemName,
				isResearched = false,
				isLearned = learned
			});
		}
		if (learned && !isLearned)
		{
			RpcNotifyItemLearned(itemName);
		}
	}

	[ClientRpc]
	private void RpcNotifyItemResearched(string itemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		SendRPCInternal("System.Void CollectableDataSaver::RpcNotifyItemResearched(System.String)", -1114218831, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcNotifyItemLearned(string itemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		SendRPCInternal("System.Void CollectableDataSaver::RpcNotifyItemLearned(System.String)", 1208506836, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public bool IsItemResearched(string itemName)
	{
		if (base.isServer)
		{
			CollectableItemData itemByName = GetItemByName(itemName);
			if (!(itemByName != null))
			{
				return false;
			}
			return itemByName.isResearched;
		}
		if (clientSyncedStates.ContainsKey(itemName))
		{
			return clientSyncedStates[itemName].isResearched;
		}
		return false;
	}

	public bool IsItemLearned(string itemName)
	{
		if (base.isServer)
		{
			CollectableItemData itemByName = GetItemByName(itemName);
			if (!(itemByName != null))
			{
				return false;
			}
			return itemByName.isLearned;
		}
		if (clientSyncedStates.ContainsKey(itemName))
		{
			return clientSyncedStates[itemName].isLearned;
		}
		return false;
	}

	public void UpdateClientItemStates(CollectableItemData[] items)
	{
		if (base.isServer)
		{
			return;
		}
		foreach (CollectableItemData collectableItemData in items)
		{
			if (collectableItemData != null && !collectableItemData.isOpenedInStart)
			{
				if (clientSyncedStates.ContainsKey(collectableItemData.itemName))
				{
					collectableItemData.isResearched = clientSyncedStates[collectableItemData.itemName].isResearched;
					collectableItemData.isLearned = clientSyncedStates[collectableItemData.itemName].isLearned;
				}
				else
				{
					collectableItemData.isResearched = false;
					collectableItemData.isLearned = false;
				}
			}
		}
	}

	private CollectableItemData GetItemByName(string itemName)
	{
		if (allCollectableItems == null || allCollectableItems.Length == 0)
		{
			InitializeCollectableItems();
		}
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData != null && collectableItemData.itemName == itemName)
			{
				return collectableItemData;
			}
		}
		if (allResourceItemsCache == null || allResourceItemsCache.Length == 0)
		{
			allResourceItemsCache = Resources.LoadAll<CollectableItemData>("");
		}
		array = allResourceItemsCache;
		foreach (CollectableItemData collectableItemData2 in array)
		{
			if (collectableItemData2 != null && collectableItemData2.itemName == itemName)
			{
				return collectableItemData2;
			}
		}
		return null;
	}

	public void ResetAllItemStates()
	{
		if (!base.isServer)
		{
			return;
		}
		CollectableItemData[] array = allCollectableItems;
		foreach (CollectableItemData collectableItemData in array)
		{
			if (collectableItemData != null)
			{
				collectableItemData.isResearched = false;
				collectableItemData.isLearned = false;
			}
		}
		UpdateSyncList();
	}

	public void OnPlayerConnected(NetworkConnectionToClient conn)
	{
		if (base.isServer)
		{
			StartCoroutine(SyncToNewPlayer(conn));
		}
	}

	private IEnumerator SyncToNewPlayer(NetworkConnectionToClient conn)
	{
		yield return new WaitForSeconds(2f);
		if (conn != null && conn.identity != null)
		{
			RpcForceRefreshClient(conn);
		}
	}

	[TargetRpc]
	private void RpcForceRefreshClient(NetworkConnection conn)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(conn, "System.Void CollectableDataSaver::RpcForceRefreshClient(Mirror.NetworkConnection)", 361700697, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ForceClientRefresh()
	{
		yield return new WaitForSeconds(0.5f);
		InitializeCollectableItems();
		RefreshClientCache();
		RefreshClientCategoryCache();
		ApplyStatesToItems();
		Debug.Log($"Client verileri güncellendi. Toplam {clientSyncedStates.Count} item durumu alındı.");
	}

	public void DebugListStates()
	{
		if (base.isServer)
		{
			Debug.Log($"Server - Toplam item: {allCollectableItems.Length}");
			Debug.Log($"Server - SyncList boyutu: {syncedItemStates.Count}");
			{
				foreach (CollectableItemSync syncedItemState in syncedItemStates)
				{
					if (syncedItemState.isResearched || syncedItemState.isLearned)
					{
						Debug.Log($"Server - {syncedItemState.itemName}: Researched={syncedItemState.isResearched}, Learned={syncedItemState.isLearned}");
					}
				}
				return;
			}
		}
		Debug.Log($"Client - Cache boyutu: {clientSyncedStates.Count}");
		foreach (KeyValuePair<string, CollectableItemState> clientSyncedState in clientSyncedStates)
		{
			if (clientSyncedState.Value.isResearched || clientSyncedState.Value.isLearned)
			{
				Debug.Log($"Client - {clientSyncedState.Key}: Researched={clientSyncedState.Value.isResearched}, Learned={clientSyncedState.Value.isLearned}");
			}
		}
	}

	public CollectableDataSaver()
	{
		InitSyncObject(syncedItemStates);
		InitSyncObject(syncedCategoryStates);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdSetCategoryUnlocked__String__Boolean(string categoryName, bool unlocked)
	{
		ServerSetCategoryUnlocked(categoryName, unlocked);
	}

	protected static void InvokeUserCode_CmdSetCategoryUnlocked__String__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetCategoryUnlocked called on client.");
		}
		else
		{
			((CollectableDataSaver)obj).UserCode_CmdSetCategoryUnlocked__String__Boolean(reader.ReadString(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcNotifyCategoryUnlocked__String(string categoryName)
	{
		Singleton<UserMessagePanel>.Instance?.SendMessageToPanel(categoryName + " kategorisi açıldı!");
	}

	protected static void InvokeUserCode_RpcNotifyCategoryUnlocked__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyCategoryUnlocked called on server.");
		}
		else
		{
			((CollectableDataSaver)obj).UserCode_RpcNotifyCategoryUnlocked__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdSetItemResearched__String__Boolean(string itemName, bool researched)
	{
		ServerSetItemResearched(itemName, researched);
	}

	protected static void InvokeUserCode_CmdSetItemResearched__String__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetItemResearched called on client.");
		}
		else
		{
			((CollectableDataSaver)obj).UserCode_CmdSetItemResearched__String__Boolean(reader.ReadString(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdSetItemLearned__String__Boolean(string itemName, bool learned)
	{
		ServerSetItemLearned(itemName, learned);
	}

	protected static void InvokeUserCode_CmdSetItemLearned__String__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetItemLearned called on client.");
		}
		else
		{
			((CollectableDataSaver)obj).UserCode_CmdSetItemLearned__String__Boolean(reader.ReadString(), reader.ReadBool());
		}
	}

	protected void UserCode_RpcNotifyItemResearched__String(string itemName)
	{
		CollectableItemData itemByName = GetItemByName(itemName);
		if (itemByName != null)
		{
			Singleton<UserMessagePanel>.Instance?.SendMessageToPanel(itemByName.itemName + " araştırıldı!", itemByName);
		}
	}

	protected static void InvokeUserCode_RpcNotifyItemResearched__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyItemResearched called on server.");
		}
		else
		{
			((CollectableDataSaver)obj).UserCode_RpcNotifyItemResearched__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcNotifyItemLearned__String(string itemName)
	{
		CollectableItemData itemByName = GetItemByName(itemName);
		if (!(itemByName != null))
		{
			return;
		}
		itemByName.isLearned = true;
		if (clientSyncedStates.ContainsKey(itemByName.itemName))
		{
			CollectableItemState collectableItemState = clientSyncedStates[itemByName.itemName];
			collectableItemState.isLearned = true;
			clientSyncedStates[itemByName.itemName] = collectableItemState;
		}
		if (itemByName.itemType == ItemType.StoryPaper)
		{
			string message = "Story Paper Found!";
			if (storyPaperFoundLocalized != null && !storyPaperFoundLocalized.IsEmpty)
			{
				string localizedString = storyPaperFoundLocalized.GetLocalizedString();
				if (!string.IsNullOrEmpty(localizedString))
				{
					message = localizedString;
				}
			}
			Singleton<UserMessagePanelCenter>.Instance?.SendMessageToPanel(message);
			StoryBoardPanel storyBoardPanel = Object.FindObjectOfType<StoryBoardPanel>();
			if (storyBoardPanel != null)
			{
				storyBoardPanel.RefreshStoryPapers();
			}
		}
		else
		{
			Singleton<UserMessagePanel>.Instance?.SendMessageToPanel(itemByName.itemName + " öğrenildi!", itemByName);
		}
	}

	protected static void InvokeUserCode_RpcNotifyItemLearned__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNotifyItemLearned called on server.");
		}
		else
		{
			((CollectableDataSaver)obj).UserCode_RpcNotifyItemLearned__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcForceRefreshClient__NetworkConnection(NetworkConnection conn)
	{
		StartCoroutine(ForceClientRefresh());
	}

	protected static void InvokeUserCode_RpcForceRefreshClient__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcForceRefreshClient called on server.");
		}
		else
		{
			((CollectableDataSaver)obj).UserCode_RpcForceRefreshClient__NetworkConnection(null);
		}
	}

	static CollectableDataSaver()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(CollectableDataSaver), "System.Void CollectableDataSaver::CmdSetCategoryUnlocked(System.String,System.Boolean)", InvokeUserCode_CmdSetCategoryUnlocked__String__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(CollectableDataSaver), "System.Void CollectableDataSaver::CmdSetItemResearched(System.String,System.Boolean)", InvokeUserCode_CmdSetItemResearched__String__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(CollectableDataSaver), "System.Void CollectableDataSaver::CmdSetItemLearned(System.String,System.Boolean)", InvokeUserCode_CmdSetItemLearned__String__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(CollectableDataSaver), "System.Void CollectableDataSaver::RpcNotifyCategoryUnlocked(System.String)", InvokeUserCode_RpcNotifyCategoryUnlocked__String);
		RemoteProcedureCalls.RegisterRpc(typeof(CollectableDataSaver), "System.Void CollectableDataSaver::RpcNotifyItemResearched(System.String)", InvokeUserCode_RpcNotifyItemResearched__String);
		RemoteProcedureCalls.RegisterRpc(typeof(CollectableDataSaver), "System.Void CollectableDataSaver::RpcNotifyItemLearned(System.String)", InvokeUserCode_RpcNotifyItemLearned__String);
		RemoteProcedureCalls.RegisterRpc(typeof(CollectableDataSaver), "System.Void CollectableDataSaver::RpcForceRefreshClient(Mirror.NetworkConnection)", InvokeUserCode_RpcForceRefreshClient__NetworkConnection);
	}
}
