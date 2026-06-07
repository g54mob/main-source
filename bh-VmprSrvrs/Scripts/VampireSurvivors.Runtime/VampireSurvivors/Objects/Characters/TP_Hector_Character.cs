using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Hector_Character : CharacterController
	{
		private List<CharacterType> possibleFollowers;

		private List<CharacterType> currentFollowers;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override WeaponType GetFourthLevelUpOption()
		{
			return default(WeaponType);
		}

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		private void AddRandomFollower()
		{
		}
	}
}
