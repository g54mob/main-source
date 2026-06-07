using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PistolProjectile_FalconFire : Projectile
	{
		[SerializeField]
		private ParticleSystem boundingShotVFX;

		[SerializeField]
		private ParticleEventCall boundingShotParticleEventCall;

		private Timer _expireTimer;

		private Timer _despawnTimer;

		private EME_Pistol1Weapon _trueWeapon;

		private bool _hasExploded;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}
	}
}
