using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Maria_Character : CharacterController
	{
		private int _followers;

		public float bonusConst;

		public float bonusStats;

		public float overhealingTotal;

		private float OverhealDelay;

		private float OverhealTriggerValue;

		private float OverhealTriggerValue2;

		private bool _canOverheal;

		private Timer _overHealTimer;

		private List<CharacterType> possibleFollowers;

		private List<CharacterType> currentFollowers;

		public override float PPower()
		{
			return 0f;
		}

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		private void AddRandomFollower()
		{
		}

		private void StatsUp(float value, float rawValue)
		{
		}
	}
}
