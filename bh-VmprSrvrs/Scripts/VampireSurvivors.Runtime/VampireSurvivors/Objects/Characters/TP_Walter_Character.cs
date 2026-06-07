using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Walter_Character : TP_Character
	{
		private float OverhealDelay;

		private float OverhealTriggerValue2;

		private bool _canOverheal;

		private Timer _overHealTimer;

		private Weapon aurablastWeapon;

		private List<WeaponType> spells;

		public override bool DrainWeaponsImmunity => false;

		public override void AfterFullInitialization()
		{
		}

		private void StatsUp(float value, float rawValue)
		{
		}

		[Command]
		public void TriggerWeapon(int weapon)
		{
		}
	}
}
