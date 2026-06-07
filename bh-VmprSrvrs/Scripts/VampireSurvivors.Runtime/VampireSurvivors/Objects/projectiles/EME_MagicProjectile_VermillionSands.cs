using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MagicProjectile_VermillionSands : Projectile
	{
		[SerializeField]
		protected ParticleSystem _particleSystem;

		[SerializeField]
		protected ParticleEventCall _particleEventCall;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _alphaTween;

		private Timer _hitboxTimer;

		private MultiTargetTween _moveTween;

		private Timer _movementTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void GoToNearestEnemy()
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
