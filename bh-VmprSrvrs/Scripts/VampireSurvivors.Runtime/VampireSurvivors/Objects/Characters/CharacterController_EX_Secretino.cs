using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterController_EX_Secretino : CharacterController
	{
		private bool _ArcanaGivenLevel1;

		private bool _ArcanaGivenLevel2;

		private bool _ArcanaGivenLevel3;

		public Ex_Magistone2_Weapon Magistone2_Weapon { get; set; }

		public override void AfterFullInitialization()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void LevelUp()
		{
		}

		private void CheckOpenSurvarots()
		{
		}
	}
}
