using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Guns3Projectile : Projectile
	{
		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetTarget(double ang)
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}
	}
}
