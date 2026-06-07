using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Maxim_Character : TP_Character
	{
		public float bonusConst;

		public float bonusStats;

		public float overhealingTotal;

		private float OverhealTriggerValue;

		private Timer _overHealTimer;

		public override float PPower()
		{
			return 0f;
		}

		public override float PSpeed()
		{
			return 0f;
		}

		public override void AfterFullInitialization()
		{
		}

		private void StatsUp(float value, float rawValue)
		{
		}
	}
}
