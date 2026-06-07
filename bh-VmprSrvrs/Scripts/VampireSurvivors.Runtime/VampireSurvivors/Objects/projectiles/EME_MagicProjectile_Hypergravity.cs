using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MagicProjectile_Hypergravity : Projectile
	{
		[SerializeField]
		protected ParticleSystem _particleSystem;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _alphaTween;

		private Timer _hitboxTimer;

		private MultiTargetTween _moveTween;

		private Transform target;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void FadeOut()
		{
		}

		private void HitEnemies()
		{
		}

		private void LateUpdate()
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
