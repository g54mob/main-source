namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerAvatar : CharacterController
	{
		public override bool NeedsCart => false;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		protected override void OnStop()
		{
		}
	}
}
