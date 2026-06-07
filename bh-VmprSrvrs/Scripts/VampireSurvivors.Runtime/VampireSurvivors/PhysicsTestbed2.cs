using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors
{
	[DefaultExecutionOrder(1000)]
	public class PhysicsTestbed2 : MonoBehaviour
	{
		[SerializeField]
		private GameObject _EnemyPrefab;

		[SerializeField]
		private GameObject _ProjectilePrefab;

		[SerializeField]
		protected bool _freeze;

		public PhysicsGroup Enemies;

		public PhysicsGroup Projectiles;

		public PhaserTilemap[] _tilemaps;

		private static PhysicsTestbed2 _sInstance;

		private List<ArcadeSprite> _spawned;

		private List<Vector2> _spawnedPositions;

		public static PhysicsTestbed2 Instance => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void InitPhysics()
		{
		}

		private void SpawnEnemies()
		{
		}

		private void SpawnProjectiles()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
