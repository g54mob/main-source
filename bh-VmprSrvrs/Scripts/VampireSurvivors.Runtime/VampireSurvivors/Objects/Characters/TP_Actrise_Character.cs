using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Actrise_Character : TP_Character
	{
		private float _baseWeaponPower;

		private List<WeaponType> adeptSpells;

		public TP_Earth2_Weapon StartingWeapon { get; set; }

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}

		public override void LevelUp()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		public void ShowIcons()
		{
		}
	}
}
