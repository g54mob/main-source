namespace VampireSurvivors.Objects.Characters
{
	public class LEM_CharacterController_004 : LEM_CharacterController_Base
	{
		private int skippedTimes;

		public override bool StartWithSurvarotDraft => false;

		public override void AfterFullInitialization()
		{
		}

		public override void OnLevelUpSkipped()
		{
		}
	}
}
