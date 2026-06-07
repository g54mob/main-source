using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MedicalScan2Projectile : MedicalScanProjectile
	{
		private Dictionary<WeaponType, float> _bonusList;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void ApplyScanEffect()
		{
		}
	}
}
