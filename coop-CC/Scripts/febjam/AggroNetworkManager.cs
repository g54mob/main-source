using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AggroNetworkManager : NetworkManager
{
	[Header("Transports")]
	public Transport normalTransport;

	public Transport platformTransport;

	public Transport gdkTransport;

	private static bool _receivedMsg;

	private static NetMsgGameSettings _msg;

	private static bool _suppressDisconnect;

	private static bool _hasSendServerClientMsg;

	private static ObjectQuery<EntityBehaviour> _behaviourQuery;

	private static ObjectQuery<PlayerPosition> _positionQuery;

	private static int _playerSpawned;

	private static List<NetworkConnectionToClient> _orderedConnections;

	private Dictionary<NetworkConnectionToClient, string> _connectedClients = new Dictionary<NetworkConnectionToClient, string>();

	private static List<PlayerPosition> _positions = new List<PlayerPosition>();

	public static bool allowingConnections { get; private set; }

	public static NetworkManagerMode networkMode
	{
		get
		{
			if (NetworkManager.singleton == null)
			{
				return NetworkManagerMode.Offline;
			}
			return NetworkManager.singleton.mode;
		}
	}

	public static bool isSinglePlayer { get; private set; }

	public override void Awake()
	{
		if (!(NetworkManager.singleton != null))
		{
			transport = normalTransport;
			transport.enabled = false;
			base.Awake();
			if (TryGetComponent<NetworkPingDisplay>(out var component))
			{
				component.enabled = false;
			}
		}
	}

	public static void StartHost(NetworkTransportType transportType, ushort port)
	{
		Debug.Log($"[AggroNetworkManager] [StartHost] Starting host with transportType {transportType} and port {port}");
		isSinglePlayer = false;
		allowingConnections = false;
		_hasSendServerClientMsg = false;
		_suppressDisconnect = false;
		_orderedConnections = null;
		NetworkManager.singleton.transport = ((AggroNetworkManager)NetworkManager.singleton).gdkTransport;
		Transport.active = NetworkManager.singleton.transport;
		Debug.Log("[AggroNetworkManager] [StartHost] Selected transport is " + Transport.active.name + " on the " + Transport.active.gameObject.name + " game object");
		if (Transport.active is PortTransport portTransport)
		{
			Debug.Log($"[AggroNetworkManager] [StartHost] Active transport is PortTransport. Port was {portTransport.Port}, setting to {port}.");
			portTransport.Port = port;
		}
		Transport.active.gameObject.SetActive(value: true);
		Transport.active.enabled = true;
		NetworkManager.singleton.StartHost();
		NetworkObjectDatabase.InitializeNetwork();
	}

	public static void StartSinglePlayer()
	{
		NetworkManager.singleton.transport = ((AggroNetworkManager)NetworkManager.singleton).gdkTransport;
		isSinglePlayer = true;
		NetworkServer.listen = false;
		allowingConnections = false;
		_hasSendServerClientMsg = false;
		_suppressDisconnect = false;
		_orderedConnections = null;
		Transport.active.gameObject.SetActive(value: true);
		Transport.active.enabled = true;
		NetworkManager.singleton.StartHost();
		NetworkObjectDatabase.InitializeNetwork();
	}

	public static void EnableHost()
	{
		if (!_hasSendServerClientMsg)
		{
			_hasSendServerClientMsg = true;
			_behaviourQuery = GameUtil.world.entityManager.CreateObjectQuery<EntityBehaviour>();
			_behaviourQuery.Run();
			for (int i = 0; i < _behaviourQuery.count; i++)
			{
				_behaviourQuery[i].ServerClientConnected(NetworkServer.localConnection);
			}
		}
		if (!isSinglePlayer)
		{
			allowingConnections = true;
			Platform.SetLobbyJoinable(isJoinable: true);
		}
	}

	public static void DisableHost()
	{
		allowingConnections = false;
		Platform.SetLobbyJoinable(isJoinable: false);
	}

	public static async Task<ClientConnectionResult> StartClientAsync(NetworkTransportType transportType, string adddress, ushort port)
	{
		Debug.Log($"[AggroNetworkManager] [StartClientAsync] Start client async with {adddress} and {port}.");
		_receivedMsg = false;
		_suppressDisconnect = false;
		try
		{
			NetworkManager.singleton.transport = ((AggroNetworkManager)NetworkManager.singleton).gdkTransport;
			Transport.active = NetworkManager.singleton.transport;
			Debug.Log("[AggroNetworkManager] [StartHost] Selected transport is " + Transport.active.name + " on the " + Transport.active.gameObject.name + " game object");
			if (Transport.active is PortTransport portTransport)
			{
				Debug.Log($"[AggroNetworkManager] [StartClientAsync] Port was {portTransport.Port}, setting to {port}");
				portTransport.Port = port;
			}
			NetworkManager.singleton.networkAddress = adddress;
			Transport.active.gameObject.SetActive(value: true);
			Transport.active.enabled = true;
			NetworkManager.singleton.StartClient();
			NetworkObjectDatabase.InitializeNetwork();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return ClientConnectionResult.Failed();
		}
		while (NetworkClient.isConnecting)
		{
			await Task.Yield();
		}
		if (NetworkClient.isConnected)
		{
			while (!_receivedMsg)
			{
				await Task.Yield();
			}
			if (!Application.isEditor && _msg.versionGuid != Guid.Empty && _msg.versionGuid != AggroUtil.GetBuildGuid())
			{
				return ClientConnectionResult.FailedVersionMismatch();
			}
			NetworkClient.Send(new NetMsgServerPlayerJoined
			{
				playerName = Platform.GetUserName()
			});
			return ClientConnectionResult.Success();
		}
		return ClientConnectionResult.Failed();
	}

	public static void Disconnect()
	{
		isSinglePlayer = false;
		if (NetworkManager.singleton.isNetworkActive)
		{
			_suppressDisconnect = true;
			if (NetworkManager.singleton.mode == NetworkManagerMode.ClientOnly)
			{
				NetworkManager.singleton.StopClient();
			}
			else
			{
				NetworkManager.singleton.StopHost();
			}
		}
	}

	public override void OnServerConnect(NetworkConnectionToClient conn)
	{
		if (!(conn is LocalConnectionToClient))
		{
			if (allowingConnections)
			{
				StartCoroutine(HandleClientConnectCo(conn));
			}
			else
			{
				conn.Disconnect();
			}
		}
	}

	public override void OnServerDisconnect(NetworkConnectionToClient conn)
	{
		NetworkAggroManagerBase<NetworkPlayerManager>.instance?.ServerPlayerLeft(conn);
		foreach (NetworkIdentity item in new List<NetworkIdentity>(conn.owned))
		{
			if (item.TryGetEntity(out var entity))
			{
				entity.behaviour.ServerOwnerDisconnecting();
			}
			if (item.connectionToClient != null && item.connectionToClient.identity != item)
			{
				item.RemoveClientAuthority();
			}
		}
		if (_connectedClients.TryGetValue(conn, out var value))
		{
			_connectedClients.Remove(conn);
			NetworkServer.SendToAll(new NetMsgPlayerLeft
			{
				playerName = value
			});
		}
		if (_orderedConnections != null)
		{
			int num = -1;
			for (int i = 0; i < _orderedConnections.Count; i++)
			{
				if (_orderedConnections[i] == conn)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				_orderedConnections[num] = null;
				if (NetworkAggroManagerBase<LobbyManager>.ManagerExists())
				{
					NetworkAggroManagerBase<LobbyManager>.instance?.ServerDisconnected(conn, num);
				}
			}
		}
		base.OnServerDisconnect(conn);
	}

	public override void OnClientConnect()
	{
	}

	public override void OnClientDisconnect()
	{
		if (!_suppressDisconnect && GameUtil.gameError == GameError.None)
		{
			GameUtil.gameError = GameError.ClientDisconnected;
		}
	}

	public override void OnStartServer()
	{
		NetworkServer.RegisterHandler<NetMsgServerPlayerJoined>(OnServerPlayerJoined);
	}

	public override void OnStartClient()
	{
		NetworkClient.RegisterHandler<NetMsgGameSettings>(OnGameSettingsMsg);
		NetworkClient.RegisterHandler<NetMsgPlayerJoined>(OnPlayerJoined);
		NetworkClient.RegisterHandler<NetMsgPlayerLeft>(OnPlayerLeft);
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		NetworkClient.UnregisterHandler<NetMsgGameSettings>();
		NetworkClient.UnregisterHandler<NetMsgPlayerJoined>();
		NetworkClient.UnregisterHandler<NetMsgPlayerLeft>();
		NetworkServer.UnregisterHandler<NetMsgServerPlayerJoined>();
	}

	private void OnServerPlayerJoined(NetworkConnectionToClient conn, NetMsgServerPlayerJoined msg)
	{
		_connectedClients[conn] = msg.playerName;
		NetMsgPlayerJoined message = new NetMsgPlayerJoined
		{
			playerName = msg.playerName
		};
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			if (connection.Value != conn)
			{
				connection.Value.Send(message);
			}
		}
	}

	private void OnGameSettingsMsg(NetMsgGameSettings msg)
	{
		_receivedMsg = true;
		_msg = msg;
	}

	private void OnPlayerJoined(NetMsgPlayerJoined msg)
	{
		if (GameUtil.isReady)
		{
			EvPlayerJoined ev = new EvPlayerJoined
			{
				playerName = msg.playerName
			};
			GameUtil.world.eventManager.QueueGlobalEvent(ev);
		}
	}

	private void OnPlayerLeft(NetMsgPlayerLeft msg)
	{
		if (GameUtil.isReady)
		{
			EvPlayerLeft ev = new EvPlayerLeft
			{
				playerName = msg.playerName
			};
			GameUtil.world.eventManager.QueueGlobalEvent(ev);
		}
	}

	private IEnumerator HandleClientConnectCo(NetworkConnectionToClient conn)
	{
		if (!(conn is LocalConnectionToClient))
		{
			conn.Send(new NetMsgGameSettings
			{
				versionGuid = AggroUtil.GetBuildGuid()
			});
		}
		while (!conn.isReady)
		{
			yield return null;
		}
		_behaviourQuery.Run();
		for (int i = 0; i < _behaviourQuery.count; i++)
		{
			_behaviourQuery[i].ServerClientConnected(conn);
		}
		int num = -1;
		for (int j = 0; j < _orderedConnections.Count; j++)
		{
			if (_orderedConnections[j] == null)
			{
				num = j;
				break;
			}
		}
		if (num < 0)
		{
			num = _orderedConnections.Count;
			_orderedConnections.Add(null);
		}
		_orderedConnections[num] = conn;
		NetworkAggroManagerBase<LobbyManager>.instance.ServerAddPlayer(conn, num);
		NetworkAggroManagerBase<NetworkPlayerManager>.instance.ServerPlayerJoined(conn);
	}

	public static void SetCurrentLobbyPlayers()
	{
		if (_orderedConnections == null)
		{
			_orderedConnections = new List<NetworkConnectionToClient>(NetworkServer.connections.Values);
		}
		for (int i = 0; i < _orderedConnections.Count; i++)
		{
			NetworkConnectionToClient networkConnectionToClient = _orderedConnections[i];
			if (networkConnectionToClient != null)
			{
				NetworkAggroManagerBase<LobbyManager>.instance.ServerAddPlayer(networkConnectionToClient, i);
			}
		}
	}

	public static void RemoveCurrentLocalPlayers()
	{
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			NetworkServer.RemovePlayerForConnection(connection.Value, RemovePlayerOptions.Destroy);
		}
	}

	public static void SpawnPlayers()
	{
		foreach (KeyValuePair<int, NetworkConnectionToClient> connection in NetworkServer.connections)
		{
			GameObject gameObject = ServerGetSpawnedPlayer();
			NetworkServer.AddPlayerForConnection(connection.Value, gameObject);
			gameObject.GetComponent<NetworkTransformBase>().ServerTeleport(gameObject.transform.position, gameObject.transform.rotation);
		}
	}

	private static GameObject ServerGetSpawnedPlayer()
	{
		Vector3 position = Vector3.zero;
		Quaternion rotation = Quaternion.identity;
		RoomType type = ((!GameUtil.isTutorial && !GameUtil.isGym) ? RoomType.BreakRoom : RoomType.Warehouse);
		if (_positionQuery == null || !_positionQuery.isValid)
		{
			_positionQuery = GameUtil.entityManager.CreateObjectQuery<PlayerPosition>();
		}
		_positionQuery.Run();
		_positionQuery.SortEntities();
		_positions.Clear();
		for (int i = 0; i < _positionQuery.count; i++)
		{
			PlayerPosition playerPosition = _positionQuery[i];
			if (playerPosition.Evaluate(type))
			{
				_positions.Add(playerPosition);
			}
		}
		if (_positions.Count > 0)
		{
			Transform obj = _positions[_playerSpawned++ % _positions.Count].transform;
			position = obj.position;
			rotation = obj.rotation;
		}
		position.y = 0f;
		GameObject obj2 = UnityEngine.Object.Instantiate(NetworkManager.singleton.playerPrefab);
		obj2.transform.position = position;
		obj2.transform.rotation = rotation;
		Rigidbody component = obj2.GetComponent<Rigidbody>();
		component.position = position;
		component.rotation = rotation;
		SceneManager.MoveGameObjectToScene(obj2, SceneManager.GetSceneByName("scene-game"));
		return obj2;
	}
}
