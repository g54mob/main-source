using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Frog2_Projectile : Projectile
	{
		private TP_Frog2_Weapon _trueWeapon;

		private Timer _expireTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
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
