using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Sonia_Character : TP_Character
	{
		private float OverhealDelay;

		private float OverhealTriggerValue;

		private bool _canOverheal;

		private Timer _overHealTimer;

		public override void AfterFullInitialization()
		{
		}

		private void BurningMode(float value, float rawValue)
		{
		}
	}
}
