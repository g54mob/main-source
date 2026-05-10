using UnityEngine;

namespace GameKit.Utilities.ObjectPooling.Examples
{
	public class Projectile : MonoBehaviour
	{
		[Tooltip("If above 0f projectiles are stored with a delay rather than when off screen.")]
		[Range(0f, 5f)]
		public float DestroyDelay;

		public float MoveRate;

		private ProjectileSpawner _spawner;

		private MeshRenderer[] _renderers;

		private Vector3 _moveDirection;

		private bool _exitingPlayMode;

		private void Awake()
		{
		}

		private void OnBecameInvisible()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
