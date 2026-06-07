using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class SaveManager : NetworkBehaviour
{
	public int curDay;

	public int curDifficulty;

	public float money;

	public int tokens;

	public List<string> spawnedBefore;

	public List<string> npcsKilled;

	public List<string> npcsKilledTemp;

	public List<int> instantiablesID;

	public List<int> instantiablesShiftsAlive;

	public List<string> instantiablesAssociatedTexts;

	public List<float> instantiablesPosX;

	public List<float> instantiablesPosY;

	public List<float> instantiablesPosZ;

	public List<float> instantiablesRotX;

	public List<float> instantiablesRotY;

	public List<float> instantiablesRotZ;

	public List<float> instantiablesRotW;

	public int seed;

	public List<int> seedForEvents;

	public List<int> dayObjsSpawnedBefore;

	public List<int> storeUpgradesPurchased = new List<int>();

	public List<int> weaponsPurchased = new List<int>();

	public int refreshes;

	[SyncVar]
	public int maxInventorySpace = 2;

	public int[] maxShelfItems;

	public int[] curShelfItems;

	public List<ulong> steamIds;

	public List<List<int>> inventoryIds = new List<List<int>>();

	public List<List<int>> inventoryAmounts = new List<List<int>>();

	public List<List<int>> boxStorages = new List<List<int>>();

	public List<List<int>> trashAmounts = new List<List<int>>();

	public int huntsDone;

	public GameObject[] instantiablesAtlas;

	public GameObject securityScanner;

	public GameObject aisleSigns;

	public GameObject ceilingFans;

	public float mandatoryRevenue = 30f;

	public List<int> customizablesUnlocked = new List<int>();

	public static SaveManager Instance { get; private set; }

	public int NetworkmaxInventorySpace
	{
		get
		{
			return maxInventorySpace;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref maxInventorySpace, 1uL, null);
		}
	}

	public void Save()
	{
		if (!base.isServer || EODReportValues.Instance.mandatoryRevenue > EODReportValues.Instance.todayMoneyGained - EODReportValues.Instance.todayMoneyLost)
		{
			return;
		}
		PlayerPrefs.SetInt("EventSeedSet" + PlayerPrefs.GetInt("CurSaveSlot", 0), 1);
		instantiablesID.Clear();
		instantiablesPosX.Clear();
		instantiablesPosY.Clear();
		instantiablesPosZ.Clear();
		instantiablesRotX.Clear();
		instantiablesRotY.Clear();
		instantiablesRotZ.Clear();
		instantiablesRotW.Clear();
		instantiablesAssociatedTexts.Clear();
		instantiablesShiftsAlive.Clear();
		SaveSnapshotObject[] array = Object.FindObjectsOfType<SaveSnapshotObject>();
		foreach (SaveSnapshotObject saveSnapshotObject in array)
		{
			Transform transform = saveSnapshotObject.transform;
			instantiablesID.Add(saveSnapshotObject.instantiableID);
			instantiablesAssociatedTexts.Add(saveSnapshotObject.associatedString);
			instantiablesPosX.Add(transform.position.x);
			instantiablesPosY.Add(transform.position.y);
			instantiablesPosZ.Add(transform.position.z);
			instantiablesRotX.Add(transform.rotation.x);
			instantiablesRotY.Add(transform.rotation.y);
			instantiablesRotZ.Add(transform.rotation.z);
			instantiablesRotW.Add(transform.rotation.w);
			instantiablesShiftsAlive.Add(saveSnapshotObject.shiftsAlive);
		}
		RestockShelf[] restockShelves = Shelves.Instance.restockShelves;
		for (int j = 0; j < restockShelves.Length; j++)
		{
			if (!(restockShelves[j] == null))
			{
				maxShelfItems[j] = restockShelves[j].maxProductsOnShelf;
				curShelfItems[j] = restockShelves[j].productsOnShelf;
			}
		}
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			NetworkConnectionToClient value = connection.Value;
			if (value == null || value.identity == null)
			{
				continue;
			}
			InventoryManager component = value.identity.GetComponent<InventoryManager>();
			if (component == null)
			{
				continue;
			}
			ulong steamId = component.steamId;
			bool flag = false;
			for (int k = 0; k < steamIds.Count; k++)
			{
				if (steamIds[k] == steamId)
				{
					List<int> list = new List<int>();
					List<int> list2 = new List<int>();
					List<int> list3 = new List<int>();
					List<int> list4 = new List<int>();
					for (int l = 0; l < component.inventoryIds.Length; l++)
					{
						list.Add(component.inventoryIds[l]);
						list2.Add(component.inventoryAmounts[l]);
						list3.Add(component.crateStorages[l]);
						list4.Add(component.trash[l]);
					}
					inventoryIds[k] = list;
					inventoryAmounts[k] = list2;
					boxStorages[k] = list3;
					trashAmounts[k] = list4;
					flag = true;
				}
			}
			if (!flag)
			{
				List<int> list5 = new List<int>();
				List<int> list6 = new List<int>();
				List<int> list7 = new List<int>();
				List<int> list8 = new List<int>();
				for (int m = 0; m < component.inventoryIds.Length; m++)
				{
					list5.Add(component.inventoryIds[m]);
					list6.Add(component.inventoryAmounts[m]);
					list7.Add(component.crateStorages[m]);
					list8.Add(component.trash[m]);
				}
				steamIds.Add(steamId);
				inventoryIds.Add(list5);
				inventoryAmounts.Add(list6);
				boxStorages.Add(list7);
				trashAmounts.Add(list8);
			}
		}
		SaveSystem.SaveState(this);
	}

	public void LoadSave()
	{
		if (!base.isServer)
		{
			return;
		}
		SaveData saveData = SaveSystem.LoadState();
		if (saveData == null)
		{
			return;
		}
		curDay = saveData.curDay;
		curDifficulty = saveData.curDifficulty;
		spawnedBefore = saveData.spawnedBefore;
		instantiablesID = saveData.instantiablesID;
		instantiablesPosX = saveData.instantiablesPosX;
		instantiablesPosY = saveData.instantiablesPosY;
		instantiablesPosZ = saveData.instantiablesPosZ;
		instantiablesRotX = saveData.instantiablesRotX;
		instantiablesRotY = saveData.instantiablesRotY;
		instantiablesRotZ = saveData.instantiablesRotZ;
		instantiablesRotW = saveData.instantiablesRotW;
		instantiablesAssociatedTexts = saveData.instantiablesAssociatedTexts;
		instantiablesShiftsAlive = saveData.instantiablesShiftsAlive;
		money = saveData.money;
		tokens = saveData.tokens;
		seedForEvents = saveData.seedForEvents;
		maxShelfItems = saveData.maxShelfItems;
		curShelfItems = saveData.curShelfItems;
		seed = saveData.seed;
		dayObjsSpawnedBefore = saveData.dayObjsSpawnedBefore;
		npcsKilled = saveData.npcsKilled;
		NetworkmaxInventorySpace = saveData.maxInventorySpace;
		steamIds = saveData.steamIds;
		inventoryIds = saveData.inventoryIds;
		inventoryAmounts = saveData.inventoryAmounts;
		boxStorages = saveData.boxStorages;
		trashAmounts = saveData.trashAmounts;
		refreshes = saveData.refreshes;
		storeUpgradesPurchased = saveData.storeUpgradesPurchased;
		weaponsPurchased = saveData.weaponsPurchased;
		huntsDone = saveData.huntsDone;
		customizablesUnlocked = saveData.customizablesUnlocked;
		mandatoryRevenue = 25 + curDay * 5;
		mandatoryRevenue = Mathf.Clamp(mandatoryRevenue, 30f, 80f);
		EODReportValues.Instance.mandatoryRevenue = mandatoryRevenue;
		EODReportValues.Instance.curDay = curDay;
		StoreManager.Instance.mandatoryRevenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		StoreManager.Instance.mandatoryRevenueText.text = "$" + mandatoryRevenue;
		for (int i = 0; i < instantiablesID.Count; i++)
		{
			GameObject gameObject = Object.Instantiate(instantiablesAtlas[instantiablesID[i]], new Vector3(instantiablesPosX[i], instantiablesPosY[i], instantiablesPosZ[i]), new Quaternion(instantiablesRotX[i], instantiablesRotY[i], instantiablesRotZ[i], instantiablesRotW[i]));
			NetworkServer.Spawn(gameObject);
			gameObject.GetComponent<SaveSnapshotObject>().CheckShiftsAlive(instantiablesShiftsAlive[i] + 1);
			if (instantiablesID[i] == 9 || instantiablesID[i] == 13)
			{
				gameObject.GetComponent<CreatingPoster>().LoadPosterRpc(instantiablesAssociatedTexts[i]);
			}
		}
		Invoke("DelayedLoadSave", 2f);
		SetValuesForClients();
	}

	private void DelayedLoadSave()
	{
		RestockShelf[] restockShelves = Shelves.Instance.restockShelves;
		for (int i = 0; i < restockShelves.Length; i++)
		{
			if (!(restockShelves[i] == null) && maxShelfItems[i] != curShelfItems[i])
			{
				restockShelves[i].shelfMan.RemoveRandomItems(maxShelfItems[i] - curShelfItems[i]);
			}
		}
		if ((bool)PurchaseManager.Instance)
		{
			PurchaseManager.Instance.Invoke("LoadTotalBalance", 5f);
			PurchaseManager.Instance.Invoke("LoadTotalBalance", 10f);
			PurchaseManager.Instance.Invoke("LoadTotalBalance", 15f);
			PurchaseManager.Instance.Invoke("LoadTotalBalance", 20f);
		}
	}

	public void SetValuesForClients()
	{
		if (base.isServer)
		{
			SetValuesForClientsRpc();
		}
		else
		{
			SetValuesForClientsCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void SetValuesForClientsCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void SaveManager::SetValuesForClientsCmd()", 523287866, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void SetValuesForClientsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SaveManager::SetValuesForClientsRpc()", -519182739, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void EnableSecurityScanners()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SaveManager::EnableSecurityScanners()", 2096732889, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void EnableAisleSigns()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SaveManager::EnableAisleSigns()", -927037570, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void EnableCeilingFans()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void SaveManager::EnableCeilingFans()", -2145102181, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ActuallySetValuesForClientsRpc(float money_, int tokens_, List<string> npcsKilled_, int maxInventorySpace_, List<ulong> steamIds_, List<List<int>> inventoryIds_, List<List<int>> inventoryAmounts_, List<List<int>> boxStorages_, List<List<int>> trashAmounts_, float quota, List<int> customizablesUnlocked_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(money_);
		writer.WriteVarInt(tokens_);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, npcsKilled_);
		writer.WriteVarInt(maxInventorySpace_);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EUInt64_003E(writer, steamIds_);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(writer, inventoryIds_);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(writer, inventoryAmounts_);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(writer, boxStorages_);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(writer, trashAmounts_);
		writer.WriteFloat(quota);
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(writer, customizablesUnlocked_);
		SendRPCInternal("System.Void SaveManager::ActuallySetValuesForClientsRpc(System.Single,System.Int32,System.Collections.Generic.List`1<System.String>,System.Int32,System.Collections.Generic.List`1<System.UInt64>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Single,System.Collections.Generic.List`1<System.Int32>)", 713218186, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		Invoke("LoadSave", 0.1f);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SetValuesForClientsCmd()
	{
		if (base.isServer)
		{
			SetValuesForClientsRpc();
		}
	}

	protected static void InvokeUserCode_SetValuesForClientsCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetValuesForClientsCmd called on client.");
		}
		else
		{
			((SaveManager)obj).UserCode_SetValuesForClientsCmd();
		}
	}

	protected void UserCode_SetValuesForClientsRpc()
	{
		PurchaseManager.Instance.SetRefreshesForAllClients(refreshes);
		if (!base.isServer)
		{
			return;
		}
		ActuallySetValuesForClientsRpc(money, tokens, npcsKilled, maxInventorySpace, steamIds, inventoryIds, inventoryAmounts, boxStorages, trashAmounts, mandatoryRevenue, customizablesUnlocked);
		StoreManager.Instance.SetTokenBalanceRpc_(tokens);
		foreach (int item in storeUpgradesPurchased)
		{
			switch (item)
			{
			case 5:
				EnableSecurityScanners();
				break;
			case 0:
				EnableCeilingFans();
				break;
			case 1:
				EnableAisleSigns();
				break;
			}
		}
	}

	protected static void InvokeUserCode_SetValuesForClientsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetValuesForClientsRpc called on server.");
		}
		else
		{
			((SaveManager)obj).UserCode_SetValuesForClientsRpc();
		}
	}

	protected void UserCode_EnableSecurityScanners()
	{
		securityScanner.SetActive(value: true);
	}

	protected static void InvokeUserCode_EnableSecurityScanners(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EnableSecurityScanners called on server.");
		}
		else
		{
			((SaveManager)obj).UserCode_EnableSecurityScanners();
		}
	}

	protected void UserCode_EnableAisleSigns()
	{
		aisleSigns.SetActive(value: true);
	}

	protected static void InvokeUserCode_EnableAisleSigns(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EnableAisleSigns called on server.");
		}
		else
		{
			((SaveManager)obj).UserCode_EnableAisleSigns();
		}
	}

	protected void UserCode_EnableCeilingFans()
	{
		ceilingFans.SetActive(value: true);
	}

	protected static void InvokeUserCode_EnableCeilingFans(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC EnableCeilingFans called on server.");
		}
		else
		{
			((SaveManager)obj).UserCode_EnableCeilingFans();
		}
	}

	protected void UserCode_ActuallySetValuesForClientsRpc__Single__Int32__List_00601__Int32__List_00601__List_00601__List_00601__List_00601__List_00601__Single__List_00601(float money_, int tokens_, List<string> npcsKilled_, int maxInventorySpace_, List<ulong> steamIds_, List<List<int>> inventoryIds_, List<List<int>> inventoryAmounts_, List<List<int>> boxStorages_, List<List<int>> trashAmounts_, float quota, List<int> customizablesUnlocked_)
	{
		StoreManager.Instance.mandatoryRevenueText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		StoreManager.Instance.mandatoryRevenueText.text = "$" + quota;
		customizablesUnlocked = customizablesUnlocked_;
		steamIds = steamIds_;
		NetworkmaxInventorySpace = maxInventorySpace_;
		inventoryIds = inventoryIds_;
		inventoryAmounts = inventoryAmounts_;
		boxStorages = boxStorages_;
		trashAmounts = trashAmounts_;
		if (base.isServer)
		{
			InventoryManager[] array = Object.FindObjectsOfType<InventoryManager>(includeInactive: true);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetMaxInventorySlots(maxInventorySpace);
			}
			ReviewsManager.Instance.UpdateStockPenalty(0);
		}
		npcsKilled = npcsKilled_;
		money = money_;
		ClientPlayer.Instance.inventoryMan.LoadInventoryFromLastSave();
	}

	protected static void InvokeUserCode_ActuallySetValuesForClientsRpc__Single__Int32__List_00601__Int32__List_00601__List_00601__List_00601__List_00601__List_00601__Single__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallySetValuesForClientsRpc called on server.");
		}
		else
		{
			((SaveManager)obj).UserCode_ActuallySetValuesForClientsRpc__Single__Int32__List_00601__Int32__List_00601__List_00601__List_00601__List_00601__List_00601__Single__List_00601(reader.ReadFloat(), reader.ReadVarInt(), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader), reader.ReadVarInt(), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EUInt64_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(reader), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E_003E(reader), reader.ReadFloat(), GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(reader));
		}
	}

	static SaveManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(SaveManager), "System.Void SaveManager::SetValuesForClientsCmd()", InvokeUserCode_SetValuesForClientsCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(SaveManager), "System.Void SaveManager::SetValuesForClientsRpc()", InvokeUserCode_SetValuesForClientsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(SaveManager), "System.Void SaveManager::EnableSecurityScanners()", InvokeUserCode_EnableSecurityScanners);
		RemoteProcedureCalls.RegisterRpc(typeof(SaveManager), "System.Void SaveManager::EnableAisleSigns()", InvokeUserCode_EnableAisleSigns);
		RemoteProcedureCalls.RegisterRpc(typeof(SaveManager), "System.Void SaveManager::EnableCeilingFans()", InvokeUserCode_EnableCeilingFans);
		RemoteProcedureCalls.RegisterRpc(typeof(SaveManager), "System.Void SaveManager::ActuallySetValuesForClientsRpc(System.Single,System.Int32,System.Collections.Generic.List`1<System.String>,System.Int32,System.Collections.Generic.List`1<System.UInt64>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Int32>>,System.Single,System.Collections.Generic.List`1<System.Int32>)", InvokeUserCode_ActuallySetValuesForClientsRpc__Single__Int32__List_00601__Int32__List_00601__List_00601__List_00601__List_00601__List_00601__Single__List_00601);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(maxInventorySpace);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(maxInventorySpace);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref maxInventorySpace, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref maxInventorySpace, null, reader.ReadVarInt());
		}
	}
}
