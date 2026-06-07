using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_SpecialUnlock : EnemyController
	{
		protected List<WeaponType> WeaponsToHitWith;

		protected virtual void OnKilledBySelectedWeapon()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}
	}
}
