using System;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events
{
	public class NetworkFlightObjectSpawnEventArgs : EventArgs
	{
		public NetworkFlightObject Object { get; }

		public NetworkFlightObjectSpawnerClientScript Spawner { get; }

		public int UniqueId { get; }

		public NetworkFlightObjectSpawnEventArgs(int uniqueId, NetworkFlightObject obj, NetworkFlightObjectSpawnerClientScript spawner)
		{
			UniqueId = uniqueId;
			Object = obj;
			Spawner = spawner;
		}
	}
}
