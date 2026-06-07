using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class InvisibleProjectile_Permanent : Projectile
	{
		private Timer _hitboxTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetBodyRadius(float radius)
		{
		}
	}
}
