using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PistolProjectile : Projectile
	{
		[SerializeField]
		private ParticleSystem pistolBasicVFX;

		[SerializeField]
		private ParticleSystem pistolTargetingVFX;

		[SerializeField]
		private ParticleEventCall pistolBasicParticleEventCall;

		[SerializeField]
		private ParticleEventCall pistolTargetingParticleEventCall;

		protected EnemyController _targetEnemyController;

		private Timer _prefireTimer;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void setEnemyTarget(EnemyController enemyTarget)
		{
		}

		public void EnableProjectileLaunch()
		{
		}

		public override void Despawn()
		{
		}
	}
}
