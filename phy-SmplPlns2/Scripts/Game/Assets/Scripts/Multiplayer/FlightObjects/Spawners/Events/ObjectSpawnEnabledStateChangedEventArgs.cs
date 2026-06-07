using System;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events
{
	public class ObjectSpawnEnabledStateChangedEventArgs : EventArgs
	{
		public bool Enabled { get; }

		public int ObjectUniqueId { get; }

		public ObjectSpawnEnabledStateChangedEventArgs(int objectUniqueId, bool enabled)
		{
			ObjectUniqueId = objectUniqueId;
			Enabled = enabled;
		}
	}
}
