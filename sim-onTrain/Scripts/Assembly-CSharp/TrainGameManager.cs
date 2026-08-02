using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using GPUInstancerPro;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.AzureSky;
using UnityEngine.Events;

[DefaultExecutionOrder(-200)]
public class TrainGameManager : NetworkBehaviour
{
	public static TrainGameManager instance;

	[SyncVar]
	public int seed;

	public GameObject mainPlayer;

	public InventoryManagerUI playerInventoryManagerUI;

	public EastUpPlayerItemManager itemChooser;

	[Header("Game Mode")]
	public GameMode currentGameMode;

	[Header("World Generation Prefabs")]
	public List<PrefabDestinationDatas> treePrefabs = new List<PrefabDestinationDatas>();

	public List<PrefabDestinationDatas> miningPrefabs = new List<PrefabDestinationDatas>();

	public List<PrefabDestinationDatas> sticksAndStones = new List<PrefabDestinationDatas>();

	public TrainController trainController;

	public List<GameObject> terrainPrefabs = new List<GameObject>();

	public List<int> terrainGenerationSort = new List<int>();

	public List<TerrainSaveData> activeTerrains = new List<TerrainSaveData>();

	private ChatUI chatUI;

	private static bool _isInputActive;

	private static bool _isMouseLocked;

	private static readonly HashSet<string> inputLocks;

	private static readonly HashSet<string> mouseLocks;

	public static bool isSkippingToMorning;

	public UnityEvent OnGameLoaded = new UnityEvent();

	public int lastActiveTerrainIndex;

	public int trainArrivedIndex;

	private int lastGeneratedTerrainIndex;

	[Header("Time Settings")]
	[Tooltip("Bir gün kaç saniyede geçeceği çarpanı (1 gün = 24 * azureTimeMultiplier saniye)\nÖrnek: 20 = 480 saniye (8 dakika), 10 = 240 saniye (4 dakika)")]
	public float azureTimeMultiplier = 20f;

	[SyncVar(hook = "OnCurrentTimeChanged")]
	[Range(0f, 24f)]
	public float currentTime = 12f;

	public float nightStartHour;

	public float nightEndHour;

	[SyncVar(hook = "OnCurrentDayChanged")]
	public int currentDay = 1;

	[Header("Real Time Played")]
	public float totalPlayedSeconds;

	private AzureTimeController azure;

