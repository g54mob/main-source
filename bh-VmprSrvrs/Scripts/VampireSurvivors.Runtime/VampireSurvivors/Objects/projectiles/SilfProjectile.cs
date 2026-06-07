using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SilfProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private PhaserSpline _spline;

		private float _totalTime;

		private float _duration;

		private bool _silfActive;

		private MultiTargetTween _hitScaleTween;

		private MultiTargetTween _hitFadeTween;

		private MultiTargetTween _hitFadeTrailTween;

		private MultiTargetTween _fadeInTrailTween;

		protected float _minAngleRotDeg;

		protected float _maxAngleRotDeg;

		protected Vector2 _targetPos;

		protected SilfWeapon _trueWeapon;

		protected float _trailAlpha;

		protected float _startingAlpha;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected virtual PhaserSpline GetSpline()
		{
			return null;
		}

		protected Vector2 RotatePoint(float targetX, float targetY, float angle, Vector2 origin)
		{
			return default(Vector2);
		}

		private void OnHit()
		{
		}

		public override void Despawn()
		{
		}

		private void SetupTrail()
		{
		}

		protected virtual string GetTrailTextureName()
		{
			return null;
		}
	}
}
