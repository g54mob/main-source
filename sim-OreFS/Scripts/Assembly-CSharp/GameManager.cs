using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Digger.Modules.Core.Sources;
using Digger.Modules.Runtime.Sources;
using Enviro;
using GameCreator.Runtime.Common;
using Kamgam.SettingsGenerator;
using Mirror;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameSave
{
	[Serializable]
	public class BuildingSpawnData
	{
		public string uniqueId;

		public int buildingItemSOIndex;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public float rotW;

		public bool wasOnSocket;
	}

	[Serializable]
	public class BuildingListSaveData
	{
		public List<BuildingSpawnData> buildings = new List<BuildingSpawnData>();
	}

	public static GameManager Instance;

	private int lastMinute = -1;

	[Header("Digger Components")]
	public DiggerMaster DiggerMaster;

	public DiggerMasterRuntime DiggerMasterRuntime;

	public DiggerNavMeshRuntime NavMeshRuntime;

	[Header("Player References")]
	public PlayerProgressManager playerProgressManager;

	public T_Equipments localEquipments;

	public T_Bag localBag;

	[Header("UI References")]
	public UIManager UImanager;

	[Header("References")]
	public PoolingManager poolingManager;

	public NotificationManager notificationManager;

	public StorageManager storageManager;

	public FactoryManager factoryManager;

	public DayNightManager dayNightManager;

	public DayEndManager dayEndManager;

	[Header("Tutorial")]
	public TutorialManager tutorialManager;

	[Header("Voice Chat")]
	public VoiceActivationMode voiceActivationMode;

	[Header("Machine Settings")]
	public int machineMaxItemCount = 2000;

	[Header("Sack Settings")]
	[Tooltip("Bir sack'e konulabilecek maksimum item sayısı")]
	public int MaxItemsPerSack = 10;

	[Header("Building Tracking")]
	[SerializeField]
	private bool buildingDebugLogs = true;

	private readonly List<BuildingObject> spawnedBuildings = new List<BuildingObject>();

	private bool _isRestoringFromSave;

	[Header("Object References")]
	public Transform oreSpawnParent;

	public Transform factorySpawnParent;

	[Header("Travel Transition Points")]
	public VehicleSplineTravelTransition FactoryTransitionPoint;

	public VehicleSplineTravelTransition DigsiteTransitionPoint;

	[HideInInspector]
	public List<VehicleSplineTravelTransition> DigsiteExitPoints = new List<VehicleSplineTravelTransition>();

	[Header("Teleport Markers")]
	[Tooltip("Digsite'daki bus stop marker - yeni bağlanan oyuncuların ışınlanacağı nokta")]
	public Transform digsiteMarker;

	[Tooltip("Factory'deki bus stop marker")]
	public Transform factoryMarker;

	[Header("Time")]
	public string CurrentTimeString { get; private set; } = "00:00";

	public bool IsRestoringFromSave => _isRestoringFromSave;

	public string SaveID => "game-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(BuildingListSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public event Action<string> OnMinuteChanged;

	private void Awake()
	{
		Instance = this;
		voiceActivationMode = VoiceChatModeConnection.CachedMode;
	}

	private void Update()
	{
		UpdateTimeString();
	}

	public void OnEnable()
	{
		MusicManager.Instance?.ChangeMusic(MusicManager.MusicMode.InGame);
	}

	private void UpdateTimeString()
	{
		if (!(EnviroManager.instance == null) && !(EnviroManager.instance.Time == null))
		{
			int minutes = EnviroManager.instance.Time.minutes;
			if (minutes != lastMinute)
			{
				lastMinute = minutes;
				int hours = EnviroManager.instance.Time.hours;
				CurrentTimeString = $"{hours:D2}:{minutes:D2}";
				this.OnMinuteChanged?.Invoke(CurrentTimeString);
			}
		}
	}

	public void OpenLoadingUI(LoadingType loadingType)
	{
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Show(loadingType);
		}
	}

	public void CloseLoadingUI(LoadingType loadingType)
	{
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.Hide(loadingType);
		}
	}

	public void CloseLoadingUIImmediate(LoadingType loadingType)
	{
		if (LoadingManagerUI.Instance != null)
		{
			LoadingManagerUI.HideImmediate(loadingType);
		}
	}

	public void OpenCustomization()
	{
		GamePlayer gamePlayer = NetworkClient.localPlayer?.GetComponent<GamePlayer>();
		if (gamePlayer != null)
		{
			gamePlayer.onOpenCustomization?.Invoke();
		}
	}

	public void RegisterDigsiteExitPoint(VehicleSplineTravelTransition point)
	{
		if (point != null && !DigsiteExitPoints.Contains(point))
		{
			DigsiteExitPoints.Add(point);
		}
	}

	public VehicleSplineTravelTransition GetDestinationTransitionPoint(VehicleSplineTravelTransition from)
	{
		if (from == null)
		{
			return null;
		}
		if (from == FactoryTransitionPoint)
		{
			return DigsiteTransitionPoint;
		}
		if (from == DigsiteTransitionPoint)
		{
			return FactoryTransitionPoint;
		}
		if (DigsiteExitPoints.Contains(from))
		{
			return FactoryTransitionPoint;
		}
		return null;
	}

	public void RegisterBuilding(BuildingObject building)
	{
		if (!(building == null) && !spawnedBuildings.Contains(building))
		{
			spawnedBuildings.Add(building);
			if (buildingDebugLogs)
			{
				Debug.Log($"[GameManager] Building registered: {building.UniqueBuildingId}, Total: {spawnedBuildings.Count}");
			}
		}
	}

	public void UnregisterBuilding(BuildingObject building)
	{
		if (!(building == null))
		{
			spawnedBuildings.Remove(building);
			if (buildingDebugLogs)
			{
				Debug.Log($"[GameManager] Building unregistered: {building.UniqueBuildingId}, Total: {spawnedBuildings.Count}");
			}
		}
	}

	public IReadOnlyList<BuildingObject> GetAllBuildings()
	{
		return spawnedBuildings;
	}

	private void Start()
	{
		StartCoroutine(WaitAndSubscribeToSaveSystem());
	}

	private IEnumerator WaitAndSubscribeToSaveSystem()
	{
		while (!NetworkServer.active)
		{
			yield return null;
		}
		SaveLoadManager.Subscribe(this, 35);
		if (buildingDebugLogs)
		{
			Debug.Log("[GameManager] Building save sistemine kayıt olundu.");
		}
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!NetworkServer.active)
		{
			return null;
		}
		BuildingListSaveData buildingListSaveData = new BuildingListSaveData();
		foreach (BuildingObject spawnedBuilding in spawnedBuildings)
		{
			if (spawnedBuilding == null || !spawnedBuilding.IsPlaced)
			{
				continue;
			}
			T_SortingOutput component = spawnedBuilding.GetComponent<T_SortingOutput>();
			if (component != null && component.UseManualSaveId)
			{
				continue;
			}
			T_BuildingItemSO buildingItemSO = spawnedBuilding.buildingItemSO;
			if (!(buildingItemSO == null))
			{
				int buildingSOIndex = GetBuildingSOIndex(buildingItemSO);
				if (buildingSOIndex >= 0)
				{
					buildingListSaveData.buildings.Add(new BuildingSpawnData
					{
						uniqueId = spawnedBuilding.UniqueBuildingId,
						buildingItemSOIndex = buildingSOIndex,
						posX = spawnedBuilding.transform.position.x,
						posY = spawnedBuilding.transform.position.y,
						posZ = spawnedBuilding.transform.position.z,
						rotX = spawnedBuilding.transform.rotation.x,
						rotY = spawnedBuilding.transform.rotation.y,
						rotZ = spawnedBuilding.transform.rotation.z,
						rotW = spawnedBuilding.transform.rotation.w,
						wasOnSocket = (spawnedBuilding.TargetSocketNetId != 0)
					});
				}
			}
		}
		if (buildingDebugLogs)
		{
			Debug.Log($"[GameManager] Building Save - {buildingListSaveData.buildings.Count} building kaydedildi.");
		}
		return buildingListSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!NetworkServer.active)
		{
			return Task.CompletedTask;
		}
		if (!(value is BuildingListSaveData data))
		{
			Debug.LogWarning("[GameManager] OnLoad - Invalid data type");
			return Task.CompletedTask;
		}
		_isRestoringFromSave = true;
		SaveLoadGameManager.RegisterPendingLoadOperation("Loading_Buildings");
		StartCoroutine(Co_RestoreAll(data));
		return Task.CompletedTask;
	}

	private IEnumerator Co_RestoreAll(BuildingListSaveData data)
	{
		if (data.buildings != null && data.buildings.Count > 0)
		{
			if (buildingDebugLogs)
			{
				Debug.Log($"[GameManager] OnLoad - {data.buildings.Count} building restore ediliyor.");
			}
			yield return Co_RestoreBuildings(data);
		}
		_isRestoringFromSave = false;
		if (buildingDebugLogs)
		{
			Debug.Log("[GameManager] Tüm restore işlemleri tamamlandı.");
		}
		SaveLoadGameManager.CompletePendingLoadOperation("Loading_Buildings");
	}

	private IEnumerator Co_RestoreBuildings(BuildingListSaveData data)
	{
		while (ScriptableListManager.Instance == null)
		{
			yield return null;
		}
		List<BuildingObject> socketRebindList = new List<BuildingObject>();
		foreach (BuildingSpawnData spawnData in data.buildings)
		{
			if (string.IsNullOrEmpty(spawnData.uniqueId))
			{
				continue;
			}
			T_BuildingItemSO buildingSO = GetBuildingSOFromIndex(spawnData.buildingItemSOIndex);
			if (buildingSO == null)
			{
				Debug.LogWarning($"[GameManager] Restore - BuildingSO bulunamadı, index: {spawnData.buildingItemSOIndex}");
				continue;
			}
			if (buildingSO.Prefab == null)
			{
				Debug.LogWarning("[GameManager] Restore - Prefab null: " + buildingSO.Name);
				continue;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(position: new Vector3(spawnData.posX, spawnData.posY, spawnData.posZ), rotation: new Quaternion(spawnData.rotX, spawnData.rotY, spawnData.rotZ, spawnData.rotW), original: buildingSO.Prefab);
			BuildingObject buildingObj = gameObject.GetComponent<BuildingObject>();
			if (buildingObj != null)
			{
				buildingObj.SetUniqueBuildingId(spawnData.uniqueId);
				buildingObj.SetBuildingItemSOIndex(spawnData.buildingItemSOIndex);
				NetworkServer.Spawn(gameObject);
				yield return null;
				buildingObj.ServerSetPlacedFromLoad();
				if (spawnData.wasOnSocket || buildingObj.socketOnly || buildingObj.hybridMode)
				{
					socketRebindList.Add(buildingObj);
				}
				if (buildingDebugLogs)
				{
					Debug.Log($"[GameManager] Building restored: {spawnData.uniqueId}, SO: {buildingSO.Name}, WasOnSocket: {spawnData.wasOnSocket}");
				}
				yield return null;
			}
			else
			{
				Debug.LogWarning("[GameManager] Restore - BuildingObject component bulunamadı: " + buildingSO.Name);
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		foreach (BuildingObject item in socketRebindList)
		{
			if (!(item == null))
			{
				item.ServerRebindSocketFromLoad();
			}
		}
		yield return null;
		yield return null;
		if (buildingDebugLogs)
		{
			Debug.Log($"[GameManager] Building restore tamamlandı - {data.buildings.Count} building.");
		}
	}

	private int GetBuildingSOIndex(T_BuildingItemSO buildingSO)
	{
		if (buildingSO == null)
		{
			return -1;
		}
		if (ScriptableListManager.Instance == null)
		{
			return -1;
		}
		IReadOnlyList<T_BuildingItemSO> allBuildingItemSOs = ScriptableListManager.Instance.AllBuildingItemSOs;
		for (int i = 0; i < allBuildingItemSOs.Count; i++)
		{
			if (allBuildingItemSOs[i] == buildingSO)
			{
				return i;
			}
		}
		return -1;
	}

	private T_BuildingItemSO GetBuildingSOFromIndex(int index)
	{
		if (ScriptableListManager.Instance == null)
		{
			return null;
		}
		IReadOnlyList<T_BuildingItemSO> allBuildingItemSOs = ScriptableListManager.Instance.AllBuildingItemSOs;
		if (index < 0 || index >= allBuildingItemSOs.Count)
		{
			return null;
		}
		return allBuildingItemSOs[index];
	}
}
