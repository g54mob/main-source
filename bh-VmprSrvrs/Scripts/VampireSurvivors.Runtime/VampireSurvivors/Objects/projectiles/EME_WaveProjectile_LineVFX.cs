using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_WaveProjectile_LineVFX : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail1;

		private EME_WaveWeapon _trueWeapon;

		private bool _isFirstUpdate;

		private EnemyController _targetEnemy;

		private Vector3 p0;

		private Vector3 p1;

		private Vector3 p2;

		private Vector3 p3;

		private float _elapsedLineTime;

		private float _lineDuration;

		private bool _hasReachedTarget;

		private bool _isDespawning;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetTargetEnemy(EnemyController enemy)
		{
		}

		private void Activate()
		{
		}

		private void LateUpdate()
		{
		}

		private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			return default(Vector3);
		}

		public void OnTargetReached()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
