using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Spawners;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners
{
	public abstract class NetworkFlightObjectSpawnerServerScript : MonoBehaviour
	{
		[SerializeField]
		private List<NetworkPlayerScript> _clients;

		[SerializeField]
		private NetworkFlightObjectManager _manager;

		[SerializeField]
		private int _spawnerId;

		[SerializeField]
		private NetworkFlightObjectSpawnerType _type;

		public IReadOnlyList<NetworkPlayerScript> Clients => _clients;

		public NetworkFlightObjectManager Manager => _manager;

		public int SpawnerId => _spawnerId;

		public NetworkFlightObjectSpawnerType Type => _type;

		public static NetworkFlightObjectSpawnerServerScript Create(NetworkFlightObjectManager manager, int spawnerId, NetworkFlightObjectSpawnerType type, PooledReader data)
		{
			Type componentType = type switch
			{
				NetworkFlightObjectSpawnerType.Simple => typeof(SimpleSpawnerServerScript), 
				NetworkFlightObjectSpawnerType.Train => typeof(TrainSpawnerServerScript), 
				_ => throw new NotSupportedException(string.Format("{0}.{1} not supported.", "NetworkFlightObjectSpawnerType", type)), 
			};
			GameObject obj = new GameObject($"{type} Spawner: {spawnerId}");
			obj.transform.SetParent(manager.transform);
			NetworkFlightObjectSpawnerServerScript networkFlightObjectSpawnerServerScript = (NetworkFlightObjectSpawnerServerScript)obj.AddComponent(componentType);
			networkFlightObjectSpawnerServerScript._spawnerId = spawnerId;
			networkFlightObjectSpawnerServerScript._type = type;
			networkFlightObjectSpawnerServerScript._manager = manager;
			networkFlightObjectSpawnerServerScript._clients = new List<NetworkPlayerScript>();
			networkFlightObjectSpawnerServerScript.ReadSpawnerData(data);
			networkFlightObjectSpawnerServerScript.OnInitialized();
			foreach (int objectSpawnDisabledUniqueId in manager.Server.ObjectSpawnDisabledUniqueIds)
			{
				networkFlightObjectSpawnerServerScript.OnObjectSpawnEnabledStateChanged(manager, new ObjectSpawnEnabledStateChangedEventArgs(objectSpawnDisabledUniqueId, enabled: false));
			}
			return networkFlightObjectSpawnerServerScript;
		}

		public void RegisterClient(NetworkPlayerScript client)
		{
			if (_clients.Contains(client))
			{
				Debug.LogError("Error registering client connection for network flight object spawner. Client connection has already been registered.");
			}
			else
			{
				_clients.Add(client);
			}
		}

		public void UnregisterClient(NetworkPlayerScript client, bool logErrorIfNotFound = true)
		{
			if (!_clients.Remove(client) && logErrorIfNotFound)
			{
				Debug.LogError("Error unregistering client connection for network flight object spawner. Client connection does not appear to be registered.");
			}
		}

		public abstract void UpdateSpawner();

		protected List<NetworkPlayerScript> GetClients()
		{
			return _clients;
		}

		protected NetworkPlayerScript GetClosestClientInRange(Vector3 position, float rangeInMetersSquared)
		{
			NetworkPlayerScript result = null;
			float num = float.MaxValue;
			foreach (NetworkPlayerScript client in _clients)
			{
				float sqrMagnitude = (client.FlightScenePlayer.FramePosition - position).sqrMagnitude;
				if (sqrMagnitude <= rangeInMetersSquared && sqrMagnitude < num)
				{
					result = client;
					num = sqrMagnitude;
				}
			}
			return result;
		}

		protected virtual void OnDestroy()
		{
			INetworkFlightObjectManagerServer server = _manager.Server;
			if (server != null)
			{
				server.ObjectSpawnEnabledStateChanged -= OnObjectSpawnEnabledStateChanged;
			}
		}

		protected virtual void OnInitialized()
		{
			_manager.Server.ObjectSpawnEnabledStateChanged += OnObjectSpawnEnabledStateChanged;
		}

		protected virtual void OnObjectSpawnEnabledStateChanged(object sender, ObjectSpawnEnabledStateChangedEventArgs e)
		{
		}

		protected abstract void ReadSpawnerData(PooledReader data);

		protected void ReadSpawnerDataKeyValuePairs(PooledReader reader, IDictionary<string, string> data)
		{
			int num = reader.ReadUInt8Unpacked();
			for (int i = 0; i < num; i++)
			{
				string key = reader.ReadStringAllocated();
				string value = reader.ReadStringAllocated();
				data[key] = value;
			}
		}
	}
}
