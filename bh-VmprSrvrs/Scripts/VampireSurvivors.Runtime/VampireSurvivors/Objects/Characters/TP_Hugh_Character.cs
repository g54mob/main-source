using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Hugh_Character : TP_Character
	{
		private List<WeaponType> adeptWeapons;

		public override void AfterFullInitialization()
		{
		}

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}

		public override WeaponType GetFourthLevelUpOption()
		{
			return default(WeaponType);
		}
	}
}
