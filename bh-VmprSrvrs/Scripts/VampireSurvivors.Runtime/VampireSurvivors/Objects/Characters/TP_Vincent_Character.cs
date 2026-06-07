using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Vincent_Character : TP_Character
	{
		public float bonusConst;

		public float bonusGreed;

		public float overhealingTotal;

		private float OverhealTriggerValue;

		private Timer _overHealTimer;

		public override float PGreed()
		{
			return 0f;
		}

		public override void AfterFullInitialization()
		{
		}

		private void GreedUp(float value, float rawValue)
		{
		}
	}
}
