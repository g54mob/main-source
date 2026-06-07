namespace VampireSurvivors.Objects.Characters
{
	public class TP_Gaibon_Solo_Character : TP_Character
	{
		public override bool NeedsCart => false;

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		protected override void OnStop()
		{
		}

		public override void AfterFullInitialization()
		{
		}
	}
}
