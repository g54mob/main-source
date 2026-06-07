using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Juste_Character : TP_Character
	{
		private List<WeaponType> spells;

		public override void AfterFullInitialization()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override WeaponType GetFourthLevelUpOption()
		{
			return default(WeaponType);
		}

		public override void LevelUp()
		{
		}
	}
}
