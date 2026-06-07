namespace VampireSurvivors.Objects.Characters
{
	public class CharacterController_FollowerBatsBatsBats : CharacterController
	{
		public override bool NeedsCart => false;

		public override float PAmount()
		{
			return 0f;
		}

		protected override void OnStop()
		{
		}

		public override void AfterFullInitialization()
		{
		}
	}
}
