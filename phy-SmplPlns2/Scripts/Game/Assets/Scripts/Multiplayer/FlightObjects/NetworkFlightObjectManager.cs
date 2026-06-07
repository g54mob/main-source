using System;
using System.Collections.Generic;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events;
using FishNet.Connection;
using FishNet.Serializing;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	[Serializable]
	public class NetworkFlightObjectManager : MonoBehaviour, INetworkFlightObjectManagerServer
	{
		private static class Profile
		{
			public static readonly ProfilerMarker OnPostTickServer = new ProfilerMarker("NetworkFlightObjectManager.OnPostTickServer");
		}

		private static Dictionary<int, string> _uniqueIdMap = new Dictionary<int, string>();

		private FlightSceneNetworkScript _flightSceneNetwork;

		private bool _isServer;

		[SerializeField]
		private List<NetworkFlightObject> _objects;

		private HashSet<int> _objectSpawnDisabledUniqueIds;

		[SerializeField]
		private List<NetworkFlightObjectSpawnerServerScript> _spawners;

		public FlightSceneNetworkScript FlightSceneNetwork => _flightSceneNetwork;

		HashSet<int> INetworkFlightObjectManagerServer.ObjectSpawnDisabledUniqueIds => _objectSpawnDisabledUniqueIds;

		public INetworkFlightObjectManagerServer Server
		{
			get
			{
				if (!_isServer)
				{
					throw new InvalidOperationException("The INetworkFlightObjectManagerServer API is only accessible on the server.");
				}
				return this;
			}
		}

		public event EventHandler<NetworkFlightObjectEventArgs> ObjectDespawned;

		public event EventHandler<NetworkFlightObjectEventArgs> ObjectSpawned;

		event EventHandler<ObjectSpawnEnabledStateChangedEventArgs> INetworkFlightObjectManagerServer.ObjectSpawnEnabledStateChanged
		{
			add
			{
				_objectSpawnEnabledStateChanged += value;
			}
			remove
			{
				_objectSpawnEnabledStateChanged -= value;
			}
		}

		public event EventHandler<NetworkFlightObjectEventArgs> ObjectSpawning;

		private event EventHandler<ObjectSpawnEnabledStateChangedEventArgs> _objectSpawnEnabledStateChanged;

		public static NetworkFlightObjectManager Create(FlightSceneNetworkScript flightSceneNetworkScript)
		{
			GameObject obj = new GameObject("NetworkFlightObjectManager");
			obj.transform.SetParent(flightSceneNetworkScript.transform, worldPositionStays: false);
			NetworkFlightObjectManager networkFlightObjectManager = obj.AddComponent<NetworkFlightObjectManager>();
			networkFlightObjectManager.Initialize(flightSceneNetworkScript);
			return networkFlightObjectManager;
		}

		public NetworkFlightObject GetFlightObjectByID(int uniqueID)
		{
			foreach (NetworkFlightObject @object in _objects)
			{
				if (@object.UniqueID == uniqueID)
				{
					return @object;
				}
			}
			return null;
		}

		public int GetUniqueId(string id)
		{
			int stableHashCode = StringUtility.GetStableHashCode(id);
			if (Device.IsUnityEditor)
			{
				if (_uniqueIdMap.TryGetValue(stableHashCode, out var value))
				{
					if (id != value)
					{
						Debug.LogError($"Hash collision with NetworkFlightObject unique ids. ID '{stableHashCode}' is mapped to both '{id}' and '{value}'");
					}
				}
				else
				{
					_uniqueIdMap[stableHashCode] = id;
				}
			}
			return stableHashCode;
		}

		public void OnObjectDespawned(NetworkFlightObject obj)
		{
			if (_objects.Remove(obj))
			{
				this.ObjectDespawned?.Invoke(this, new NetworkFlightObjectEventArgs(obj));
			}
		}

		public void OnObjectSpawned(NetworkFlightObject obj)
		{
			this.ObjectSpawned?.Invoke(this, new NetworkFlightObjectEventArgs(obj));
		}

		public void OnObjectSpawning(NetworkFlightObject obj)
		{
			if (obj.UniqueID != 0 && (object)GetFlightObjectByID(obj.UniqueID) != null)
			{
				Debug.LogError("A network flight object is being registered with the manager when an " + $"existing object with the same id '{obj.UniqueID}' is already registered.");
			}
			_objects.Add(obj);
			this.ObjectSpawning?.Invoke(this, new NetworkFlightObjectEventArgs(obj));
		}

		void INetworkFlightObjectManagerServer.RegisterSpawner(int spawnerUniqueId, NetworkFlightObjectSpawnerType type, PooledReader data, NetworkConnection clientConnection)
		{
			if (!_isServer)
			{
				Debug.LogError("NetworkFlightObjectManager.RegisterSpawner may only be called on the server.");
				return;
			}
			NetworkPlayerScript player = clientConnection.GetPlayer();
			if (player == null)
			{
				Debug.LogError("NetworkFlightObjectManager.RegisterSpawner could not find the player associated with the network connection.");
				return;
			}
			NetworkFlightObjectSpawnerServerScript networkFlightObjectSpawnerServerScript = GetSpawnerById(spawnerUniqueId);
			if (networkFlightObjectSpawnerServerScript == null)
			{
				if ((object)networkFlightObjectSpawnerServerScript != null)
				{
					Debug.LogError($"A dead network flight object spawner was found when attempting to register a spawner with id '{spawnerUniqueId}'.");
					_spawners.Remove(networkFlightObjectSpawnerServerScript);
				}
				networkFlightObjectSpawnerServerScript = NetworkFlightObjectSpawnerServerScript.Create(this, spawnerUniqueId, type, data);
				_spawners.Add(networkFlightObjectSpawnerServerScript);
			}
			networkFlightObjectSpawnerServerScript.RegisterClient(player);
		}

		public void SetObjectSpawnEnabledState(int objectId, bool enabled)
		{
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _flightSceneNetwork.GetPooledWriter();
			pooledWriterDisposableWrapper.Writer.WriteInt32(objectId);
			pooledWriterDisposableWrapper.Writer.WriteBoolean(enabled);
			if (_isServer)
			{
				OnSetObjectSpawnEnabledRpc(pooledWriterDisposableWrapper.GetData(), _flightSceneNetwork.LocalConnection);
			}
			else
			{
				_flightSceneNetwork.SendServerRpc(FlightSceneServerRpcType.FlightObjectManager_SetObjectSpawnEnabledState, pooledWriterDisposableWrapper.GetData());
			}
		}

		void INetworkFlightObjectManagerServer.Spawn(NetworkFlightObject obj, ArraySegment<byte> initData, IDictionary<string, string> keyValuePairData, int uniqueID, NetworkConnection owner)
		{
			obj.ServerInitialize(initData, keyValuePairData, uniqueID);
			_flightSceneNetwork.ServerManager.Spawn(obj.gameObject, owner);
		}

		void INetworkFlightObjectManagerServer.Spawn(string prefabPath, ArraySegment<byte> initData, IDictionary<string, string> keyValuePairData, int uniqueID, NetworkConnection owner)
		{
			if (uniqueID != 0 && GetFlightObjectByID(uniqueID) != null)
			{
				Debug.Log($"Did not spawn {prefabPath} with unique ID {uniqueID} because it's already been spawned");
				return;
			}
			NetworkFlightObject obj = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkFlightObject>(prefabPath);
			Server.Spawn(obj, initData, keyValuePairData, uniqueID, owner);
		}

		void INetworkFlightObjectManagerServer.UnregisterSpawner(int spawnerUniqueId, NetworkConnection clientConnection)
		{
			if (!_isServer)
			{
				Debug.LogError("NetworkFlightObjectManager.UnregisterSpawner may only be called on the server.");
				return;
			}
			NetworkPlayerScript player = clientConnection.GetPlayer();
			if (player == null)
			{
				Debug.LogError("NetworkFlightObjectManager.RegisterSpawner could not find the player associated with the network connection.");
				return;
			}
			NetworkFlightObjectSpawnerServerScript spawnerById = GetSpawnerById(spawnerUniqueId);
			if ((object)spawnerById == null)
			{
				Debug.LogError($"Unable to unregister network flight object spawner because a spawner with id '{spawnerUniqueId}' could not be found.");
			}
			else
			{
				UnregisterSpawnerClient(spawnerById, player, logErrorIfNotFound: true);
			}
		}

		protected virtual void OnDestroy()
		{
			if (_isServer)
			{
				if (_flightSceneNetwork?.TimeManager != null)
				{
					_flightSceneNetwork.TimeManager.OnPostTick -= OnPostTickServer;
				}
				Game.Instance.NetworkGameManager.PlayerLeft -= OnPlayerLeft;
			}
		}

		private NetworkFlightObjectSpawnerServerScript GetSpawnerById(int id)
		{
			foreach (NetworkFlightObjectSpawnerServerScript spawner in _spawners)
			{
				if (spawner.SpawnerId == id)
				{
					return spawner;
				}
			}
			return null;
		}

		private void Initialize(FlightSceneNetworkScript flightSceneNetworkScript)
		{
			_flightSceneNetwork = flightSceneNetworkScript;
			_objects = new List<NetworkFlightObject>();
			_spawners = new List<NetworkFlightObjectSpawnerServerScript>();
			_objectSpawnDisabledUniqueIds = new HashSet<int>();
			_flightSceneNetwork.SubscribeToServerRpc(FlightSceneServerRpcType.FlightObjectManager_SetObjectSpawnEnabledState, OnSetObjectSpawnEnabledRpc);
			if (_flightSceneNetwork.IsClientStarted)
			{
				OnClientStarted();
			}
			else
			{
				_flightSceneNetwork.ClientStarted += OnClientStarted;
			}
		}

		private void OnClientStarted()
		{
			if (_flightSceneNetwork.IsServerInitialized)
			{
				_isServer = true;
				_flightSceneNetwork.TimeManager.OnPostTick += OnPostTickServer;
				Game.Instance.NetworkGameManager.PlayerLeft += OnPlayerLeft;
			}
		}

		private void OnPlayerLeft(object sender, NetworkPlayerEventArgs e)
		{
			if (!e.Player.IsNPC)
			{
				NetworkPlayerScript player = e.Player;
				for (int num = _spawners.Count - 1; num >= 0; num--)
				{
					NetworkFlightObjectSpawnerServerScript spawner = _spawners[num];
					UnregisterSpawnerClient(spawner, player, logErrorIfNotFound: false);
				}
			}
		}

		private void OnPostTickServer()
		{
			using (Profile.OnPostTickServer.Auto())
			{
				foreach (NetworkFlightObjectSpawnerServerScript spawner in _spawners)
				{
					spawner.UpdateSpawner();
				}
			}
		}

		private void OnSetObjectSpawnEnabledRpc(ArraySegment<byte> data, NetworkConnection sender)
		{
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = _flightSceneNetwork.GetPooledReader(data);
			int num = pooledReaderDisposableWrapper.Reader.ReadInt32();
			bool flag = pooledReaderDisposableWrapper.Reader.ReadBoolean();
			if (flag ? _objectSpawnDisabledUniqueIds.Remove(num) : _objectSpawnDisabledUniqueIds.Add(num))
			{
				this._objectSpawnEnabledStateChanged?.Invoke(this, new ObjectSpawnEnabledStateChangedEventArgs(num, flag));
			}
		}

		private void UnregisterSpawnerClient(NetworkFlightObjectSpawnerServerScript spawner, NetworkPlayerScript client, bool logErrorIfNotFound)
		{
			spawner.UnregisterClient(client, logErrorIfNotFound);
			if (spawner.Clients.Count == 0)
			{
				_spawners.Remove(spawner);
				if (spawner != null && spawner.gameObject != null)
				{
					UnityEngine.Object.Destroy(spawner.gameObject);
				}
			}
		}
	}
}
