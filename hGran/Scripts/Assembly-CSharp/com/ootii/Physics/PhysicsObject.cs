using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Physics
{
	public struct PhysicsObject
	{
		public float Mass;

		public Vector3 CenterOfMass;

		public Vector3 Position;

		public Vector3 Velocity;

		private static ObjectPool<PhysicsObject> sPool;

		public static int Length => 0;

		public static PhysicsObject Allocate()
		{
			return default(PhysicsObject);
		}

		public static void Release(PhysicsObject rInstance)
		{
		}
	}
}