	public static TrainGameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = UnityEngine.Object.FindObjectOfType<TrainGameManager>();
			}
			return instance;
		}
	}

	public ChatUI ChatPanel
	{
		get
		{
			if (!(chatUI == null))
			{
				return chatUI;
			}
			return UnityEngine.Object.FindObjectOfType<ChatUI>();
		}
	}

	public static bool isInputActive
	{
		get
		{
			if (_isInputActive)
			{
				return inputLocks.Count == 0;
			}
			return false;
		}
		set
		{
			_isInputActive = value;
		}
	}

	public static bool isMouseLocked
	{
		get
		{
			if (!_isMouseLocked)
			{
				return mouseLocks.Count > 0;
			}
			return true;
		}
		set
		{
			_isMouseLocked = value;
		}
	}

	public int Networkseed
	{
		get
		{
			return seed;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref seed, 1uL, null);
		}
	}

	public float NetworkcurrentTime
	{
		get
		{
			return currentTime;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentTime, 2uL, OnCurrentTimeChanged);
		}
	}

	public int NetworkcurrentDay
	{
		get
		{
			return currentDay;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentDay, 4uL, OnCurrentDayChanged);
		}
	}

	public static void RequestInputLock(string owner)
	{
		inputLocks.Add(owner);
	}

	public static void ReleaseInputLock(string owner)
	{
		inputLocks.Remove(owner);
	}

	public static void RequestMouseLock(string owner)
	{
		mouseLocks.Add(owner);
	}

	public static void ReleaseMouseLock(string owner)
	{
		mouseLocks.Remove(owner);
	}

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		if (GPUIRenderingSystem.Instance != null)
		{
			GPUIRenderingSystem.Instance.Dispose();
		}
		if (trainController == null)
		{
			trainController = UnityEngine.Object.FindObjectOfType<TrainController>();
		}
		if (azure == null)
		{
			azure = UnityEngine.Object.FindObjectOfType<AzureTimeController>();
		}
	}

	private void OnEnable()
	{
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.AddListener(delegate
		{
			isMouseLocked = true;
		});
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.AddListener(delegate
		{
			isMouseLocked = false;
		});
	}

	private void OnDisable()
	{
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.RemoveListener(delegate
		{
			isMouseLocked = true;
		});
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.RemoveListener(delegate
		{
			isMouseLocked = false;
		});
	}

	private void Start()
	{
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveGameData);
		Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadData);
		LoadData();
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!base.isServer)
		{
			StartCoroutine(WaitForSeed());
		}
	}

	private IEnumerator WaitForSeed()
	{
		while (seed == 0)
		{
			Debug.Log("Seed Didnt Initialize. Retrying...");
			yield return new WaitForSeconds(0.1f);
		}
		Debug.Log("Started Seed: " + seed);
		GenerateMap();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.O))
		{
			Cursor.lockState = CursorLockMode.Confined;
		}
		if (base.isServer)
		{
			UpdateTime();
			totalPlayedSeconds += Time.deltaTime;
		}
	}

	[Server]
	private void UpdateTime()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainGameManager::UpdateTime()' called when server was not active");
			return;
		}
		float num = Time.deltaTime / azureTimeMultiplier;
		float num2 = currentTime + num;
		if (num2 >= 24f)
		{
			num2 = 0f;
			NetworkcurrentDay = currentDay + 1;
		}
		NetworkcurrentTime = num2;
	}

	private void OnCurrentTimeChanged(float oldTime, float newTime)
	{
		SetAzureTime(newTime);
	}

	private void OnCurrentDayChanged(int oldDay, int newDay)
	{
		Debug.Log($"Day changed from {oldDay} to {newDay}");
	}

	private void SetAzureTime(float time)
	{
		if (azure != null)
		{
			azure.SetTimeline(time);
		}
	}

	public void LoadData()
	{
		try
		{
			Networkseed = Singleton<ES3SaveManager>.Instance.LoadData("seed", 0);
			lastActiveTerrainIndex = Singleton<ES3SaveManager>.Instance.LoadData("lastActiveTerrainIndex", 0);
			trainArrivedIndex = Singleton<ES3SaveManager>.Instance.LoadData("trainArrivedIndex", 0);
			lastGeneratedTerrainIndex = Singleton<ES3SaveManager>.Instance.LoadData("lastGeneratedTerrainIndex", 0);
			NetworkcurrentDay = Singleton<ES3SaveManager>.Instance.LoadData("currentDay", 1);
			totalPlayedSeconds = Singleton<ES3SaveManager>.Instance.LoadData("totalPlayedSeconds", 0f);
			if (seed == 0)
			{
				Networkseed = UnityEngine.Random.Range(1, 1000000);
			}
			if (Singleton<ES3SaveManager>.Instance.KeyExists("currentTime"))
			{
				NetworkcurrentTime = Singleton<ES3SaveManager>.Instance.LoadData("currentTime", 7f);
				SetAzureTime(currentTime);
			}
		}
		catch (Exception)
		{
			Networkseed = UnityEngine.Random.Range(1, 1000000);
			NetworkcurrentTime = 12f;
			NetworkcurrentDay = 1;
			totalPlayedSeconds = 0f;
			lastActiveTerrainIndex = 0;
			trainArrivedIndex = 0;
			lastGeneratedTerrainIndex = 0;
		}
		OnGameLoaded.Invoke();
		GenerateMap();
	}

	public void SaveGameData()
	{
		Singleton<ES3SaveManager>.Instance.SaveData("seed", seed);
		Singleton<ES3SaveManager>.Instance.SaveData("currentTime", currentTime);
		Singleton<ES3SaveManager>.Instance.SaveData("currentDay", currentDay);
		Singleton<ES3SaveManager>.Instance.SaveData("totalPlayedSeconds", totalPlayedSeconds);
		Singleton<ES3SaveManager>.Instance.SaveData("lastActiveTerrainIndex", lastActiveTerrainIndex);
		Singleton<ES3SaveManager>.Instance.SaveData("trainArrivedIndex", trainArrivedIndex);
		Singleton<ES3SaveManager>.Instance.SaveData("lastGeneratedTerrainIndex", lastGeneratedTerrainIndex);
		Debug.Log($"Game data saved - Seed: {seed}, Time: {currentTime}, Day: {currentDay}, Played: {totalPlayedSeconds:F0}s, LastActiveTerrain: {lastActiveTerrainIndex}");
	}

	public void GenerateMap()
	{
		StartCoroutine(GenerateMapRoutine());
	}

	private IEnumerator GenerateMapRoutine()
	{
		terrainGenerationSort.Add(0);
		UnityEngine.Random.InitState(seed);
		for (int i = 0; i < 150; i++)
		{
			terrainGenerationSort.Add(UnityEngine.Random.Range(0, terrainPrefabs.Count));
		}
		yield return null;
		if (lastActiveTerrainIndex == 0)
		{
			LoadNewTerrain();
			yield break;
		}
		switch (trainArrivedIndex)
		{
		case 0:
			SetTerrainChunkID(UnityEngine.Object.Instantiate(terrainPrefabs[lastActiveTerrainIndex - 1], Vector3.zero, Quaternion.identity), lastActiveTerrainIndex - 1);
			yield return null;
			SetTerrainChunkID(UnityEngine.Object.Instantiate(terrainPrefabs[lastActiveTerrainIndex], Vector3.zero, Quaternion.identity), lastActiveTerrainIndex);
			break;
		case 1:
			SetTerrainChunkID(UnityEngine.Object.Instantiate(terrainPrefabs[lastActiveTerrainIndex], Vector3.zero, Quaternion.identity), lastActiveTerrainIndex);
			break;
		case 2:
			SetTerrainChunkID(UnityEngine.Object.Instantiate(terrainPrefabs[lastActiveTerrainIndex], Vector3.zero, Quaternion.identity), lastActiveTerrainIndex);
			yield return null;
			SetTerrainChunkID(UnityEngine.Object.Instantiate(terrainPrefabs[lastActiveTerrainIndex + 1], Vector3.zero, Quaternion.identity), lastActiveTerrainIndex + 1);
			lastGeneratedTerrainIndex = lastActiveTerrainIndex + 1;
			break;
		}
	}

	public void LoadNewTerrain()
	{
		if (lastGeneratedTerrainIndex == lastActiveTerrainIndex + 1)
		{
			lastActiveTerrainIndex++;
			return;
		}
		lastGeneratedTerrainIndex = lastActiveTerrainIndex;
		GameObject terrainInstance = UnityEngine.Object.Instantiate(terrainPrefabs[lastActiveTerrainIndex], Vector3.zero, Quaternion.identity);
		SetTerrainChunkID(terrainInstance, lastActiveTerrainIndex);
	}

	private void SetTerrainChunkID(GameObject terrainInstance, int chunkID)
	{
		ChunkDataHolder componentInChildren = terrainInstance.GetComponentInChildren<ChunkDataHolder>();
		if (componentInChildren != null)
		{
			componentInChildren.chunkID = chunkID;
		}
	}

	public void CheckAllPlayersSleeping()
	{
		if (base.isServer)
		{
			StartCoroutine(CheckSleepingCoroutine());
		}
	}

	private IEnumerator CheckSleepingCoroutine()
	{
		yield return new WaitForSeconds(0.5f);
		TSPlayerController[] array = UnityEngine.Object.FindObjectsOfType<TSPlayerController>();
		bool flag = true;
		if (array.Length == 0)
		{
			flag = false;
		}
		else
		{
			TSPlayerController[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!array2[i].isSleeping)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			SkipToMorning();
		}
	}

	[Server]
	private void SkipToMorning()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainGameManager::SkipToMorning()' called when server was not active");
			return;
		}
		RpcSetSkippingToMorning(value: true);
		RpcSleepFadeOut();
		StartCoroutine(SkipToMorningCoroutine());
	}

	private IEnumerator SkipToMorningCoroutine()
	{
		yield return new WaitForSeconds(1.5f);
		float sleepEndHour = Singleton<GameSettings>.Instance.sleepEndHour;
		DOTween.To(() => currentTime, delegate(float x)
		{
			NetworkcurrentTime = x;
		}, sleepEndHour, 3f).SetTarget(this).SetEase(Ease.InOutQuad)
			.OnComplete(delegate
			{
				WakeAllPlayers();
				RpcSleepFadeIn();
				RpcSetSkippingToMorning(value: false);
			});
	}

	[Server]
	private void WakeAllPlayers()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void TrainGameManager::WakeAllPlayers()' called when server was not active");
			return;
		}
		TSPlayerController[] array = UnityEngine.Object.FindObjectsOfType<TSPlayerController>();
		foreach (TSPlayerController tSPlayerController in array)
		{
			if (tSPlayerController.isSleeping)
			{
				RpcWakePlayer(tSPlayerController.gameObject);
			}
		}
	}

	[ClientRpc]
	private void RpcSleepFadeOut()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TrainGameManager::RpcSleepFadeOut()", 314174634, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSleepFadeIn()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TrainGameManager::RpcSleepFadeIn()", -1375526485, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSetSkippingToMorning(bool value)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(value);
		SendRPCInternal("System.Void TrainGameManager::RpcSetSkippingToMorning(System.Boolean)", 858200156, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcWakePlayer(GameObject playerObj)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(playerObj);
		SendRPCInternal("System.Void TrainGameManager::RpcWakePlayer(UnityEngine.GameObject)", 2141447020, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	static TrainGameManager()
	{
		_isInputActive = true;
		_isMouseLocked = false;
		inputLocks = new HashSet<string>();
		mouseLocks = new HashSet<string>();
		isSkippingToMorning = false;
		RemoteProcedureCalls.RegisterRpc(typeof(TrainGameManager), "System.Void TrainGameManager::RpcSleepFadeOut()", InvokeUserCode_RpcSleepFadeOut);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainGameManager), "System.Void TrainGameManager::RpcSleepFadeIn()", InvokeUserCode_RpcSleepFadeIn);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainGameManager), "System.Void TrainGameManager::RpcSetSkippingToMorning(System.Boolean)", InvokeUserCode_RpcSetSkippingToMorning__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(TrainGameManager), "System.Void TrainGameManager::RpcWakePlayer(UnityEngine.GameObject)", InvokeUserCode_RpcWakePlayer__GameObject);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcSleepFadeOut()
	{
		ScreenFader.Instance.FadeOut(1.5f);
	}

	protected static void InvokeUserCode_RpcSleepFadeOut(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSleepFadeOut called on server.");
		}
		else
		{
			((TrainGameManager)obj).UserCode_RpcSleepFadeOut();
		}
	}

	protected void UserCode_RpcSleepFadeIn()
	{
		ScreenFader.Instance.FadeIn(1.5f);
	}

	protected static void InvokeUserCode_RpcSleepFadeIn(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSleepFadeIn called on server.");
		}
		else
		{
			((TrainGameManager)obj).UserCode_RpcSleepFadeIn();
		}
	}

	protected void UserCode_RpcSetSkippingToMorning__Boolean(bool value)
	{
		isSkippingToMorning = value;
	}

	protected static void InvokeUserCode_RpcSetSkippingToMorning__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetSkippingToMorning called on server.");
		}
		else
		{
			((TrainGameManager)obj).UserCode_RpcSetSkippingToMorning__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RpcWakePlayer__GameObject(GameObject playerObj)
	{
		TSPlayerController component = playerObj.GetComponent<TSPlayerController>();
		if (component != null && component.isSleeping)
		{
			component.WakeUp();
		}
	}

	protected static void InvokeUserCode_RpcWakePlayer__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcWakePlayer called on server.");
		}
		else
		{
			((TrainGameManager)obj).UserCode_RpcWakePlayer__GameObject(reader.ReadGameObject());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(seed);
			writer.WriteFloat(currentTime);
			writer.WriteInt(currentDay);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteInt(seed);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteFloat(currentTime);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteInt(currentDay);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref seed, null, reader.ReadInt());
			GeneratedSyncVarDeserialize(ref currentTime, OnCurrentTimeChanged, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref currentDay, OnCurrentDayChanged, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref seed, null, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentTime, OnCurrentTimeChanged, reader.ReadFloat());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentDay, OnCurrentDayChanged, reader.ReadInt());
		}
	}
}
