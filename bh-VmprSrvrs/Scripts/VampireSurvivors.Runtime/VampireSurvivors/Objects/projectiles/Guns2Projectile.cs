using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Guns2Projectile : GunsProjectile
	{
		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable target)
		{
		}

		private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
		{
		}
	}
}
