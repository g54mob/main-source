using UnityEngine;

namespace Aggro.Core
{
	public struct RigidbodyGroupEntryState
	{
		public Vector3 positionDelta;

		public Vector3 position;

		public Quaternion rotationDelta;

		public Quaternion rotation;

		public Vector3 velocityDelta;

		public Vector3 velocity;

		public Vector3 angularVelocityDelta;

		public Vector3 angularVelocity;

		public Entity entity;

		public static RigidbodyGroupEntryState Interpolate(in RigidbodyGroupEntryState a, in RigidbodyGroupEntryState b, float t)
		{
			return new RigidbodyGroupEntryState
			{
				entity = a.entity,
				position = Vector3.Lerp(a.position, b.position, t),
				rotation = Quaternion.Slerp(a.rotation, b.rotation, t).normalized,
				velocity = Vector3.Lerp(a.velocity, b.velocity, t),
				angularVelocity = Vector3.Lerp(a.angularVelocity, b.angularVelocity, t)
			};
		}
	}
}
