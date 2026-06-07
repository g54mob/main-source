using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_FakeGrant_Solo_Character : TP_Character
	{
		private bool _canRetaliate;

		private float RetaliationDelay;

		private float OverhealDelay;

		private float OverhealTriggerValue;

		private bool _canOverheal;

		private Timer _overHealTimer;

		private List<WeaponType> knives;

		public override void AfterFullInitialization()
		{
		}

		private void FireAllKnives()
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		private void OverhealTrigger(float value, float rawValue)
		{
		}
	}
}
