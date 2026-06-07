namespace VampireSurvivors.Objects.Characters
{
	public class TP_Graham_Character : TP_Character
	{
		public override bool DrainWeaponsImmunity => false;

		protected override void OnStop()
		{
		}

		public override void AfterFullInitialization()
		{
		}
	}
}
