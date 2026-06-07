using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_DragonWater2_Projectile : Projectile
	{
		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetBodyRadius(float radius)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
