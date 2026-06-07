using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerGazebo : CharacterController
	{
		private float OverhealTriggerValue;

		private Timer _overHealTimer;

		private List<WeaponBonusPair> _earlyBonusList;

		private List<WeaponBonusPair> _crapBonusList;

		private List<WeaponBonusPair> _obtainedBonusList;

		private int maxBonusTimes;

		private float cachedSize;

		private Timer _food_sequentialTimer;

		private float _food_BonusTimer;

		private float _food_BonusDelay;

		public override void AfterFullInitialization()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void ApplyBonus(WeaponType weapon, float value, float bonusSize)
		{
		}

		[Command]
		public void AddAttributeOnline(int weaponType, float value, float bonusSize)
		{
		}

		private void InitBonuses(WeaponType weaponType, float bonusValue, int times, List<WeaponBonusPair> _list)
		{
		}

		private void CharacterHealed(float value, float rawValue)
		{
		}

		public bool CheckAchievementStats()
		{
			return false;
		}

		private void AddBonusToQueue()
		{
		}

		private void AddAttribute(CharacterController character, WeaponType weaponType, float value)
		{
		}
	}
}
