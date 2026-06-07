using System;
using Unity.Mathematics;

namespace Assets.Scripts.Flight.Combat.Bullets
{
	public struct Bullet
	{
		public IntPtr BulletData;

		public bool IsNew;

		public float Lifetime;

		public float3 Position;

		public quaternion Rotation;

		public float3 StartPosition;

		public float3 Velocity;
	}
}
