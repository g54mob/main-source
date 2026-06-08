using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MLAPI.Configuration;
using MLAPI.Connection;
using MLAPI.Exceptions;
using MLAPI.Internal;
using MLAPI.LagCompensation;
using MLAPI.Logging;
using MLAPI.Messaging;
using MLAPI.Messaging.Buffering;
using MLAPI.Profiling;
using MLAPI.SceneManagement;
using MLAPI.Security;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;
using MLAPI.Spawning;
using MLAPI.Transports;
using MLAPI.Transports.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MLAPI
{
	[AddComponentMenu("MLAPI/NetworkingManager", -100)]
	public class NetworkingManager : MonoBehaviour
	{
		public delegate void ConnectionApprovedDelegate(bool createPlayerObject, ulong? playerPrefabHash, bool approved, Vector3? position, Quaternion? rotation);

		private float networkTimeOffset;

		private float currentNetworkTimeOffset;

		[HideInInspector]
		public bool DontDestroy = true;

		[HideInInspector]
		public bool RunInBackground = true;

		[HideInInspector]
		public LogLevel LogLevel = LogLevel.Normal;

		private ulong localClientId;

		public readonly Dictionary<ulong, NetworkedClient> ConnectedClients = new Dictionary<ulong, NetworkedClient>();

		public readonly List<NetworkedClient> ConnectedClientsList = new List<NetworkedClient>();

		public readonly Dictionary<ulong, PendingClient> PendingClients = new Dictionary<ulong, PendingClient>();

		[HideInInspector]
		public NetworkConfig NetworkConfig;

		internal byte[] clientAesKey;

		private float lastReceiveTickTime;

		private float lastEventTickTime;

		private float eventOvershootCounter;

		private float lastTimeSyncTime;

		private readonly BitStream inputStreamWrapper = new BitStream(new byte[0]);

		private readonly List<NetworkedObject> _observedObjects = new List<NetworkedObject>();

		public float NetworkTime => Time.unscaledTime + currentNetworkTimeOffset;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Singleton instead", false)]
		public static NetworkingManager singleton => Singleton;

		public static NetworkingManager Singleton { get; private set; }

		public ulong ServerClientId
		{
			get
			{
				if (!(NetworkConfig.NetworkTransport != null))
				{
					throw new NullReferenceException("The transport in the active NetworkConfig is null");
				}
				return NetworkConfig.NetworkTransport.ServerClientId;
			}
		}

		public ulong LocalClientId
		{
			get
			{
				if (IsServer)
				{
					return NetworkConfig.NetworkTransport.ServerClientId;
				}
				return localClientId;
			}
			internal set
			{
				localClientId = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsServer instead", false)]
		public bool isServer => IsServer;

		public bool IsServer { get; internal set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsClient instead", false)]
		public bool isClient => IsClient;

		public bool IsClient { get; internal set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsHost instead", false)]
		public bool isHost => IsHost;

		public bool IsHost
		{
			get
			{
				if (IsServer)
				{
					return IsClient;
				}
				return false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsListening instead", false)]
		public bool isListening => IsListening;

		public bool IsListening { get; internal set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsConnectedClient instead", false)]
		public bool isConnectedClients => IsConnectedClient;

		public bool IsConnectedClient { get; internal set; }

		public string ConnectedHostname { get; private set; }

		public event Action<ulong> OnClientConnectedCallback;

		public event Action<ulong> OnClientDisconnectCallback;

		public event Action OnServerStarted;

		public event Action<byte[], ulong, ConnectionApprovedDelegate> ConnectionApprovalCallback;

		[Obsolete("Use OnUnnamedMessage instead")]
		public event CustomMessagingManager.UnnamedMessageDelegate OnIncomingCustomMessage;

		internal static event Action OnSingletonReady;

		internal void InvokeOnClientConnectedCallback(ulong clientId)
		{
			if (this.OnClientConnectedCallback != null)
			{
				this.OnClientConnectedCallback(clientId);
			}
		}

		internal void InvokeOnClientDisconnectCallback(ulong clientId)
		{
			if (this.OnClientDisconnectCallback != null)
			{
				this.OnClientDisconnectCallback(clientId);
			}
		}

		internal void InvokeConnectionApproval(byte[] payload, ulong clientId, ConnectionApprovedDelegate action)
		{
			if (this.ConnectionApprovalCallback != null)
			{
				this.ConnectionApprovalCallback(payload, clientId, action);
			}
		}

		internal void InvokeOnIncomingCustomMessage(ulong clientId, Stream stream)
		{
			if (this.OnIncomingCustomMessage != null)
			{
				this.OnIncomingCustomMessage(clientId, stream);
			}
		}

		[Obsolete("Use CustomMessagingManager.SendUnnamedMessage instead")]
		public void SendCustomMessage(List<ulong> clientIds, BitStream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			if (!IsServer)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogWarning("Can not send unnamed message to multiple users as a client");
				}
			}
			else
			{
				InternalMessageSender.Send(20, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, clientIds, stream, security, null);
			}
		}

		[Obsolete("Use CustomMessagingManager.SendUnnamedMessage instead")]
		public void SendCustomMessage(ulong clientId, BitStream stream, string channel = null, SecuritySendFlags security = SecuritySendFlags.None)
		{
			InternalMessageSender.Send(clientId, 20, string.IsNullOrEmpty(channel) ? "MLAPI_DEFAULT_MESSAGE" : channel, stream, security, null);
		}

		private void OnValidate()
		{
			if (NetworkConfig == null)
			{
				return;
			}
			if (GetComponentInChildren<NetworkedObject>() != null && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("The NetworkingManager cannot be a NetworkedObject. This will lead to weird side effects.");
			}
			if (!NetworkConfig.RegisteredScenes.Contains(SceneManager.GetActiveScene().name))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("The active scene is not registered as a networked scene. The MLAPI has added it");
				}
				NetworkConfig.RegisteredScenes.Add(SceneManager.GetActiveScene().name);
			}
			for (int i = 0; i < NetworkConfig.NetworkedPrefabs.Count; i++)
			{
				if (NetworkConfig.NetworkedPrefabs[i] == null || !(NetworkConfig.NetworkedPrefabs[i].Prefab != null))
				{
					continue;
				}
				if (NetworkConfig.NetworkedPrefabs[i].Prefab.GetComponent<NetworkedObject>() == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("The network prefab [" + i + "] does not have a NetworkedObject component");
					}
				}
				else
				{
					NetworkConfig.NetworkedPrefabs[i].Prefab.GetComponent<NetworkedObject>().ValidateHash();
				}
			}
			HashSet<ulong> hashSet = new HashSet<ulong>();
			for (int j = 0; j < NetworkConfig.NetworkedPrefabs.Count; j++)
			{
				if (hashSet.Contains(NetworkConfig.NetworkedPrefabs[j].Hash) && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogError("PrefabHash collision! You have two prefabs with the same hash. This is not supported");
				}
				hashSet.Add(NetworkConfig.NetworkedPrefabs[j].Hash);
			}
			int num = NetworkConfig.NetworkedPrefabs.Count((NetworkedPrefab x) => x.PlayerPrefab);
			if (num == 0 && !NetworkConfig.ConnectionApproval && NetworkConfig.CreatePlayerPrefab)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("There is no NetworkedPrefab marked as a PlayerPrefab");
				}
			}
			else if (num > 1 && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("Only one networked prefab can be marked as a player prefab");
			}
			NetworkedPrefab networkedPrefab = NetworkConfig.NetworkedPrefabs.FirstOrDefault((NetworkedPrefab x) => x.PlayerPrefab);
			if (networkedPrefab == null)
			{
				NetworkConfig.PlayerPrefabHash = null;
			}
			else
			{
				NetworkConfig.PlayerPrefabHash.Value = networkedPrefab.Hash;
			}
		}

		private void Init(bool server)
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Init()");
			}
			LocalClientId = 0uL;
			networkTimeOffset = 0f;
			currentNetworkTimeOffset = 0f;
			lastEventTickTime = 0f;
			lastReceiveTickTime = 0f;
			eventOvershootCounter = 0f;
			PendingClients.Clear();
			ConnectedClients.Clear();
			ConnectedClientsList.Clear();
			ResponseMessageManager.Clear();
			SpawnManager.SpawnedObjects.Clear();
			SpawnManager.SpawnedObjectsList.Clear();
			SpawnManager.releasedNetworkObjectIds.Clear();
			SpawnManager.pendingSoftSyncObjects.Clear();
			NetworkSceneManager.registeredSceneNames.Clear();
			NetworkSceneManager.sceneIndexToString.Clear();
			NetworkSceneManager.sceneNameToIndex.Clear();
			NetworkSceneManager.sceneSwitchProgresses.Clear();
			if (NetworkConfig.NetworkTransport == null)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("No transport has been selected!");
				}
				return;
			}
			try
			{
				string text = NetworkConfig.ServerBase64PfxCertificate.Trim();
				if (server && NetworkConfig.EnableEncryption && NetworkConfig.SignKeyExchange && !string.IsNullOrEmpty(text))
				{
					try
					{
						byte[] rawData = Convert.FromBase64String(text);
						NetworkConfig.ServerX509Certificate = new X509Certificate2(rawData);
						if (!NetworkConfig.ServerX509Certificate.HasPrivateKey && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
						{
							NetworkLog.LogWarning("The imported PFX file did not have a private key");
						}
					}
					catch (FormatException ex)
					{
						if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
						{
							NetworkLog.LogError("Parsing PFX failed: " + ex.ToString());
						}
					}
				}
			}
			catch (CryptographicException ex2)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Importing of certificate failed: " + ex2.ToString());
				}
			}
			if (NetworkConfig.EnableSceneManagement)
			{
				NetworkConfig.RegisteredScenes.Sort(StringComparer.Ordinal);
				for (int i = 0; i < NetworkConfig.RegisteredScenes.Count; i++)
				{
					NetworkSceneManager.registeredSceneNames.Add(NetworkConfig.RegisteredScenes[i]);
					NetworkSceneManager.sceneIndexToString.Add((uint)i, NetworkConfig.RegisteredScenes[i]);
					NetworkSceneManager.sceneNameToIndex.Add(NetworkConfig.RegisteredScenes[i], (uint)i);
				}
				NetworkSceneManager.SetCurrentSceneIndex();
			}
			for (int j = 0; j < NetworkConfig.NetworkedPrefabs.Count; j++)
			{
				if (NetworkConfig.NetworkedPrefabs[j] == null || NetworkConfig.NetworkedPrefabs[j].Prefab == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogError("Networked prefab cannot be null");
					}
				}
				else if (NetworkConfig.NetworkedPrefabs[j].Prefab.GetComponent<NetworkedObject>() == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogError("Networked prefab is missing a NetworkedObject component");
					}
				}
				else
				{
					NetworkConfig.NetworkedPrefabs[j].Prefab.GetComponent<NetworkedObject>().ValidateHash();
				}
			}
			NetworkConfig.NetworkTransport.OnTransportEvent += HandleRawTransportPoll;
			NetworkConfig.NetworkTransport.ResetChannelCache();
			NetworkConfig.NetworkTransport.Init();
		}

		public SocketTasks StartServer()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StartServer()");
			}
			if (IsServer || IsClient)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Cannot start server while an instance is already running");
				}
				return SocketTask.Fault.AsTasks();
			}
			if (NetworkConfig.ConnectionApproval && this.ConnectionApprovalCallback == null && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("No ConnectionApproval callback defined. Connection approval will timeout");
			}
			Init(server: true);
			SocketTasks result = NetworkConfig.NetworkTransport.StartServer();
			IsServer = true;
			IsClient = false;
			IsListening = true;
			SpawnManager.ServerSpawnSceneObjectsOnStartSweep();
			if (this.OnServerStarted != null)
			{
				this.OnServerStarted();
			}
			return result;
		}

		public SocketTasks StartClient()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StartClient()");
			}
			if (IsServer || IsClient)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Cannot start client while an instance is already running");
				}
				return SocketTask.Fault.AsTasks();
			}
			Init(server: false);
			SocketTasks result = NetworkConfig.NetworkTransport.StartClient();
			IsServer = false;
			IsClient = true;
			IsListening = true;
			return result;
		}

		public void StopServer()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StopServer()");
			}
			HashSet<ulong> hashSet = new HashSet<ulong>();
			foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in ConnectedClients)
			{
				if (!hashSet.Contains(connectedClient.Key))
				{
					hashSet.Add(connectedClient.Key);
					if (connectedClient.Key != NetworkConfig.NetworkTransport.ServerClientId)
					{
						NetworkConfig.NetworkTransport.DisconnectRemoteClient(connectedClient.Key);
					}
				}
			}
			foreach (KeyValuePair<ulong, PendingClient> pendingClient in PendingClients)
			{
				if (!hashSet.Contains(pendingClient.Key))
				{
					hashSet.Add(pendingClient.Key);
					if (pendingClient.Key != NetworkConfig.NetworkTransport.ServerClientId)
					{
						NetworkConfig.NetworkTransport.DisconnectRemoteClient(pendingClient.Key);
					}
				}
			}
			IsServer = false;
			Shutdown();
		}

		public void StopHost()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StopHost()");
			}
			IsServer = false;
			IsClient = false;
			StopServer();
		}

		public void StopClient()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StopClient()");
			}
			IsClient = false;
			NetworkConfig.NetworkTransport.DisconnectLocalClient();
			IsConnectedClient = false;
			Shutdown();
		}

		public SocketTasks StartHost(Vector3? position = null, Quaternion? rotation = null, bool? createPlayerObject = null, ulong? prefabHash = null, Stream payloadStream = null)
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("StartHost()");
			}
			if (IsServer || IsClient)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Cannot start host while an instance is already running");
				}
				return SocketTask.Fault.AsTasks();
			}
			if (NetworkConfig.ConnectionApproval && this.ConnectionApprovalCallback == null && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("No ConnectionApproval callback defined. Connection approval will timeout");
			}
			Init(server: true);
			SocketTasks result = NetworkConfig.NetworkTransport.StartServer();
			IsServer = true;
			IsClient = true;
			IsListening = true;
			ulong serverClientId = NetworkConfig.NetworkTransport.ServerClientId;
			ConnectedClients.Add(serverClientId, new NetworkedClient
			{
				ClientId = serverClientId
			});
			ConnectedClientsList.Add(ConnectedClients[serverClientId]);
			if ((!createPlayerObject.HasValue && NetworkConfig.CreatePlayerPrefab) || (createPlayerObject.HasValue && createPlayerObject.Value))
			{
				NetworkedObject networkedObject = SpawnManager.CreateLocalNetworkedObject(softCreate: false, 0uL, (!prefabHash.HasValue) ? NetworkConfig.PlayerPrefabHash.Value : prefabHash.Value, null, position, rotation);
				SpawnManager.SpawnNetworkedObjectLocally(networkedObject, SpawnManager.GetNetworkObjectId(), sceneObject: false, playerObject: true, serverClientId, payloadStream, payloadStream != null, (int)((payloadStream != null) ? payloadStream.Length : 0), readNetworkedVar: false, destroyWithScene: false);
				if (networkedObject.CheckObjectVisibility == null || networkedObject.CheckObjectVisibility(serverClientId))
				{
					networkedObject.observers.Add(serverClientId);
				}
			}
			SpawnManager.ServerSpawnSceneObjectsOnStartSweep();
			if (this.OnServerStarted != null)
			{
				this.OnServerStarted();
			}
			return result;
		}

		private void OnEnable()
		{
			if (Singleton != null && Singleton != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			Singleton = this;
			if (NetworkingManager.OnSingletonReady != null)
			{
				NetworkingManager.OnSingletonReady();
			}
			if (DontDestroy)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			if (RunInBackground)
			{
				Application.runInBackground = true;
			}
		}

		private void OnDestroy()
		{
			if (Singleton != null && Singleton == this)
			{
				Singleton = null;
				Shutdown();
			}
		}

		private void Shutdown()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Shutdown()");
			}
			NetworkProfiler.Stop();
			IsListening = false;
			IsServer = false;
			IsClient = false;
			NetworkConfig.NetworkTransport.OnTransportEvent -= HandleRawTransportPoll;
			SpawnManager.DestroyNonSceneObjects();
			SpawnManager.ServerResetShudownStateForSceneObjects();
			if (NetworkConfig != null && NetworkConfig.NetworkTransport != null)
			{
				NetworkConfig.NetworkTransport.Shutdown();
			}
		}

		private void Update()
		{
			if (!IsListening)
			{
				return;
			}
			if (NetworkTime - lastReceiveTickTime >= 1f / (float)NetworkConfig.ReceiveTickrate || NetworkConfig.ReceiveTickrate <= 0)
			{
				NetworkProfiler.StartTick(TickType.Receive);
				int num = 0;
				NetEventType netEventType;
				do
				{
					num++;
					netEventType = NetworkConfig.NetworkTransport.PollEvent(out var clientId, out var channelName, out var payload, out var receiveTime);
					HandleRawTransportPoll(netEventType, clientId, channelName, payload, receiveTime);
				}
				while (IsListening && netEventType != NetEventType.Nothing && (NetworkConfig.MaxReceiveEventsPerTickRate <= 0 || num < NetworkConfig.MaxReceiveEventsPerTickRate));
				lastReceiveTickTime = NetworkTime;
				NetworkProfiler.EndTick();
			}
			if (!IsListening)
			{
				return;
			}
			if (NetworkTime - lastEventTickTime >= 1f / (float)NetworkConfig.EventTickrate)
			{
				NetworkProfiler.StartTick(TickType.Event);
				if (IsServer)
				{
					eventOvershootCounter += NetworkTime - lastEventTickTime - 1f / (float)NetworkConfig.EventTickrate;
					LagCompensationManager.AddFrames();
					ResponseMessageManager.CheckTimeouts();
				}
				if (NetworkConfig.EnableNetworkedVar)
				{
					NetworkedObject.NetworkedBehaviourUpdate();
				}
				if (!IsServer && NetworkConfig.EnableMessageBuffering)
				{
					BufferManager.CleanBuffer();
				}
				if (IsServer)
				{
					lastEventTickTime = NetworkTime;
				}
				NetworkProfiler.EndTick();
			}
			else if (IsServer && eventOvershootCounter >= 1f / (float)NetworkConfig.EventTickrate)
			{
				NetworkProfiler.StartTick(TickType.Event);
				eventOvershootCounter -= 1f / (float)NetworkConfig.EventTickrate;
				LagCompensationManager.AddFrames();
				NetworkProfiler.EndTick();
			}
			if (IsServer && NetworkConfig.EnableTimeResync && NetworkTime - lastTimeSyncTime >= (float)NetworkConfig.TimeResyncInterval)
			{
				NetworkProfiler.StartTick(TickType.Event);
				SyncTime();
				lastTimeSyncTime = NetworkTime;
				NetworkProfiler.EndTick();
			}
			if (!Mathf.Approximately(networkTimeOffset, currentNetworkTimeOffset))
			{
				float num2 = Mathf.Max(0.001f, 0.2f * Time.unscaledDeltaTime);
				currentNetworkTimeOffset += Mathf.Clamp(networkTimeOffset - currentNetworkTimeOffset, 0f - num2, num2);
			}
		}

		internal void UpdateNetworkTime(ulong clientId, float netTime, float receiveTime, bool warp = false)
		{
			float num = (float)NetworkConfig.NetworkTransport.GetCurrentRtt(clientId) / 1000f;
			networkTimeOffset = netTime - receiveTime + num / 2f;
			if (warp)
			{
				currentNetworkTimeOffset = networkTimeOffset;
			}
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo(string.Format("Received network time {0}, RTT to server is {1}, {2} offset to {3} (delta {4})", netTime, num, warp ? "setting" : "smearing", networkTimeOffset, networkTimeOffset - currentNetworkTimeOffset));
			}
		}

		internal void SendConnectionRequest()
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
			{
				pooledBitWriter.WriteUInt64Packed(NetworkConfig.GetConfig());
				if (NetworkConfig.ConnectionApproval)
				{
					pooledBitWriter.WriteByteArray(NetworkConfig.ConnectionData, -1L);
				}
			}
			InternalMessageSender.Send(ServerClientId, 3, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.Encrypted | SecuritySendFlags.Authenticated, null);
		}

		private IEnumerator ApprovalTimeout(ulong clientId)
		{
			float timeStarted = NetworkTime;
			while (NetworkTime - timeStarted < (float)NetworkConfig.ClientConnectionBufferTimeout && PendingClients.ContainsKey(clientId))
			{
				yield return null;
			}
			if (PendingClients.ContainsKey(clientId) && !ConnectedClients.ContainsKey(clientId))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogInfo("Client " + clientId + " Handshake Timed Out");
				}
				DisconnectClient(clientId);
			}
		}

		internal IEnumerator TimeOutSwitchSceneProgress(SceneSwitchProgress switchSceneProgress)
		{
			yield return new WaitForSecondsRealtime(NetworkConfig.LoadSceneTimeOut);
			switchSceneProgress.SetTimedOut();
		}

		private void HandleRawTransportPoll(NetEventType eventType, ulong clientId, string channelName, ArraySegment<byte> payload, float receiveTime)
		{
			switch (eventType)
			{
			case NetEventType.Connect:
				NetworkProfiler.StartEvent(TickType.Receive, (uint)payload.Count, channelName, "TRANSPORT_CONNECT");
				if (IsServer)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
					{
						NetworkLog.LogInfo("Client Connected");
					}
					if (NetworkConfig.EnableEncryption)
					{
						using PooledBitStream pooledBitStream = PooledBitStream.Get();
						using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
						{
							if (NetworkConfig.SignKeyExchange)
							{
								pooledBitWriter.WriteByteArray(NetworkConfig.ServerX509CertificateBytes, -1L);
							}
							EllipticDiffieHellman ellipticDiffieHellman = new EllipticDiffieHellman(EllipticDiffieHellman.DEFAULT_CURVE, EllipticDiffieHellman.DEFAULT_GENERATOR, EllipticDiffieHellman.DEFAULT_ORDER);
							byte[] publicKey = ellipticDiffieHellman.GetPublicKey();
							pooledBitWriter.WriteByteArray(publicKey, -1L);
							PendingClients.Add(clientId, new PendingClient
							{
								ClientId = clientId,
								ConnectionState = PendingClient.State.PendingHail,
								KeyExchange = ellipticDiffieHellman
							});
							if (NetworkConfig.SignKeyExchange)
							{
								X509Certificate2 serverX509Certificate = NetworkConfig.ServerX509Certificate;
								if (!serverX509Certificate.HasPrivateKey)
								{
									throw new CryptographicException("[MLAPI] No private key was found in server certificate. Unable to sign key exchange");
								}
								RSACryptoServiceProvider rSACryptoServiceProvider = serverX509Certificate.PrivateKey as RSACryptoServiceProvider;
								DSACryptoServiceProvider dSACryptoServiceProvider = serverX509Certificate.PrivateKey as DSACryptoServiceProvider;
								if (rSACryptoServiceProvider != null)
								{
									pooledBitWriter.WriteByte(0);
									using SHA256Managed halg = new SHA256Managed();
									pooledBitWriter.WriteByteArray(rSACryptoServiceProvider.SignData(publicKey, halg), -1L);
								}
								else
								{
									if (dSACryptoServiceProvider == null)
									{
										throw new CryptographicException("[MLAPI] Only RSA and DSA certificates are supported. No valid RSA or DSA key was found");
									}
									pooledBitWriter.WriteByte(1);
									using SHA256Managed sHA256Managed = new SHA256Managed();
									pooledBitWriter.WriteByteArray(dSACryptoServiceProvider.SignData(sHA256Managed.ComputeHash(publicKey)), -1L);
								}
							}
						}
						InternalMessageSender.Send(clientId, 0, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
					}
					else
					{
						PendingClients.Add(clientId, new PendingClient
						{
							ClientId = clientId,
							ConnectionState = PendingClient.State.PendingConnection
						});
					}
					StartCoroutine(ApprovalTimeout(clientId));
				}
				else
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
					{
						NetworkLog.LogInfo("Connected");
					}
					if (!NetworkConfig.EnableEncryption)
					{
						SendConnectionRequest();
					}
					StartCoroutine(ApprovalTimeout(clientId));
				}
				NetworkProfiler.EndEvent();
				break;
			case NetEventType.Data:
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogInfo($"Incoming Data From {clientId} : {payload.Count} bytes");
				}
				HandleIncomingData(clientId, channelName, payload, receiveTime, allowBuffer: true);
				break;
			case NetEventType.Disconnect:
				NetworkProfiler.StartEvent(TickType.Receive, 0u, "NONE", "TRANSPORT_DISCONNECT");
				if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
				{
					NetworkLog.LogInfo("Disconnect Event From " + clientId);
				}
				if (IsServer)
				{
					OnClientDisconnectFromServer(clientId);
				}
				else
				{
					IsConnectedClient = false;
					StopClient();
				}
				if (this.OnClientDisconnectCallback != null)
				{
					this.OnClientDisconnectCallback(clientId);
				}
				NetworkProfiler.EndEvent();
				break;
			}
		}

		internal void HandleIncomingData(ulong clientId, string channelName, ArraySegment<byte> data, float receiveTime, bool allowBuffer)
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Unwrapping Data Header");
			}
			inputStreamWrapper.SetTarget(data.Array);
			inputStreamWrapper.SetLength(data.Count + data.Offset);
			inputStreamWrapper.Position = data.Offset;
			byte messageType;
			SecuritySendFlags security;
			using BitStream bitStream = MessagePacker.UnwrapMessage(inputStreamWrapper, clientId, out messageType, out security);
			if (bitStream == null)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Message unwrap could not be completed. Was the header corrupt? Crypto error?");
				}
				return;
			}
			if (messageType == 32)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Message unwrap read an invalid messageType");
				}
				return;
			}
			uint num = (uint)Arithmetic.VarIntSize(messageType);
			NetworkProfiler.StartEvent(TickType.Receive, (uint)(data.Count - num), channelName, messageType);
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Data Header: messageType=" + messageType);
			}
			if ((IsServer && NetworkConfig.EnableEncryption && PendingClients.ContainsKey(clientId) && PendingClients[clientId].ConnectionState == PendingClient.State.PendingHail && messageType != 1) || (PendingClients.ContainsKey(clientId) && PendingClients[clientId].ConnectionState == PendingClient.State.PendingConnection && messageType != 3))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Message received from clientId " + clientId + " before it has been accepted");
				}
				return;
			}
			switch (messageType)
			{
			case 3:
				if (IsServer)
				{
					InternalMessageHandler.HandleConnectionRequest(clientId, bitStream);
				}
				break;
			case 4:
				if (IsClient)
				{
					InternalMessageHandler.HandleConnectionApproved(clientId, bitStream, receiveTime);
				}
				break;
			case 5:
				if (IsClient)
				{
					InternalMessageHandler.HandleAddObject(clientId, bitStream);
				}
				break;
			case 6:
				if (IsClient)
				{
					InternalMessageHandler.HandleDestroyObject(clientId, bitStream);
				}
				break;
			case 7:
				if (IsClient)
				{
					InternalMessageHandler.HandleSwitchScene(clientId, bitStream);
				}
				break;
			case 9:
				if (IsClient)
				{
					InternalMessageHandler.HandleChangeOwner(clientId, bitStream);
				}
				break;
			case 10:
				if (IsClient)
				{
					InternalMessageHandler.HandleAddObjects(clientId, bitStream);
				}
				break;
			case 21:
				if (IsClient)
				{
					InternalMessageHandler.HandleDestroyObjects(clientId, bitStream);
				}
				break;
			case 11:
				if (IsClient)
				{
					InternalMessageHandler.HandleTimeSync(clientId, bitStream, receiveTime);
				}
				break;
			case 12:
				InternalMessageHandler.HandleNetworkedVarDelta(clientId, bitStream, BufferCallback, new PreBufferPreset
				{
					AllowBuffer = allowBuffer,
					ChannelName = channelName,
					ClientId = clientId,
					Data = data,
					MessageType = messageType,
					ReceiveTime = receiveTime
				});
				break;
			case 13:
				InternalMessageHandler.HandleNetworkedVarUpdate(clientId, bitStream, BufferCallback, new PreBufferPreset
				{
					AllowBuffer = allowBuffer,
					ChannelName = channelName,
					ClientId = clientId,
					Data = data,
					MessageType = messageType,
					ReceiveTime = receiveTime
				});
				break;
			case 14:
				if (IsServer)
				{
					InternalMessageHandler.HandleServerRPC(clientId, bitStream);
				}
				break;
			case 15:
				if (IsServer)
				{
					InternalMessageHandler.HandleServerRPCRequest(clientId, bitStream, channelName, security);
				}
				break;
			case 16:
				if (IsClient)
				{
					InternalMessageHandler.HandleServerRPCResponse(clientId, bitStream);
				}
				break;
			case 17:
				if (IsClient)
				{
					InternalMessageHandler.HandleClientRPC(clientId, bitStream, BufferCallback, new PreBufferPreset
					{
						AllowBuffer = allowBuffer,
						ChannelName = channelName,
						ClientId = clientId,
						Data = data,
						MessageType = messageType,
						ReceiveTime = receiveTime
					});
				}
				break;
			case 18:
				if (IsClient)
				{
					InternalMessageHandler.HandleClientRPCRequest(clientId, bitStream, channelName, security, BufferCallback, new PreBufferPreset
					{
						AllowBuffer = allowBuffer,
						ChannelName = channelName,
						ClientId = clientId,
						Data = data,
						MessageType = messageType,
						ReceiveTime = receiveTime
					});
				}
				break;
			case 19:
				if (IsServer)
				{
					InternalMessageHandler.HandleClientRPCResponse(clientId, bitStream);
				}
				break;
			case 20:
				InternalMessageHandler.HandleUnnamedMessage(clientId, bitStream);
				break;
			case 22:
				InternalMessageHandler.HandleNamedMessage(clientId, bitStream);
				break;
			case 0:
				if (IsClient)
				{
					InternalMessageHandler.HandleHailRequest(clientId, bitStream);
				}
				break;
			case 1:
				if (IsServer)
				{
					InternalMessageHandler.HandleHailResponse(clientId, bitStream);
				}
				break;
			case 2:
				if (IsClient)
				{
					InternalMessageHandler.HandleGreetings(clientId, bitStream);
				}
				break;
			case 8:
				if (IsServer && NetworkConfig.EnableSceneManagement)
				{
					InternalMessageHandler.HandleClientSwitchSceneCompleted(clientId, bitStream);
				}
				break;
			case 23:
				if (IsClient)
				{
					InternalMessageHandler.HandleSyncedVar(clientId, bitStream);
				}
				break;
			case 24:
				if (IsServer && NetworkConfig.EnableNetworkLogs)
				{
					InternalMessageHandler.HandleNetworkLog(clientId, bitStream);
				}
				break;
			default:
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Read unrecognized messageType " + messageType);
				}
				break;
			}
			NetworkProfiler.EndEvent();
		}

		private void BufferCallback(ulong networkId, PreBufferPreset preset)
		{
			if (!preset.AllowBuffer)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("A message of type " + MLAPIConstants.MESSAGE_NAMES[preset.MessageType] + " was recursivley buffered. It has been dropped.");
				}
				return;
			}
			if (!NetworkConfig.EnableMessageBuffering)
			{
				throw new InvalidOperationException("Cannot buffer with buffering disabled.");
			}
			if (IsServer)
			{
				throw new InvalidOperationException("Cannot buffer on server.");
			}
			BufferManager.BufferMessageForNetworkId(networkId, preset.ClientId, preset.ChannelName, preset.ReceiveTime, preset.Data);
		}

		public void DisconnectClient(ulong clientId)
		{
			if (!IsServer)
			{
				throw new NotServerException("Only server can disconnect remote clients. Use StopClient instead.");
			}
			if (ConnectedClients.ContainsKey(clientId))
			{
				ConnectedClients.Remove(clientId);
			}
			if (PendingClients.ContainsKey(clientId))
			{
				PendingClients.Remove(clientId);
			}
			for (int num = ConnectedClientsList.Count - 1; num > -1; num--)
			{
				if (ConnectedClientsList[num].ClientId == clientId)
				{
					ConnectedClientsList.RemoveAt(num);
				}
			}
			NetworkConfig.NetworkTransport.DisconnectRemoteClient(clientId);
		}

		internal void OnClientDisconnectFromServer(ulong clientId)
		{
			if (PendingClients.ContainsKey(clientId))
			{
				PendingClients.Remove(clientId);
			}
			if (!ConnectedClients.ContainsKey(clientId))
			{
				return;
			}
			if (IsServer)
			{
				if (ConnectedClients[clientId].PlayerObject != null)
				{
					if (SpawnManager.customDestroyHandlers.ContainsKey(ConnectedClients[clientId].PlayerObject.PrefabHash))
					{
						SpawnManager.customDestroyHandlers[ConnectedClients[clientId].PlayerObject.PrefabHash](ConnectedClients[clientId].PlayerObject);
						SpawnManager.OnDestroyObject(ConnectedClients[clientId].PlayerObject.NetworkId, destroyGameObject: false);
					}
					else
					{
						UnityEngine.Object.Destroy(ConnectedClients[clientId].PlayerObject.gameObject);
					}
				}
				for (int i = 0; i < ConnectedClients[clientId].OwnedObjects.Count; i++)
				{
					if (!(ConnectedClients[clientId].OwnedObjects[i] != null))
					{
						continue;
					}
					if (!ConnectedClients[clientId].OwnedObjects[i].DontDestroyWithOwner)
					{
						if (SpawnManager.customDestroyHandlers.ContainsKey(ConnectedClients[clientId].OwnedObjects[i].PrefabHash))
						{
							SpawnManager.customDestroyHandlers[ConnectedClients[clientId].OwnedObjects[i].PrefabHash](ConnectedClients[clientId].OwnedObjects[i]);
							SpawnManager.OnDestroyObject(ConnectedClients[clientId].OwnedObjects[i].NetworkId, destroyGameObject: false);
						}
						else
						{
							UnityEngine.Object.Destroy(ConnectedClients[clientId].OwnedObjects[i].gameObject);
						}
					}
					else
					{
						ConnectedClients[clientId].OwnedObjects[i].RemoveOwnership();
					}
				}
				for (int j = 0; j < SpawnManager.SpawnedObjectsList.Count; j++)
				{
					SpawnManager.SpawnedObjectsList[j].observers.Remove(clientId);
				}
			}
			for (int k = 0; k < ConnectedClientsList.Count; k++)
			{
				if (ConnectedClientsList[k].ClientId == clientId)
				{
					ConnectedClientsList.RemoveAt(k);
					break;
				}
			}
			ConnectedClients.Remove(clientId);
		}

		private void SyncTime()
		{
			if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
			{
				NetworkLog.LogInfo("Syncing Time To Clients");
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteSinglePacked(Time.realtimeSinceStartup);
			InternalMessageSender.Send(11, "MLAPI_TIME_SYNC", pooledBitStream, SecuritySendFlags.None, null);
		}

		internal void HandleApproval(ulong clientId, bool createPlayerObject, ulong? playerPrefabHash, bool approved, Vector3? position, Quaternion? rotation)
		{
			if (approved)
			{
				byte[] aesKey = (PendingClients.ContainsKey(clientId) ? PendingClients[clientId].AesKey : null);
				if (PendingClients.ContainsKey(clientId))
				{
					PendingClients.Remove(clientId);
				}
				NetworkedClient networkedClient = new NetworkedClient
				{
					ClientId = clientId,
					AesKey = aesKey
				};
				ConnectedClients.Add(clientId, networkedClient);
				ConnectedClientsList.Add(networkedClient);
				SyncTime();
				if (createPlayerObject)
				{
					NetworkedObject networkedObject = SpawnManager.CreateLocalNetworkedObject(softCreate: false, 0uL, (!playerPrefabHash.HasValue) ? NetworkConfig.PlayerPrefabHash.Value : playerPrefabHash.Value, null, position, rotation);
					SpawnManager.SpawnNetworkedObjectLocally(networkedObject, SpawnManager.GetNetworkObjectId(), sceneObject: false, playerObject: true, clientId, null, readPayload: false, 0, readNetworkedVar: false, destroyWithScene: false);
					ConnectedClients[clientId].PlayerObject = networkedObject;
				}
				_observedObjects.Clear();
				for (int i = 0; i < SpawnManager.SpawnedObjectsList.Count; i++)
				{
					if (clientId == ServerClientId || SpawnManager.SpawnedObjectsList[i].CheckObjectVisibility == null || SpawnManager.SpawnedObjectsList[i].CheckObjectVisibility(clientId))
					{
						_observedObjects.Add(SpawnManager.SpawnedObjectsList[i]);
						SpawnManager.SpawnedObjectsList[i].observers.Add(clientId);
					}
				}
				using (PooledBitStream pooledBitStream = PooledBitStream.Get())
				{
					using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
					pooledBitWriter.WriteUInt64Packed(clientId);
					if (NetworkConfig.EnableSceneManagement)
					{
						pooledBitWriter.WriteUInt32Packed(NetworkSceneManager.currentSceneIndex);
						pooledBitWriter.WriteByteArray(NetworkSceneManager.currentSceneSwitchProgressGuid.ToByteArray(), -1L);
					}
					pooledBitWriter.WriteSinglePacked(Time.realtimeSinceStartup);
					pooledBitWriter.WriteUInt32Packed((uint)_observedObjects.Count);
					for (int j = 0; j < _observedObjects.Count; j++)
					{
						NetworkedObject networkedObject2 = _observedObjects[j];
						pooledBitWriter.WriteBool(networkedObject2.IsPlayerObject);
						pooledBitWriter.WriteUInt64Packed(networkedObject2.NetworkId);
						pooledBitWriter.WriteUInt64Packed(networkedObject2.OwnerClientId);
						NetworkedObject networkedObject3 = null;
						if (!networkedObject2.AlwaysReplicateAsRoot && networkedObject2.transform.parent != null)
						{
							networkedObject3 = networkedObject2.transform.parent.GetComponent<NetworkedObject>();
						}
						if (networkedObject3 == null)
						{
							pooledBitWriter.WriteBool(value: false);
						}
						else
						{
							pooledBitWriter.WriteBool(value: true);
							pooledBitWriter.WriteUInt64Packed(networkedObject3.NetworkId);
						}
						if (!NetworkConfig.EnableSceneManagement || NetworkConfig.UsePrefabSync)
						{
							pooledBitWriter.WriteUInt64Packed(networkedObject2.PrefabHash);
						}
						else
						{
							pooledBitWriter.WriteBool(!networkedObject2.IsSceneObject.HasValue || networkedObject2.IsSceneObject.Value);
							if (!networkedObject2.IsSceneObject.HasValue || networkedObject2.IsSceneObject.Value)
							{
								pooledBitWriter.WriteUInt64Packed(networkedObject2.NetworkedInstanceId);
							}
							else
							{
								pooledBitWriter.WriteUInt64Packed(networkedObject2.PrefabHash);
							}
						}
						if (networkedObject2.IncludeTransformWhenSpawning == null || networkedObject2.IncludeTransformWhenSpawning(clientId))
						{
							pooledBitWriter.WriteBool(value: true);
							pooledBitWriter.WriteSinglePacked(networkedObject2.transform.position.x);
							pooledBitWriter.WriteSinglePacked(networkedObject2.transform.position.y);
							pooledBitWriter.WriteSinglePacked(networkedObject2.transform.position.z);
							pooledBitWriter.WriteSinglePacked(networkedObject2.transform.rotation.eulerAngles.x);
							pooledBitWriter.WriteSinglePacked(networkedObject2.transform.rotation.eulerAngles.y);
							pooledBitWriter.WriteSinglePacked(networkedObject2.transform.rotation.eulerAngles.z);
						}
						else
						{
							pooledBitWriter.WriteBool(value: false);
						}
						if (NetworkConfig.EnableNetworkedVar)
						{
							networkedObject2.WriteNetworkedVarData(pooledBitStream, clientId);
							networkedObject2.WriteSyncedVarData(pooledBitStream, clientId);
						}
					}
					InternalMessageSender.Send(clientId, 4, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.Encrypted | SecuritySendFlags.Authenticated, null);
					if (this.OnClientConnectedCallback != null)
					{
						this.OnClientConnectedCallback(clientId);
					}
				}
				{
					foreach (KeyValuePair<ulong, NetworkedClient> connectedClient in ConnectedClients)
					{
						if (connectedClient.Key == clientId || ConnectedClients[clientId].PlayerObject == null || !ConnectedClients[clientId].PlayerObject.observers.Contains(connectedClient.Key))
						{
							continue;
						}
						using PooledBitStream pooledBitStream2 = PooledBitStream.Get();
						using PooledBitWriter pooledBitWriter2 = PooledBitWriter.Get(pooledBitStream2);
						pooledBitWriter2.WriteBool(value: true);
						pooledBitWriter2.WriteUInt64Packed(ConnectedClients[clientId].PlayerObject.NetworkId);
						pooledBitWriter2.WriteUInt64Packed(clientId);
						pooledBitWriter2.WriteBool(value: false);
						if (!NetworkConfig.EnableSceneManagement || NetworkConfig.UsePrefabSync)
						{
							pooledBitWriter2.WriteUInt64Packed((!playerPrefabHash.HasValue) ? NetworkConfig.PlayerPrefabHash.Value : playerPrefabHash.Value);
						}
						else
						{
							pooledBitWriter2.WriteBool(value: false);
							pooledBitWriter2.WriteUInt64Packed((!playerPrefabHash.HasValue) ? NetworkConfig.PlayerPrefabHash.Value : playerPrefabHash.Value);
						}
						if (ConnectedClients[clientId].PlayerObject.IncludeTransformWhenSpawning == null || ConnectedClients[clientId].PlayerObject.IncludeTransformWhenSpawning(clientId))
						{
							pooledBitWriter2.WriteBool(value: true);
							pooledBitWriter2.WriteSinglePacked(ConnectedClients[clientId].PlayerObject.transform.position.x);
							pooledBitWriter2.WriteSinglePacked(ConnectedClients[clientId].PlayerObject.transform.position.y);
							pooledBitWriter2.WriteSinglePacked(ConnectedClients[clientId].PlayerObject.transform.position.z);
							pooledBitWriter2.WriteSinglePacked(ConnectedClients[clientId].PlayerObject.transform.rotation.eulerAngles.x);
							pooledBitWriter2.WriteSinglePacked(ConnectedClients[clientId].PlayerObject.transform.rotation.eulerAngles.y);
							pooledBitWriter2.WriteSinglePacked(ConnectedClients[clientId].PlayerObject.transform.rotation.eulerAngles.z);
						}
						else
						{
							pooledBitWriter2.WriteBool(value: false);
						}
						pooledBitWriter2.WriteBool(value: false);
						if (NetworkConfig.EnableNetworkedVar)
						{
							ConnectedClients[clientId].PlayerObject.WriteNetworkedVarData(pooledBitStream2, connectedClient.Key);
							ConnectedClients[clientId].PlayerObject.WriteSyncedVarData(pooledBitStream2, connectedClient.Key);
						}
						InternalMessageSender.Send(connectedClient.Key, 5, "MLAPI_INTERNAL", pooledBitStream2, SecuritySendFlags.None, null);
					}
					return;
				}
			}
			if (PendingClients.ContainsKey(clientId))
			{
				PendingClients.Remove(clientId);
			}
			NetworkConfig.NetworkTransport.DisconnectRemoteClient(clientId);
		}
	}
}
