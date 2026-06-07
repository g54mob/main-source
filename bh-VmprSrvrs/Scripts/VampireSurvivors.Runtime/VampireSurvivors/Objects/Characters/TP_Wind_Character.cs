using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Wind_Character : TP_Character
	{
		private bool _canRetaliate;

		private float RetaliationDelay;

		private float OverhealDelay;

		private float OverhealTriggerValue2;

		private bool _canOverheal;

		private Timer _overHealTimer;

		private Weapon aurablastWeapon;

		private List<WeaponType> spells;

		public override void AfterFullInitialization()
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		private void StatsUp(float value, float rawValue)
		{
		}

		[Command]
		public void TriggerCoatOfArmsWeapon(int weapon)
		{
		}
	}
}
