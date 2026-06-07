using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PistolProjectile_FalconFireExplosion : Projectile
	{
		[SerializeField]
		private ParticleSystem explosionVFX;

		private Timer _expireTimer;

		private Timer _damageTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void StopDamage()
		{
		}

		public override void Despawn()
		{
		}
	}
}
