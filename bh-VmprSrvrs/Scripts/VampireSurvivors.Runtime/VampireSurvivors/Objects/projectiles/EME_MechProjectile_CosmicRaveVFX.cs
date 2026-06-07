using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MechProjectile_CosmicRaveVFX : Projectile
	{
		[SerializeField]
		private ParticleSystem HitFX;

		private Timer _expireTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
