using System;
using System.Collections.Generic;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events;
using FishNet.Connection;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public interface INetworkFlightObjectManagerServer
	{
		HashSet<int> ObjectSpawnDisabledUniqueIds { get; }

		event EventHandler<ObjectSpawnEnabledStateChangedEventArgs> ObjectSpawnEnabledStateChanged;

		void RegisterSpawner(int spawnerUniqueId, NetworkFlightObjectSpawnerType type, PooledReader data, NetworkConnection clientConnection);

		void Spawn(NetworkFlightObject obj, ArraySegment<byte> initData, IDictionary<string, string> keyValuePairData, int uniqueId, NetworkConnection owner);

		void Spawn(string prefabPath, ArraySegment<byte> initData, IDictionary<string, string> keyValuePairData, int uniqueId, NetworkConnection owner);

		void UnregisterSpawner(int spawnerUniqueId, NetworkConnection clientConnection);
	}
}
