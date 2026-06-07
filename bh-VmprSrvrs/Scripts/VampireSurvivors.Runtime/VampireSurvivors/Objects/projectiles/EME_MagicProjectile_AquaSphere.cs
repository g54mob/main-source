using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MagicProjectile_AquaSphere : Projectile
	{
		[SerializeField]
		protected ParticleSystem _particleSystem;

		[SerializeField]
		protected ParticleEventCall _particleEventCall;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _alphaTween;

		private Timer _hitboxTimer;

		private MultiTargetTween _moveTween;

		private Tween _angleTween;

		private Tween _scaleTween;

		private float _saveVelX;

		private float _saveVelY;

		private Timer _bounceTimer;

		private bool _canBounce;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
		{
		}

		public override void Despawn()
		{
		}

		private void DespawnAfterParticlesToFinish()
		{
		}
	}
}
