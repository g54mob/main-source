using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class PropertyLoader : NetworkBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private string propertySceneName = "PropertyScene";

	[SerializeField]
	private float loadingDelayBeforeScene = 1f;

	[SerializeField]
	private float unloadingDelayBeforeScene = 1f;

	[Header("Spawn Point")]
	[Tooltip("Digsite'dan dönen oyuncuların spawn edileceği başlangıç noktası")]
	[SerializeField]
	private Transform factorySpawnPoint;

	private Vector3 cachedSpawnPosition;

	private Quaternion cachedSpawnRotation;

	[Header("References")]
	[SerializeField]
	private NetworkSceneLoader sceneLoader;

	[Header("Events")]
	[Tooltip("Property sahnesi yüklenmeye başladığında")]
	public UnityEvent onPropertyLoadStarted;

	[Tooltip("Tüm oyuncularda property sahnesi hazır olduğunda")]
	public UnityEvent onPropertyReady;

	[Tooltip("Property sahnesi unload edildiğinde")]
	public UnityEvent onPropertyUnloaded;

	[SyncVar(hook = "OnPropertyLoadedChanged")]
	private bool _isPropertyLoaded;

	private bool _hasReceivedPropertyReady;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate__isPropertyLoaded;

	public static PropertyLoader Instance { get; private set; }

	public bool IsPropertyLoaded => _isPropertyLoaded;

	public string CurrentPropertyScene => propertySceneName;

	public bool Network_isPropertyLoaded
	{
		get
		{
			return _isPropertyLoaded;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _isPropertyLoaded, 1uL, _Mirror_SyncVarHookDelegate__isPropertyLoaded);
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		CacheSpawnPoint();
	}

	private void CacheSpawnPoint()
	{
		if (factorySpawnPoint != null)
		{
			cachedSpawnPosition = factorySpawnPoint.position;
			cachedSpawnRotation = factorySpawnPoint.rotation;
		}
		else
		{
			cachedSpawnPosition = base.transform.position;
			cachedSpawnRotation = base.transform.rotation;
			Debug.LogWarning("[PropertyLoader] factorySpawnPoint atanmamış, fallback pozisyon kullanılıyor.");
		}
	}

	private void Start()
	{
		if (sceneLoader == null)
		{
			sceneLoader = NetworkSceneLoader.Instance;
		}
		if (sceneLoader != null)
		{
			sceneLoader.onSceneLoadStarted.AddListener(OnSceneLoadStarted);
			sceneLoader.onAllPlayersReady.AddListener(OnAllPlayersReady);
			sceneLoader.onSceneUnloaded.AddListener(OnSceneUnloaded);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		if (sceneLoader != null)
		{
			sceneLoader.onSceneLoadStarted.RemoveListener(OnSceneLoadStarted);
			sceneLoader.onAllPlayersReady.RemoveListener(OnAllPlayersReady);
			sceneLoader.onSceneUnloaded.RemoveListener(OnSceneUnloaded);
		}
	}

	public void LoadProperty()
	{
		if (sceneLoader == null)
		{
			Debug.LogError("[PropertyLoader] NetworkSceneLoader bulunamadı!");
		}
		else if (!NetworkClient.isConnected)
		{
			Debug.LogError("[PropertyLoader] Network'e bağlı değilsiniz!");
		}
		else if (_isPropertyLoaded)
		{
			Debug.LogWarning("[PropertyLoader] Property zaten yüklü!");
		}
		else
		{
			StartCoroutine(LoadPropertyWithDelay(propertySceneName));
		}
	}

	public void LoadProperty(string sceneName)
	{
		if (sceneLoader == null)
		{
			Debug.LogError("[PropertyLoader] NetworkSceneLoader bulunamadı!");
			return;
		}
		if (!NetworkClient.isConnected)
		{
			Debug.LogError("[PropertyLoader] Network'e bağlı değilsiniz!");
			return;
		}
		propertySceneName = sceneName;
		StartCoroutine(LoadPropertyWithDelay(sceneName));
	}

	private IEnumerator LoadPropertyWithDelay(string sceneName)
	{
		if (base.isServer && NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerShowLoading(LoadingType.Property);
		}
		yield return new WaitForSeconds(loadingDelayBeforeScene);
		sceneLoader.LoadSceneForAll(sceneName);
	}

	public void UnloadProperty()
	{
		if (sceneLoader == null)
		{
			Debug.LogError("[PropertyLoader] NetworkSceneLoader bulunamadı!");
		}
		else if (!_isPropertyLoaded)
		{
			Debug.LogWarning("[PropertyLoader] Unload edilecek property yok!");
		}
		else
		{
			StartCoroutine(UnloadPropertyWithDelay(propertySceneName));
		}
	}

	private IEnumerator UnloadPropertyWithDelay(string sceneName)
	{
		if (base.isServer && NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerShowLoading(LoadingType.Scene);
		}
		yield return new WaitForSeconds(unloadingDelayBeforeScene / 2f);
		if (base.isServer)
		{
			TeleportDigsitePlayersToFactory();
		}
		yield return new WaitForSeconds(unloadingDelayBeforeScene);
		sceneLoader.UnloadScene(sceneName);
	}

	[Server]
	private void TeleportDigsitePlayersToFactory()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PropertyLoader::TeleportDigsitePlayersToFactory()' called when server was not active");
		}
		else
		{
			if (!(NetworkManager.singleton is NewNetworkManager { GamePlayers: { Count: not 0 } gamePlayers }))
			{
				return;
			}
			foreach (GamePlayer item in gamePlayers)
			{
				if (!(item == null) && item.isInDigsite)
				{
					RpcTeleportPlayer(item.netIdentity, cachedSpawnPosition, cachedSpawnRotation);
					item.NetworkisInDigsite = false;
					Debug.Log("[PropertyLoader] " + item.playerName + " factory'ye teleport edildi.");
				}
			}
			if (PlayerProgressManager.Instance != null)
			{
				PlayerProgressManager.Instance.Server_ResetAllDigsiteStatuses();
			}
			DestroyAbandonedDigsiteSacks();
		}
	}

	[Server]
	private void DestroyAbandonedDigsiteSacks()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PropertyLoader::DestroyAbandonedDigsiteSacks()' called when server was not active");
		}
		else
		{
			if (DynamicObjectSpawner.Instance == null)
			{
				return;
			}
			IReadOnlyCollection<T_Sack> allRegisteredSacks = DynamicObjectSpawner.Instance.GetAllRegisteredSacks();
			List<T_Sack> list = new List<T_Sack>();
			foreach (T_Sack item in allRegisteredSacks)
			{
				if (!(item == null) && item.transform.position.z > 500f && !item.IsBeingCarried)
				{
					list.Add(item);
				}
			}
			foreach (T_Sack item2 in list)
			{
				Debug.Log($"[PropertyLoader] Z>500 sahipsiz sack siliniyor: {item2.UniqueId} (pos: {item2.transform.position})");
				NetworkServer.Destroy(item2.gameObject);
			}
		}
	}

	[ClientRpc]
	private void RpcTeleportPlayer(NetworkIdentity playerIdentity, Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkIdentity(playerIdentity);
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendRPCInternal("System.Void PropertyLoader::RpcTeleportPlayer(Mirror.NetworkIdentity,UnityEngine.Vector3,UnityEngine.Quaternion)", -2120385761, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnPropertyLoadedChanged(bool oldValue, bool newValue)
	{
		if (!base.isServer && !(_hasReceivedPropertyReady && newValue))
		{
			if (newValue && !oldValue)
			{
				Debug.Log("[PropertyLoader] Sonradan giren oyuncu: Property zaten yüklü, onPropertyReady tetikleniyor.");
				_hasReceivedPropertyReady = true;
				onPropertyReady?.Invoke();
				StartCoroutine(ClientCheckAndTeleportToDigsite());
			}
			else if (!newValue && oldValue)
			{
				_hasReceivedPropertyReady = false;
				onPropertyUnloaded?.Invoke();
			}
		}
	}

	private void OnSceneLoadStarted(string sceneName)
	{
		if (sceneName == propertySceneName)
		{
			Debug.Log("[PropertyLoader] Property yüklenmeye başladı: " + sceneName);
			onPropertyLoadStarted?.Invoke();
		}
	}

	private void OnAllPlayersReady(string sceneName)
	{
		if (sceneName == propertySceneName)
		{
			Debug.Log("[PropertyLoader] Tüm oyuncular hazır! Property: " + sceneName);
			Network_isPropertyLoaded = true;
			_hasReceivedPropertyReady = true;
			SaveLoadGameManager.CompletePendingLoadOperation("Loading_Property");
			if (base.isServer && NetworkLoadingSync.Instance != null)
			{
				NetworkLoadingSync.Instance.ServerHideLoading(LoadingType.Property);
			}
			onPropertyReady?.Invoke();
			if (base.isServer)
			{
				StartCoroutine(ServerHostRestoreDigsite());
				StartCoroutine(ServerSpawnRule());
			}
		}
	}

	private IEnumerator ClientCheckAndTeleportToDigsite()
	{
		yield return new WaitForSeconds(0.5f);
		if (NetworkClient.localPlayer == null)
		{
			yield break;
		}
		GamePlayer localGamePlayer = NetworkClient.localPlayer.GetComponent<GamePlayer>();
		if (localGamePlayer == null)
		{
			yield break;
		}
		if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning)
		{
			if (!(NetworkManager.singleton is NewNetworkManager { GamePlayers: { } gamePlayers }))
			{
				yield break;
			}
			{
				foreach (GamePlayer item in gamePlayers)
				{
					if (!(item == null) && item.ownerConnectionId == 0 && item.isInDigsite)
					{
						StartCoroutine(SetDigsiteActions(localGamePlayer));
						break;
					}
				}
				yield break;
			}
		}
		CmdRestoreMyDigsiteStatus(NetworkClient.localPlayer.connectionToClient);
		yield return new WaitForSeconds(0.5f);
		if (localGamePlayer.isInDigsite)
		{
			StartCoroutine(SetDigsiteActions(localGamePlayer));
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRestoreMyDigsiteStatus(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRestoreMyDigsiteStatus__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PropertyLoader::CmdRestoreMyDigsiteStatus(Mirror.NetworkConnectionToClient)", -1556384677, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator ServerHostRestoreDigsite()
	{
		yield return new WaitForSeconds(0.3f);
		if (!(NetworkClient.localPlayer == null))
		{
			GamePlayer component = NetworkClient.localPlayer.GetComponent<GamePlayer>();
			if (!(component == null) && !(PlayerProgressManager.Instance == null) && PlayerProgressManager.Instance.Server_GetPlayerInDigsite(component.playerSteamId))
			{
				component.NetworkisInDigsite = true;
				StartCoroutine(SetDigsiteActions(component));
			}
		}
	}

	public IEnumerator SetDigsiteActions(GamePlayer localGamePlayer)
	{
		if (!(GameManager.Instance == null) && !(GameManager.Instance.digsiteMarker == null))
		{
			Transform digsiteMarker = GameManager.Instance.digsiteMarker;
			CharacterController component = NetworkClient.localPlayer.GetComponent<CharacterController>();
			if (component != null)
			{
				component.enabled = false;
			}
			NetworkClient.localPlayer.transform.SetPositionAndRotation(digsiteMarker.position, digsiteMarker.rotation);
			if (component != null)
			{
				component.enabled = true;
			}
			localGamePlayer.SetIsInDigsite(value: true);
		}
		yield break;
	}

	public IEnumerator ServerSpawnRule()
	{
		yield return new WaitForSeconds(0.25f);
		if (NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerShowLoading(LoadingType.Ore);
		}
		T_ItemAreaSpawner.instance.ServerSpawnFromRules();
		yield return new WaitForSeconds(1f);
		if (NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerHideLoading(LoadingType.Ore);
		}
	}

	private void OnSceneUnloaded(string sceneName)
	{
		if (sceneName == propertySceneName)
		{
			Debug.Log("[PropertyLoader] Property unload edildi: " + sceneName);
			Network_isPropertyLoaded = false;
			_hasReceivedPropertyReady = false;
			if (base.isServer && NetworkLoadingSync.Instance != null)
			{
				NetworkLoadingSync.Instance.ServerHideLoading(LoadingType.Scene);
			}
			onPropertyUnloaded?.Invoke();
		}
	}

	[ContextMenu("Load Property")]
	private void TestLoadProperty()
	{
		LoadProperty();
	}

	[ContextMenu("Unload Property")]
	private void TestUnloadProperty()
	{
		UnloadProperty();
	}

	public PropertyLoader()
	{
		_Mirror_SyncVarHookDelegate__isPropertyLoaded = OnPropertyLoadedChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcTeleportPlayer__NetworkIdentity__Vector3__Quaternion(NetworkIdentity playerIdentity, Vector3 position, Quaternion rotation)
	{
		if (!(playerIdentity == null))
		{
			CharacterController component = playerIdentity.GetComponent<CharacterController>();
			if (component != null)
			{
				component.enabled = false;
			}
			playerIdentity.transform.SetPositionAndRotation(position, rotation);
			NetworkTransformReliable component2 = playerIdentity.GetComponent<NetworkTransformReliable>();
			if (component2 != null)
			{
				component2.Reset();
			}
			if (component != null)
			{
				component.enabled = true;
			}
		}
	}

	protected static void InvokeUserCode_RpcTeleportPlayer__NetworkIdentity__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcTeleportPlayer called on server.");
		}
		else
		{
			((PropertyLoader)obj).UserCode_RpcTeleportPlayer__NetworkIdentity__Vector3__Quaternion(reader.ReadNetworkIdentity(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	protected void UserCode_CmdRestoreMyDigsiteStatus__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && !(sender.identity == null) && !(PlayerProgressManager.Instance == null))
		{
			GamePlayer component = sender.identity.GetComponent<GamePlayer>();
			if (!(component == null) && PlayerProgressManager.Instance.Server_GetPlayerInDigsite(component.playerSteamId) && !component.isInDigsite)
			{
				component.NetworkisInDigsite = true;
				Debug.Log("[PropertyLoader] " + component.playerName + " isInDigsite restore -> true (CmdRestoreMyDigsiteStatus)");
			}
		}
	}

	protected static void InvokeUserCode_CmdRestoreMyDigsiteStatus__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRestoreMyDigsiteStatus called on client.");
		}
		else
		{
			((PropertyLoader)obj).UserCode_CmdRestoreMyDigsiteStatus__NetworkConnectionToClient(senderConnection);
		}
	}

	static PropertyLoader()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PropertyLoader), "System.Void PropertyLoader::CmdRestoreMyDigsiteStatus(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRestoreMyDigsiteStatus__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PropertyLoader), "System.Void PropertyLoader::RpcTeleportPlayer(Mirror.NetworkIdentity,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcTeleportPlayer__NetworkIdentity__Vector3__Quaternion);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(_isPropertyLoaded);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(_isPropertyLoaded);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _isPropertyLoaded, _Mirror_SyncVarHookDelegate__isPropertyLoaded, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _isPropertyLoaded, _Mirror_SyncVarHookDelegate__isPropertyLoaded, reader.ReadBool());
		}
	}
}
