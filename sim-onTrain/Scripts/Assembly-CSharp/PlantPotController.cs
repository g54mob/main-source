using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlantPotController : NetworkBehaviour, IInteractable
{
	[Serializable]
	public class PlantPotSaveData
	{
		public List<PlantData> plantDataList;
	}

	public List<ItemType> accectablePlantTypes = new List<ItemType>();

	public List<PlantPlacer> plantPoints = new List<PlantPlacer>();

	public SyncList<PlantData> plants = new SyncList<PlantData>();

	private bool isNetworkReady;

	[Header("Water Settings")]
	[SerializeField]
	private float emptyPotWaterDuration = 30f;

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	private bool isActive = true;

	private bool isShowingInteraction;

	private bool didHideBottomInfo;

	private float nextSyncTime;

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

	private void Awake()
	{
		if (plantPoints.Count == 0)
		{
			plantPoints.AddRange(GetComponentsInChildren<PlantPlacer>());
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		CheckNetworkReady();
		for (int i = 0; i < plantPoints.Count; i++)
		{
			plants.Add(new PlantData());
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		CheckNetworkReady();
		plants.Callback += OnPlantsUpdated;
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
		for (int i = 0; i < plants.Count && i < plantPoints.Count; i++)
		{
			if (plants[i].isPlanted)
			{
				plantPoints[i].UpdatePlantVisual(plants[i]);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdAddPlant(int placerIndex, string itemName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(placerIndex);
		writer.WriteString(itemName);
		SendCommandInternal("System.Void PlantPotController::CmdAddPlant(System.Int32,System.String)", -1165764440, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAddWater(int placerIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(placerIndex);
		SendCommandInternal("System.Void PlantPotController::CmdAddWater(System.Int32)", 1165519640, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdCollectPlant(int placerIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(placerIndex);
		SendCommandInternal("System.Void PlantPotController::CmdCollectPlant(System.Int32)", -312670653, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdRemovePlant(int placerIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(placerIndex);
		SendCommandInternal("System.Void PlantPotController::CmdRemovePlant(System.Int32)", -933096695, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private void OnPlantsUpdated(SyncList<PlantData>.Operation op, int index, PlantData oldItem, PlantData newItem)
	{
		if (plantPoints == null || plantPoints.Count == 0)
		{
			plantPoints.AddRange(GetComponentsInChildren<PlantPlacer>());
		}
		if (index >= plantPoints.Count || plantPoints[index] == null)
		{
			return;
		}
		switch (op)
		{
		case SyncList<PlantData>.Operation.OP_ADD:
		case SyncList<PlantData>.Operation.OP_INSERT:
			plantPoints[index].UpdatePlantVisual(newItem);
			break;
		case SyncList<PlantData>.Operation.OP_SET:
			plantPoints[index].UpdatePlantVisual(newItem);
			break;
		case SyncList<PlantData>.Operation.OP_REMOVEAT:
			plantPoints[index].ClearPlant();
			break;
		case SyncList<PlantData>.Operation.OP_CLEAR:
		{
			foreach (PlantPlacer plantPoint in plantPoints)
			{
				if (plantPoint != null)
				{
					plantPoint.ClearPlant();
				}
			}
			break;
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
		for (int i = 0; i < plants.Count; i++)
		{
			if (!plants[i].isPlanted && !plants[i].itHasWater)
			{
				continue;
			}
			PlantData plantData = plants[i];
			bool flag2 = false;
			if (plantData.itHasWater)
			{
				if (plantData.isPlanted)
				{
					if (plantData.growingStatus >= 1f)
					{
						plantData.itHasWater = false;
						plantData.waterTimer = 0f;
						flag2 = true;
					}
				}
				else
				{
					plantData.waterTimer -= Time.deltaTime;
					if (plantData.waterTimer <= 0f)
					{
						plantData.itHasWater = false;
						plantData.waterTimer = 0f;
						flag2 = true;
					}
				}
			}
			if (plantData.isPlanted)
			{
				CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(plantData.plantName);
				if (itemFromName != null && plantData.itHasWater && plantData.growingStatus < 1f)
				{
					int currentGrowLevel = plantData.currentGrowLevel;
					float num = Time.deltaTime / itemFromName.growingTime;
					plantData.growingStatus += num;
					plantData.growingStatus = Mathf.Clamp01(plantData.growingStatus);
					int count = itemFromName.plantLevelPrefabs.Count;
					if (count > 0)
					{
						int num2 = 0;
						if (plantData.growingStatus >= 1f)
						{
							num2 = count - 1;
							flag2 = true;
						}
						else if (count > 1)
						{
							float num3 = 1f / (float)(count - 1);
							num2 = Mathf.Min((int)(plantData.growingStatus / num3), count - 2);
						}
						if (currentGrowLevel != num2)
						{
							plantData.currentGrowLevel = num2;
							flag2 = true;
						}
					}
					if (flag)
					{
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				plants.RemoveAt(i);
				plants.Insert(i, plantData);
			}
		}
		if (flag)
		{
			nextSyncTime = Time.time + syncInterval;
		}
	}

	public int GetPlacerIndex(PlantPlacer placer)
	{
		return plantPoints.IndexOf(placer);
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (InteractionPanel.Instance != null && InteractionPanel.Instance.IsBottomInfoLocked)
		{
			InteractionPanel.Instance.UnlockAndHideBottomInfo();
			didHideBottomInfo = true;
		}
		if (!isShowingInteraction)
		{
			ShowRemoveInteraction(player.transform);
			isShowingInteraction = true;
		}
	}

	public void StopInteract()
	{
		isShowingInteraction = false;
		InteractionPanel.Instance.HidePanels();
		if (didHideBottomInfo)
		{
			didHideBottomInfo = false;
			EastUpPlayerItemManager eastUpPlayerItemManager = UnityEngine.Object.FindObjectOfType<EastUpPlayerItemManager>();
			if (eastUpPlayerItemManager != null)
			{
				eastUpPlayerItemManager.UpdateConsumableInteraction();
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

	public string SaveState()
	{
		PlantPotSaveData plantPotSaveData = new PlantPotSaveData
		{
			plantDataList = new List<PlantData>()
		};
		for (int i = 0; i < plants.Count; i++)
		{
			plantPotSaveData.plantDataList.Add(plants[i]);
		}
		return JsonUtility.ToJson(plantPotSaveData);
	}

	public void LoadState(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			return;
		}
		try
		{
			PlantPotSaveData plantPotSaveData = JsonUtility.FromJson<PlantPotSaveData>(data);
			if (plantPotSaveData != null && plantPotSaveData.plantDataList != null && base.isServer)
			{
				for (int i = 0; i < plantPotSaveData.plantDataList.Count && i < plants.Count; i++)
				{
					plants[i] = plantPotSaveData.plantDataList[i];
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("[PlantPot] Failed to load save data: " + ex.Message);
		}
	}

	public PlantPotController()
	{
		InitSyncObject(plants);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddPlant__Int32__String(int placerIndex, string itemName)
	{
		if (isNetworkReady && placerIndex >= 0 && placerIndex < plants.Count)
		{
			CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(itemName);
			if (!(itemFromName == null) && (accectablePlantTypes.Contains(itemFromName.itemType) || itemFromName.isPlantable))
			{
				PlantData plantData = plants[placerIndex];
				bool itHasWater = plantData.itHasWater;
				float waterTimer = plantData.waterTimer;
				PlantData value = new PlantData
				{
					plantName = itemFromName.itemName,
					isPlanted = true,
					growingStatus = 0f,
					currentGrowLevel = 0,
					itHasWater = itHasWater,
					waterTimer = waterTimer
				};
				plants[placerIndex] = value;
			}
		}
	}

	protected static void InvokeUserCode_CmdAddPlant__Int32__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddPlant called on client.");
		}
		else
		{
			((PlantPotController)obj).UserCode_CmdAddPlant__Int32__String(reader.ReadInt(), reader.ReadString());
		}
	}

	protected void UserCode_CmdAddWater__Int32(int placerIndex)
	{
		if (!isNetworkReady)
		{
			Debug.LogError("[SERVER] Network not ready for CmdAddWater");
			return;
		}
		if (placerIndex < 0 || placerIndex >= plants.Count)
		{
			Debug.LogError($"[SERVER] Invalid placerIndex in CmdAddWater: {placerIndex}");
			return;
		}
		if (plants[placerIndex].itHasWater)
		{
			Debug.LogWarning("[SERVER] Cannot add water - already has water");
			return;
		}
		PlantData plantData = plants[placerIndex];
		plantData.itHasWater = true;
		plantData.waterTimer = emptyPotWaterDuration;
		plants[placerIndex] = plantData;
	}

	protected static void InvokeUserCode_CmdAddWater__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddWater called on client.");
		}
		else
		{
			((PlantPotController)obj).UserCode_CmdAddWater__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdCollectPlant__Int32(int placerIndex)
	{
		if (!isNetworkReady)
		{
			Debug.LogError("[SERVER] Network not ready for CmdCollectPlant");
			return;
		}
		if (placerIndex < 0 || placerIndex >= plants.Count)
		{
			Debug.LogError($"[SERVER] Invalid placerIndex in CmdCollectPlant: {placerIndex}");
			return;
		}
		if (!plants[placerIndex].isPlanted || plants[placerIndex].growingStatus < 1f)
		{
			Debug.LogWarning($"[SERVER] Cannot collect - isPlanted: {plants[placerIndex].isPlanted}, growingStatus: {plants[placerIndex].growingStatus}");
			return;
		}
		PlantData value = new PlantData();
		plants[placerIndex] = value;
	}

	protected static void InvokeUserCode_CmdCollectPlant__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCollectPlant called on client.");
		}
		else
		{
			((PlantPotController)obj).UserCode_CmdCollectPlant__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdRemovePlant__Int32(int placerIndex)
	{
		if (!isNetworkReady)
		{
			Debug.LogError("[SERVER] Network not ready for CmdRemovePlant");
			return;
		}
		if (placerIndex < 0 || placerIndex >= plants.Count)
		{
			Debug.LogError($"[SERVER] Invalid placerIndex in CmdRemovePlant: {placerIndex}");
			return;
		}
		if (!plants[placerIndex].isPlanted)
		{
			Debug.LogWarning($"[SERVER] No plant to remove at index: {placerIndex}");
			return;
		}
		PlantData value = new PlantData();
		plants[placerIndex] = value;
	}

	protected static void InvokeUserCode_CmdRemovePlant__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRemovePlant called on client.");
		}
		else
		{
			((PlantPotController)obj).UserCode_CmdRemovePlant__Int32(reader.ReadInt());
		}
	}

	static PlantPotController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlantPotController), "System.Void PlantPotController::CmdAddPlant(System.Int32,System.String)", InvokeUserCode_CmdAddPlant__Int32__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlantPotController), "System.Void PlantPotController::CmdAddWater(System.Int32)", InvokeUserCode_CmdAddWater__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlantPotController), "System.Void PlantPotController::CmdCollectPlant(System.Int32)", InvokeUserCode_CmdCollectPlant__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlantPotController), "System.Void PlantPotController::CmdRemovePlant(System.Int32)", InvokeUserCode_CmdRemovePlant__Int32, requiresAuthority: false);
	}
}
