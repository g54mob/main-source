using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Dmitri_Character : TP_Character
	{
		private Weapon lastClonedWeapon;

		private WeaponType lastClonedWeaponType;

		private List<WeaponType> invalidClones;

		public override void LevelUp()
		{
		}

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}
	}
}
