using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Barlowe_Character : TP_Character
	{
		public float bonusConst;

		public float bonusStat;

		public float overhealingTotal;

		private float OverhealTriggerValue;

		private Timer _overHealTimer;

		public override float PPower()
		{
			return 0f;
		}

		public override float PCurse()
		{
			return 0f;
		}

		public override void AfterFullInitialization()
		{
		}

		public override WeaponType GetFourthLevelUpOption()
		{
			return default(WeaponType);
		}

		private void StatsUp(float value, float rawValue)
		{
		}
	}
}
