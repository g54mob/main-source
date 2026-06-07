using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Wind1_Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private Vector2 _initialVel;

		private float _startingAngle;

		private float GravX;

		private float GravY;

		private float _bodyRadius;

		private float _spriteSize;

		protected float[] _firingAngles;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeInTrailTween;

		protected float _trailAlpha;

		private bool _mirrored;

		private bool _flip;

		private Sequence _windSequence;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetFlip(bool __flip)
		{
		}

		private void StartDespawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		private float UpdateTrailAlpha()
		{
			return 0f;
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void SetupTrail()
		{
		}
	}
}
