using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mirror
{
	[DisallowMultipleComponent]
	public class NetworkManager : MonoBehaviour
	{
		public static bool ACTUALLY_QUITTING;

		public bool dontDestroyOnLoad;

		[Obsolete]
		public bool PersistNetworkManagerToOfflineScene;

		public bool runInBackground;

		public bool autoStartServerBuild;

		public int serverTickRate;

		public bool serverBatching;

		public float serverBatchInterval;

		[Scene]
		public string offlineScene;

		[Scene]
		public string onlineScene;

		[SerializeField]
		protected Transport transport;

		public string networkAddress;

		public int maxConnections;

		public bool disconnectInactiveConnections;

		public float disconnectInactiveTimeout;

		public NetworkAuthenticator authenticator;

		public GameObject playerPrefab;

		public bool autoCreatePlayer;

		public PlayerSpawnMethod playerSpawnMethod;

		[HideInInspector]
		public List<GameObject> spawnPrefabs;

		public static List<Transform> startPositions;

		public static int startPositionIndex;

		[NonSerialized]
		public bool isNetworkActive;

		private static NetworkConnection clientReadyConnection;

		[NonSerialized]
		public bool clientLoadedScene;

		private bool finishStartHostPending;

		public static AsyncOperation loadingSceneAsync;

		private SceneOperation clientSceneOperation;

		public static NetworkManager singleton { get; private set; }

		public int numPlayers => 0;

		public NetworkManagerMode mode { get; private set; }

		public static string networkSceneName { get; protected set; }

		public virtual void OnValidate()
		{
		}

		public virtual void Awake()
		{
		}

		public virtual void Start()
		{
		}

		public virtual void LateUpdate()
		{
		}

		private bool IsServerOnlineSceneChangeNeeded()
		{
			return false;
		}

		public static bool IsSceneActive(string scene)
		{
			return false;
		}

		private void SetupServer()
		{
		}

		public void StartServer()
		{
		}

		public void StartClient()
		{
		}

		public void StartClient(Uri uri)
		{
		}

		public void StartHost()
		{
		}

		private void FinishStartHost()
		{
		}

		private void StartHostClient()
		{
		}

		public void StopHost()
		{
		}

		public void StopServer()
		{
		}

		public void StopClient()
		{
		}

		public virtual void OnApplicationQuit()
		{
		}

		public virtual void ConfigureServerFrameRate()
		{
		}

		private bool InitializeSingleton()
		{
			return false;
		}

		private void RegisterServerMessages()
		{
		}

		private void RegisterClientMessages()
		{
		}

		public static void Shutdown()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void ServerChangeScene(string newSceneName)
		{
		}

		internal void ClientChangeScene(string newSceneName, SceneOperation sceneOperation = SceneOperation.Normal, bool customHandling = false)
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void UpdateScene()
		{
		}

		protected void FinishLoadScene()
		{
		}

		private void FinishLoadSceneHost()
		{
		}

		private void FinishLoadSceneServerOnly()
		{
		}

		private void FinishLoadSceneClientOnly()
		{
		}

		public static void RegisterStartPosition(Transform start)
		{
		}

		public static void UnRegisterStartPosition(Transform start)
		{
		}

		public Transform GetStartPosition()
		{
			return null;
		}

		private void OnServerConnectInternal(NetworkConnection conn)
		{
		}

		private void OnServerAuthenticated(NetworkConnection conn)
		{
		}

		private void OnServerDisconnectInternal(NetworkConnection conn)
		{
		}

		private void OnServerReadyMessageInternal(NetworkConnection conn, ReadyMessage msg)
		{
		}

		private void OnServerAddPlayerInternal(NetworkConnection conn, AddPlayerMessage msg)
		{
		}

		private void OnClientConnectInternal()
		{
		}

		private void OnClientAuthenticated(NetworkConnection conn)
		{
		}

		private void OnClientDisconnectInternal()
		{
		}

		private void OnClientNotReadyMessageInternal(NotReadyMessage msg)
		{
		}

		private void OnClientSceneInternal(SceneMessage msg)
		{
		}

		public virtual void OnServerConnect(NetworkConnection conn)
		{
		}

		public virtual void OnServerDisconnect(NetworkConnection conn)
		{
		}

		public virtual void OnServerReady(NetworkConnection conn)
		{
		}

		public virtual void OnServerAddPlayer(NetworkConnection conn)
		{
		}

		[Obsolete]
		public virtual void OnServerError(NetworkConnection conn, int errorCode)
		{
		}

		public virtual void OnServerChangeScene(string newSceneName)
		{
		}

		public virtual void OnServerSceneChanged(string sceneName)
		{
		}

		public virtual void OnClientConnect(NetworkConnection conn)
		{
		}

		public virtual void OnClientDisconnect(NetworkConnection conn)
		{
		}

		[Obsolete]
		public virtual void OnClientError(NetworkConnection conn, int errorCode)
		{
		}

		public virtual void OnClientNotReady(NetworkConnection conn)
		{
		}

		public virtual void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
		{
		}

		public virtual void OnClientSceneChanged(NetworkConnection conn)
		{
		}

		public virtual void OnStartHost()
		{
		}

		public virtual void OnStartServer()
		{
		}

		public virtual void OnStartClient()
		{
		}

		public virtual void OnStopServer()
		{
		}

		public virtual void OnStopClient()
		{
		}

		public virtual void OnStopHost()
		{
		}
	}
}
