using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_AlucardSword2_Weapon : Weapon
	{
		private const int MaxGhostsPerFire = 6;

		private int _totalOtherEvos;

		private int _fireCounter;

		public int NumOtherEvos => 0;

		public int ModFireCounter => 0;

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		private void CheckOtherEvos()
		{
		}
	}
}
