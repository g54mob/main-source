using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_BladeCrossbowWeapon : FB_QuantisedAngleWeapon
	{
		public override float SecondsToRotateAim360 => 0f;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public EnemyController findEnemyInPlayerDirection(Vector2 pos, float angle, float acceptableAngle = 3.4028235E+38f)
		{
			return null;
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
