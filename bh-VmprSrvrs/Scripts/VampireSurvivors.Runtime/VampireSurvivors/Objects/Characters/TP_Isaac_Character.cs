using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Isaac_Character : CharacterController
	{
		private int _followers;

		private List<CharacterType> possibleFollowers;

		private List<CharacterType> currentFollowers;

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
