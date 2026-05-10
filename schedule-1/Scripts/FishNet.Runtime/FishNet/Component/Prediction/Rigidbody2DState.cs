using UnityEngine;

namespace FishNet.Component.Prediction
{
	public struct Rigidbody2DState
	{
		public uint LocalTick;

		public Vector3 Position;

		public Quaternion Rotation;

		public Vector2 Velocity;

		public float AngularVelocity;

		public bool Simulated;

		public bool IsKinematic;

		public Rigidbody2DState(Rigidbody2D rb, bool simulated, uint tick)
		{
			LocalTick = 0u;
			Position = default(Vector3);
			Rotation = default(Quaternion);
			Velocity = default(Vector2);
			AngularVelocity = 0f;
			Simulated = false;
			IsKinematic = false;
		}

		public Rigidbody2DState(Rigidbody2D rb, uint tick)
		{
			LocalTick = 0u;
			Position = default(Vector3);
			Rotation = default(Quaternion);
			Velocity = default(Vector2);
			AngularVelocity = 0f;
			Simulated = false;
			IsKinematic = false;
		}
	}
}
