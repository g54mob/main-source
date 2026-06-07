using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Tera_Character : TP_Character
	{
		private const float bonusConst = -0.01f;

		private float bonusStats;

		private float overhealingTotal;

		private float OverhealTriggerValue;

		private Timer _overHealTimer;

		public override float LootMult_Rosary => 0f;

		public override float PCooldown()
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
