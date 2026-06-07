using System.Collections.Generic;
using QFSW.MOP2;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Pools
{
	public class EnemyBulletPool : PhysicsGroup
	{
		private ObjectPool _pool;

		public bool IsUncapped;

		public int UpperLimit;

		private static readonly ProfilerMarker _markerSpawnAt;

		public int AliveObjectsCount => 0;

		public Dictionary<int, GameObject> Spawned => null;

		public EnemyBulletPool(EnemyProjectile projectilePrefab, int capacity = 50)
			: base(0)
		{
		}

		public EnemyProjectile SpawnAt(float x, float y, float2 direction, int index = 0)
		{
			return null;
		}

		public EnemyProjectile SpawnAt(float2 pos, float2 direction, int index = 0)
		{
			return null;
		}

		public void Return(EnemyProjectile projectile)
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
