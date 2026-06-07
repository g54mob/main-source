using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NetworkSceneLoader : NetworkBehaviour
{
	[Header("Events")]
	[Tooltip("Sahne yüklenmeye başladığında tetiklenir (local)")]
	public UnityEvent<string> onSceneLoadStarted;

	[Tooltip("Sahne local olarak yüklendi (henüz herkes hazır değil)")]
	public UnityEvent<string> onSceneLoadedLocally;

	[Tooltip("Tüm oyuncularda sahne yüklendi - asıl iş mantığı burada başlar")]
	public UnityEvent<string> onAllPlayersReady;

	[Tooltip("Sahne unload edildiğinde tetiklenir")]
	public UnityEvent<string> onSceneUnloaded;

	[Header("Debug")]
	[SerializeField]
	private bool enableDebugLogging;

	private readonly HashSet<int> _readyClients = new HashSet<int>();

	private string _currentLoadingScene = "";

	private Scene _loadedScene;

	private int _expectedClientCount;

	private bool _hasLoadedSceneLocally;

	private int _lastLoggedProgress = -1;

	public static NetworkSceneLoader Instance { get; private set; }

	public string CurrentLoadingScene => _currentLoadingScene;

	public bool IsLoading
	{
		get
		{
			if (!string.IsNullOrEmpty(_currentLoadingScene))
			{
				return _readyClients.Count < _expectedClientCount;
			}
			return false;
		}
	}

	public Scene? LoadedScene
	{
		get
		{
			if (!_loadedScene.IsValid() || !_loadedScene.isLoaded)
			{
				return null;
			}
			return _loadedScene;
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void OnCurrentLoadingSceneChanged(string oldScene, string newScene)
	{
		if (!base.isServer)
		{
			if (!string.IsNullOrEmpty(newScene) && !_hasLoadedSceneLocally)
			{
				StartCoroutine(LoadSceneAsync(newScene));
			}
			else if (string.IsNullOrEmpty(newScene) && !string.IsNullOrEmpty(oldScene))
			{
				_hasLoadedSceneLocally = false;
			}
		}
	}

	public void LoadSceneForAll(string sceneName)
	{
		if (string.IsNullOrEmpty(sceneName))
		{
			Debug.LogError("[NetworkSceneLoader] Sahne adı boş olamaz!");
			return;
		}
		DebugLog($"LoadSceneForAll requested for '{sceneName}' (isServer={base.isServer})");
		if (base.isServer)
		{
			ServerStartSceneLoad(sceneName);
		}
		else
		{
			CmdRequestSceneLoad(sceneName);
		}
	}

	public void UnloadCurrentScene()
	{
		if (!string.IsNullOrEmpty(_currentLoadingScene))
		{
			DebugLog($"UnloadCurrentScene requested for '{_currentLoadingScene}' (isServer={base.isServer})");
			if (base.isServer)
			{
				ServerUnloadScene();
			}
			else
			{
				CmdRequestSceneUnload();
			}
		}
	}

	public void UnloadScene(string sceneName)
	{
		if (string.IsNullOrEmpty(sceneName))
		{
			Debug.LogError("[NetworkSceneLoader] Sahne adı boş olamaz!");
			return;
		}
		DebugLog($"UnloadScene requested for '{sceneName}' (isServer={base.isServer})");
		if (base.isServer)
		{
			ServerUnloadSpecificScene(sceneName);
		}
		else
		{
			CmdRequestSpecificSceneUnload(sceneName);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSceneLoad(string sceneName, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSceneLoad__String__NetworkConnectionToClient(sceneName, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(sceneName);
		SendCommandInternal("System.Void NetworkSceneLoader::CmdRequestSceneLoad(System.String,Mirror.NetworkConnectionToClient)", 1647445944, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSceneUnload(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSceneUnload__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkSceneLoader::CmdRequestSceneUnload(Mirror.NetworkConnectionToClient)", -757590701, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSpecificSceneUnload(string sceneName, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSpecificSceneUnload__String__NetworkConnectionToClient(sceneName, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(sceneName);
		SendCommandInternal("System.Void NetworkSceneLoader::CmdRequestSpecificSceneUnload(System.String,Mirror.NetworkConnectionToClient)", -1854692185, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerStartSceneLoad(string sceneName)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneLoader::ServerStartSceneLoad(System.String)' called when server was not active");
		}
		else if (!string.IsNullOrEmpty(_currentLoadingScene))
		{
			DebugLog("ServerStartSceneLoad ignored: already loading '" + _currentLoadingScene + "', requested '" + sceneName + "'");
		}
		else
		{
			DebugLog($"Server starting scene load for '{sceneName}', expected clients: {NetworkServer.connections.Count}");
			_readyClients.Clear();
			_expectedClientCount = NetworkServer.connections.Count;
			_currentLoadingScene = sceneName;
			RpcLoadScene(sceneName);
			StartCoroutine(LoadSceneAsync(sceneName));
		}
	}

	[Server]
	private void ServerUnloadScene()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneLoader::ServerUnloadScene()' called when server was not active");
		}
		else if (!string.IsNullOrEmpty(_currentLoadingScene))
		{
			DebugLog("Server unloading current scene '" + _currentLoadingScene + "'");
			string currentLoadingScene = _currentLoadingScene;
			_currentLoadingScene = "";
			_readyClients.Clear();
			RpcUnloadScene(currentLoadingScene);
			StartCoroutine(UnloadSceneAsync(currentLoadingScene));
		}
	}

	[Server]
	private void ServerUnloadSpecificScene(string sceneName)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneLoader::ServerUnloadSpecificScene(System.String)' called when server was not active");
			return;
		}
		DebugLog("Server unloading specific scene '" + sceneName + "'");
		if (_currentLoadingScene == sceneName)
		{
			_currentLoadingScene = "";
		}
		_readyClients.Clear();
		RpcUnloadScene(sceneName);
		StartCoroutine(UnloadSceneAsync(sceneName));
	}

	[Command(requiresAuthority = false)]
	private void CmdNotifySceneLoaded(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdNotifySceneLoaded__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkSceneLoader::CmdNotifySceneLoaded(Mirror.NetworkConnectionToClient)", -2028580693, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void CheckAllClientsReady()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneLoader::CheckAllClientsReady()' called when server was not active");
			return;
		}
		int count = NetworkServer.connections.Count;
		if (_readyClients.Count >= count)
		{
			DebugLog($"All clients ready ({_readyClients.Count}/{count}) for scene '{_currentLoadingScene}', spawning objects");
			string currentLoadingScene = _currentLoadingScene;
			RpcAllPlayersReady(currentLoadingScene);
			onAllPlayersReady?.Invoke(currentLoadingScene);
			NetworkServer.SpawnObjects();
		}
	}

	[ClientRpc]
	private void RpcLoadScene(string sceneName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(sceneName);
		SendRPCInternal("System.Void NetworkSceneLoader::RpcLoadScene(System.String)", 1086126151, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcUnloadScene(string sceneName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(sceneName);
		SendRPCInternal("System.Void NetworkSceneLoader::RpcUnloadScene(System.String)", 765601828, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcAllPlayersReady(string sceneName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(sceneName);
		SendRPCInternal("System.Void NetworkSceneLoader::RpcAllPlayersReady(System.String)", 386447557, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator LoadSceneAsync(string sceneName)
	{
		DebugLog("LoadSceneAsync started for '" + sceneName + "'");
		onSceneLoadStarted?.Invoke(sceneName);
		Scene sceneByName = SceneManager.GetSceneByName(sceneName);
		if (sceneByName.isLoaded)
		{
			DebugLog("Scene '" + sceneName + "' already loaded, skipping async load");
			_loadedScene = sceneByName;
			OnSceneLoadComplete(sceneName);
			yield break;
		}
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		if (asyncLoad == null)
		{
			Debug.LogError("[NetworkSceneLoader] Sahne yüklenemedi: " + sceneName + ". Build Settings'de olduğundan emin olun!");
			yield break;
		}
		_lastLoggedProgress = -1;
		while (!asyncLoad.isDone)
		{
			int num = Mathf.RoundToInt(asyncLoad.progress * 100f);
			if (num != _lastLoggedProgress)
			{
				_lastLoggedProgress = num;
				DebugLog($"Scene load progress for '{sceneName}': {num}%");
			}
			yield return null;
		}
		_loadedScene = SceneManager.GetSceneByName(sceneName);
		OnSceneLoadComplete(sceneName);
	}

	private void OnSceneLoadComplete(string sceneName)
	{
		DebugLog($"Scene load complete for '{sceneName}' (isServer={base.isServer})");
		_hasLoadedSceneLocally = true;
		onSceneLoadedLocally?.Invoke(sceneName);
		if (NetworkClient.active)
		{
			NetworkClient.PrepareToSpawnSceneObjects();
		}
		if (base.isServer)
		{
			ServerNotifySceneLoaded(NetworkServer.localConnection?.connectionId ?? 0);
		}
		else
		{
			CmdNotifySceneLoaded();
		}
	}

	[Server]
	private void ServerNotifySceneLoaded(int connectionId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneLoader::ServerNotifySceneLoaded(System.Int32)' called when server was not active");
			return;
		}
		if (_readyClients.Contains(connectionId))
		{
			DebugLog($"Client {connectionId} already marked as ready, ignoring duplicate");
			return;
		}
		_readyClients.Add(connectionId);
		DebugLog($"Client {connectionId} ready ({_readyClients.Count}/{NetworkServer.connections.Count})");
		CheckAllClientsReady();
	}

	private IEnumerator UnloadSceneAsync(string sceneName)
	{
		DebugLog("UnloadSceneAsync started for '" + sceneName + "'");
		Scene sceneByName = SceneManager.GetSceneByName(sceneName);
		if (!sceneByName.isLoaded)
		{
			DebugLog("Scene '" + sceneName + "' is not loaded, nothing to unload");
			_hasLoadedSceneLocally = false;
			yield break;
		}
		AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneByName);
		if (asyncUnload == null)
		{
			Debug.LogError("[NetworkSceneLoader] Sahne unload edilemedi: " + sceneName);
			yield break;
		}
		while (!asyncUnload.isDone)
		{
			yield return null;
		}
		_hasLoadedSceneLocally = false;
		DebugLog("Scene '" + sceneName + "' unloaded successfully");
		onSceneUnloaded?.Invoke(sceneName);
	}

	private void DebugLog(string message)
	{
		if (enableDebugLogging)
		{
			Debug.Log("[NetworkSceneLoader] " + message);
		}
	}

	[Server]
	public GameObject SpawnInLoadedScene(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'UnityEngine.GameObject NetworkSceneLoader::SpawnInLoadedScene(UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return null;
		}
		if (prefab == null)
		{
			Debug.LogError("[NetworkSceneLoader] SpawnInLoadedScene: Prefab null!");
			return null;
		}
		DebugLog($"SpawnInLoadedScene: spawning '{prefab.name}' at {position}");
		GameObject gameObject = Object.Instantiate(prefab, position, rotation);
		MoveToLoadedScene(gameObject);
		NetworkServer.Spawn(gameObject);
		return gameObject;
	}

	[Server]
	public GameObject SpawnInLoadedSceneWithAuthority(GameObject prefab, Vector3 position, Quaternion rotation, NetworkConnectionToClient owner)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'UnityEngine.GameObject NetworkSceneLoader::SpawnInLoadedSceneWithAuthority(UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion,Mirror.NetworkConnectionToClient)' called when server was not active");
			return null;
		}
		if (prefab == null)
		{
			Debug.LogError("[NetworkSceneLoader] SpawnInLoadedSceneWithAuthority: Prefab null!");
			return null;
		}
		DebugLog($"SpawnInLoadedSceneWithAuthority: spawning '{prefab.name}' at {position} for connection {owner?.connectionId}");
		GameObject gameObject = Object.Instantiate(prefab, position, rotation);
		MoveToLoadedScene(gameObject);
		NetworkServer.Spawn(gameObject, owner);
		return gameObject;
	}

	public void MoveToLoadedScene(GameObject obj)
	{
		if (obj == null)
		{
			Debug.LogError("[NetworkSceneLoader] MoveToLoadedScene: GameObject null!");
			return;
		}
		if (!_loadedScene.IsValid() || !_loadedScene.isLoaded)
		{
			DebugLog("MoveToLoadedScene: no valid loaded scene to move '" + obj.name + "' into");
			return;
		}
		DebugLog("Moving '" + obj.name + "' to loaded scene '" + _loadedScene.name + "'");
		SceneManager.MoveGameObjectToScene(obj, _loadedScene);
	}

	[Server]
	public void MoveSpawnedObjectToLoadedScene(NetworkIdentity networkIdentity)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void NetworkSceneLoader::MoveSpawnedObjectToLoadedScene(Mirror.NetworkIdentity)' called when server was not active");
			return;
		}
		if (networkIdentity == null)
		{
			Debug.LogError("[NetworkSceneLoader] MoveSpawnedObjectToLoadedScene: NetworkIdentity null!");
			return;
		}
		if (!_loadedScene.IsValid() || !_loadedScene.isLoaded)
		{
			DebugLog("MoveSpawnedObjectToLoadedScene: no valid loaded scene to move '" + networkIdentity.gameObject.name + "' into");
			return;
		}
		DebugLog($"Moving spawned object '{networkIdentity.gameObject.name}' (netId={networkIdentity.netId}) to scene '{_loadedScene.name}'");
		SceneManager.MoveGameObjectToScene(networkIdentity.gameObject, _loadedScene);
		RpcMoveObjectToScene(networkIdentity, _loadedScene.name);
	}

	[ClientRpc]
	private void RpcMoveObjectToScene(NetworkIdentity networkIdentity, string sceneName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkIdentity(networkIdentity);
		writer.WriteString(sceneName);
		SendRPCInternal("System.Void NetworkSceneLoader::RpcMoveObjectToScene(Mirror.NetworkIdentity,System.String)", 1634313277, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestSceneLoad__String__NetworkConnectionToClient(string sceneName, NetworkConnectionToClient sender)
	{
		ServerStartSceneLoad(sceneName);
	}

	protected static void InvokeUserCode_CmdRequestSceneLoad__String__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestSceneLoad called on client.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_CmdRequestSceneLoad__String__NetworkConnectionToClient(reader.ReadString(), senderConnection);
		}
	}

	protected void UserCode_CmdRequestSceneUnload__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerUnloadScene();
	}

	protected static void InvokeUserCode_CmdRequestSceneUnload__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestSceneUnload called on client.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_CmdRequestSceneUnload__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdRequestSpecificSceneUnload__String__NetworkConnectionToClient(string sceneName, NetworkConnectionToClient sender)
	{
		ServerUnloadSpecificScene(sceneName);
	}

	protected static void InvokeUserCode_CmdRequestSpecificSceneUnload__String__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestSpecificSceneUnload called on client.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_CmdRequestSpecificSceneUnload__String__NetworkConnectionToClient(reader.ReadString(), senderConnection);
		}
	}

	protected void UserCode_CmdNotifySceneLoaded__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null)
		{
			ServerNotifySceneLoaded(sender.connectionId);
		}
	}

	protected static void InvokeUserCode_CmdNotifySceneLoaded__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdNotifySceneLoaded called on client.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_CmdNotifySceneLoaded__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcLoadScene__String(string sceneName)
	{
		if (!base.isServer)
		{
			StartCoroutine(LoadSceneAsync(sceneName));
		}
	}

	protected static void InvokeUserCode_RpcLoadScene__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcLoadScene called on server.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_RpcLoadScene__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcUnloadScene__String(string sceneName)
	{
		if (!base.isServer)
		{
			StartCoroutine(UnloadSceneAsync(sceneName));
		}
	}

	protected static void InvokeUserCode_RpcUnloadScene__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUnloadScene called on server.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_RpcUnloadScene__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcAllPlayersReady__String(string sceneName)
	{
		if (!base.isServer)
		{
			onAllPlayersReady?.Invoke(sceneName);
		}
	}

	protected static void InvokeUserCode_RpcAllPlayersReady__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAllPlayersReady called on server.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_RpcAllPlayersReady__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcMoveObjectToScene__NetworkIdentity__String(NetworkIdentity networkIdentity, string sceneName)
	{
		if (!base.isServer && !(networkIdentity == null))
		{
			Scene sceneByName = SceneManager.GetSceneByName(sceneName);
			if (sceneByName.IsValid() && sceneByName.isLoaded)
			{
				SceneManager.MoveGameObjectToScene(networkIdentity.gameObject, sceneByName);
			}
		}
	}

	protected static void InvokeUserCode_RpcMoveObjectToScene__NetworkIdentity__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcMoveObjectToScene called on server.");
		}
		else
		{
			((NetworkSceneLoader)obj).UserCode_RpcMoveObjectToScene__NetworkIdentity__String(reader.ReadNetworkIdentity(), reader.ReadString());
		}
	}

	static NetworkSceneLoader()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::CmdRequestSceneLoad(System.String,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestSceneLoad__String__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::CmdRequestSceneUnload(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestSceneUnload__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::CmdRequestSpecificSceneUnload(System.String,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestSpecificSceneUnload__String__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::CmdNotifySceneLoaded(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdNotifySceneLoaded__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::RpcLoadScene(System.String)", InvokeUserCode_RpcLoadScene__String);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::RpcUnloadScene(System.String)", InvokeUserCode_RpcUnloadScene__String);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::RpcAllPlayersReady(System.String)", InvokeUserCode_RpcAllPlayersReady__String);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSceneLoader), "System.Void NetworkSceneLoader::RpcMoveObjectToScene(Mirror.NetworkIdentity,System.String)", InvokeUserCode_RpcMoveObjectToScene__NetworkIdentity__String);
	}
}
