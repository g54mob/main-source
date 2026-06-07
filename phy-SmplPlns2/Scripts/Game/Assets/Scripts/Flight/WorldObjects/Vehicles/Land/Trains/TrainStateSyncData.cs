using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public readonly struct TrainStateSyncData
	{
		public readonly Vector3 FloatingOriginOffset;

		public readonly float PhysicsTimeElapsedLocal;

		public readonly float PhysicsTimeElapsedRemote;

		public readonly float PhysicsTimeRemote;

		public TrainStateSyncData(Vector3 floatingOriginOffset, float physicsTimeRemote, float physicsTimeElapsedRemote, float physicsTimeElapsedLocal)
		{
			FloatingOriginOffset = floatingOriginOffset;
			PhysicsTimeRemote = physicsTimeRemote;
			PhysicsTimeElapsedRemote = physicsTimeElapsedRemote;
			PhysicsTimeElapsedLocal = physicsTimeElapsedLocal;
		}
	}
}
