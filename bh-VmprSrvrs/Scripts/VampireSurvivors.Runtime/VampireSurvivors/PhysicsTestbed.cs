using UnityEngine;

namespace VampireSurvivors
{
	public class PhysicsTestbed : MonoBehaviour
	{
		[SerializeField]
		private GameObject _EnemyPrefab;

		public PhysicsGroup Enemies;

		public PhysicsGroup _enemyGroup;

		private static PhysicsTestbed _sInstance;

		public static PhysicsTestbed Instance => null;

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
	}
}
