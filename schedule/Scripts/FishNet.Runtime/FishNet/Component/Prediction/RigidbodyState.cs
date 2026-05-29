using UnityEngine;

namespace FishNet.Component.Prediction
{
	public struct RigidbodyState
	{
		public uint LocalTick;

		public Vector3 Position;

		public Quaternion Rotation;

		public bool IsKinematic;

		public Vector3 Velocity;

		public Vector3 AngularVelocity;

		public RigidbodyState(Rigidbody rb, bool isKinematic, uint tick)
		{
			LocalTick = 0u;
			Position = default(Vector3);
			Rotation = default(Quaternion);
			IsKinematic = false;
			Velocity = default(Vector3);
			AngularVelocity = default(Vector3);
		}

		public RigidbodyState(Rigidbody rb, uint tick)
		{
			LocalTick = 0u;
			Position = default(Vector3);
			Rotation = default(Quaternion);
			IsKinematic = false;
			Velocity = default(Vector3);
			AngularVelocity = default(Vector3);
		}
	}
}
