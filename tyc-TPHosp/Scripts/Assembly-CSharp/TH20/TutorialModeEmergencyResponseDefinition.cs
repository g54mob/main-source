namespace TH20
{
	public class TutorialModeEmergencyResponseDefinition : TutorialModeDefinition
	{
		public float SecondsBeforeClosingSatNav = 2.5f;

		public override TutorialMode Create()
		{
			return new TutorialModeEmergencyResponse(this);
		}
	}
}
