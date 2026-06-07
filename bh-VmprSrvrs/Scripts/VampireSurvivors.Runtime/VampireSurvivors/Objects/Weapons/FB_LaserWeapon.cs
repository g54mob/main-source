using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_LaserWeapon : Weapon
	{
		public override void CheckArcanas()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
