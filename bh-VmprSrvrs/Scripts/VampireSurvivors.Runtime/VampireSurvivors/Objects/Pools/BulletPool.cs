using System.Collections.Generic;
using QFSW.MOP2;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Pools
{
	public class BulletPool : PhysicsGroup
	{
		private ObjectPool _pool;

		public bool IsUncapped;

		public int UpperLimit;

		private static readonly ProfilerMarker _markerSpawnAt;

		public int AliveObjectsCount => 0;

		public Dictionary<int, GameObject> Spawned => null;

		public BulletPool(Projectile projectilePrefab, int capacity = 50)
			: base(0)
		{
		}

		public Projectile SpawnAt(float x, float y, Weapon weapon, int index = 0)
		{
			return null;
		}

		public Projectile SpawnAt(float2 pos, Weapon weapon, int index = 0)
		{
			return null;
		}

		public void Return(Projectile projectile)
		{
		}

		public void Cleanup()
		{
		}

		public void Destroy()
		{
		}
	}
}
