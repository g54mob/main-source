using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Combat
{
	public class CollisionLayerManager : BaseSingleton<CollisionLayerManager>
	{
		public LayerMask EnemyWeaponRaycastLayerMask;

		public LayerMask TerrainLayerMask;

		public LayerMask SpawnCheckLayerStructures;

		public LayerMask SpawnCheckLayerEnemyUnits;

		public LayerMask EnemyForceDamageLayer;

		public LayerMask EnemyHealthLayer;

		public LayerMask DronePartHealthLayer;

		public HealthBarDisplay HealthBarPrefab;

		public int EnemyProjectileLayer;

		protected override void Awake()
		{
			base.Awake();
			Object.DontDestroyOnLoad(base.gameObject);
		}

		public bool IsTerrainLayer(int layer)
		{
			return (TerrainLayerMask.value & (1 << layer)) != 0;
		}

		public bool IsLayer(LayerMask mask, int layer)
		{
			return (mask.value & (1 << layer)) != 0;
		}
	}
}
