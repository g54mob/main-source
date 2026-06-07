using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_FlikTrailProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfxEmitter;

		private bool _expired;

		private float _updateLoops;

		private MultiTargetTween _fadeTrailTween;

		private MultiTargetTween _angleTween;

		private Vector2 _startingPoint;

		public float angleLerp;

		private float _trailTime;

		private EX_FlikTrailWeapon _trueWeapon;

		private EnemyController _enemy;

		private List<Vector3> _trailPositions;

		public void SetEnemy(EnemyController enemy)
		{
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void InitTrail()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		private void FadeOut()
		{
		}

		private Vector2 Rotate_point(float targetX, float targetY, float angle, Vector2 origin)
		{
			return default(Vector2);
		}
	}
}
