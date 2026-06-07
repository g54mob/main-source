using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_WaterMagician_Character : TP_Character
	{
		public float bonusConst;

		public float bonusStats;

		public float overhealingTotal;

		private float OverhealDelay;

		private float OverhealTriggerValue2;

		private bool _canOverheal;

		private Timer _overHealTimer;

		private List<WeaponType> coatOfArmsWeapons;

		private FloodWeapon floodWeapon;

		public override void AfterFullInitialization()
		{
		}

		private void StatsUp(float value, float rawValue)
		{
		}

		private void FireAllCoatOfArmsWeapons()
		{
		}
	}
}
