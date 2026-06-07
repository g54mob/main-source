using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public static class NetworkServer
	{
		private struct Serialization
		{
			public PooledNetworkWriter ownerWriter;

			public PooledNetworkWriter observersWriter;

			public int ownerWritten;

			public int observersWritten;
		}

		private static bool initialized;

		public static int maxConnections;

		public static Dictionary<int, NetworkConnectionToClient> connections;

		private static Dictionary<int, NetworkMessageDelegate> handlers;

		public static bool dontListen;

		public static bool batching;

		public static float batchInterval;

		public static InterestManagement aoi;

		public static bool disconnectInactiveConnections;

		public static float disconnectInactiveTimeout;

		internal static Action<NetworkConnection> OnConnectedEvent;

		internal static Action<NetworkConnection> OnDisconnectedEvent;

		private static readonly HashSet<NetworkConnection> newObservers;

		private static Dictionary<NetworkIdentity, Serialization> serializations;

		public static NetworkConnectionToClient localConnection { get; private set; }

		public static bool localClientActive => false;

		public static bool active { get; internal set; }

		private static void Initialize()
		{
		}

		private static void AddTransportHandlers()
		{
		}

		public static void ActivateHostScene()
		{
		}

		internal static void RegisterMessageHandlers()
		{
		}

		public static void Listen(int maxConns)
		{
		}

		private static void CleanupNetworkIdentities()
		{
		}

		public static void Shutdown()
		{
		}

		public static bool AddConnection(NetworkConnectionToClient conn)
		{
			return false;
		}

		public static bool RemoveConnection(int connectionId)
		{
			return false;
		}

		internal static void SetLocalConnection(LocalConnectionToClient conn)
		{
		}

		internal static void RemoveLocalConnection()
		{
		}

		public static bool NoExternalConnections()
		{
			return false;
		}

		[Obsolete]
		public static bool NoConnections()
		{
			return false;
		}

		public static void SendToAll<T>(T message, int channelId = 0, bool sendToReadyOnly = false) where T : struct, NetworkMessage
		{
		}

		public static void SendToReady<T>(T message, int channelId = 0) where T : struct, NetworkMessage
		{
		}

		public static void SendToReady<T>(NetworkIdentity identity, T message, bool includeOwner = true, int channelId = 0) where T : struct, NetworkMessage
		{
		}

		public static void SendToReady<T>(NetworkIdentity identity, T message, int channelId) where T : struct, NetworkMessage
		{
		}

		private static void SendToObservers<T>(NetworkIdentity identity, T message, int channelId = 0) where T : struct, NetworkMessage
		{
		}

		[Obsolete]
		public static void SendToClientOfPlayer<T>(NetworkIdentity identity, T msg, int channelId = 0) where T : struct, NetworkMessage
		{
		}

		private static void OnConnected(int connectionId)
		{
		}

		internal static void OnConnected(NetworkConnectionToClient conn)
		{
		}

		private static void OnDataReceived(int connectionId, ArraySegment<byte> data, int channelId)
		{
		}

		internal static void OnDisconnected(int connectionId)
		{
		}

		private static void OnDisconnected(NetworkConnection conn)
		{
		}

		private static void OnError(int connectionId, Exception exception)
		{
		}

		public static void RegisterHandler<T>(Action<NetworkConnection, T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		[Obsolete]
		public static void RegisterHandler<T>(Action<T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		public static void ReplaceHandler<T>(Action<NetworkConnection, T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		public static void ReplaceHandler<T>(Action<T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		public static void UnregisterHandler<T>() where T : struct, NetworkMessage
		{
		}

		public static void ClearHandlers()
		{
		}

		internal static bool GetNetworkIdentity(GameObject go, out NetworkIdentity identity)
		{
			identity = null;
			return false;
		}

		public static void DisconnectAll()
		{
		}

		public static void DisconnectAllExternalConnections()
		{
		}

		[Obsolete]
		public static void DisconnectAllConnections()
		{
		}

		public static bool AddPlayerForConnection(NetworkConnection conn, GameObject player)
		{
			return false;
		}

		public static bool AddPlayerForConnection(NetworkConnection conn, GameObject player, Guid assetId)
		{
			return false;
		}

		public static bool ReplacePlayerForConnection(NetworkConnection conn, GameObject player, bool keepAuthority = false)
		{
			return false;
		}

		public static bool ReplacePlayerForConnection(NetworkConnection conn, GameObject player, Guid assetId, bool keepAuthority = false)
		{
			return false;
		}

		public static void SetClientReady(NetworkConnection conn)
		{
		}

		public static void SetClientNotReady(NetworkConnection conn)
		{
		}

		public static void SetAllClientsNotReady()
		{
		}

		private static void OnClientReadyMessage(NetworkConnection conn, ReadyMessage msg)
		{
		}

		internal static void ShowForConnection(NetworkIdentity identity, NetworkConnection conn)
		{
		}

		internal static void HideForConnection(NetworkIdentity identity, NetworkConnection conn)
		{
		}

		public static void RemovePlayerForConnection(NetworkConnection conn, bool destroyServerObject)
		{
		}

		private static void OnCommandMessage(NetworkConnection conn, CommandMessage msg)
		{
		}

		private static ArraySegment<byte> CreateSpawnMessagePayload(bool isOwner, NetworkIdentity identity, PooledNetworkWriter ownerWriter, PooledNetworkWriter observersWriter)
		{
			return default(ArraySegment<byte>);
		}

		internal static void SendSpawnMessage(NetworkIdentity identity, NetworkConnection conn)
		{
		}

		private static void SpawnObject(GameObject obj, NetworkConnection ownerConnection)
		{
		}

		public static void Spawn(GameObject obj, NetworkConnection ownerConnection = null)
		{
		}

		public static void Spawn(GameObject obj, GameObject ownerPlayer)
		{
		}

		public static void Spawn(GameObject obj, Guid assetId, NetworkConnection ownerConnection = null)
		{
		}

		internal static bool ValidateSceneObject(NetworkIdentity identity)
		{
			return false;
		}

		public static bool SpawnObjects()
		{
			return false;
		}

		private static void Respawn(NetworkIdentity identity)
		{
		}

		private static void SpawnObserversForConnection(NetworkConnection conn)
		{
		}

		public static void UnSpawn(GameObject obj)
		{
		}

		public static void DestroyPlayerForConnection(NetworkConnection conn)
		{
		}

		private static void DestroyObject(NetworkIdentity identity, bool destroyServerObject)
		{
		}

		private static void DestroyObject(GameObject obj, bool destroyServerObject)
		{
		}

		public static void Destroy(GameObject obj)
		{
		}

		internal static void AddAllReadyServerConnectionsToObservers(NetworkIdentity identity)
		{
		}

		private static void RebuildObserversDefault(NetworkIdentity identity, bool initialize)
		{
		}

		private static void RebuildObserversCustom(NetworkIdentity identity, bool initialize)
		{
		}

		public static void RebuildObservers(NetworkIdentity identity, bool initialize)
		{
		}

		internal static void NetworkEarlyUpdate()
		{
		}

		internal static void NetworkLateUpdate()
		{
		}

		[Obsolete]
		public static void Update()
		{
		}
	}
}
