namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerPavone : CharacterController
	{
		public override bool NeedsCart => false;

		public override void LevelUp()
		{
		}

		public override void Revive(float percentage = 1f, bool instantRevival = false)
		{
		}
	}
}
