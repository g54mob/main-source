using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Zephyr_Character : TP_Character
	{
		private List<WeaponType> adeptWeapons;

		private float cooldownBonus;

		private float moveBonus;

		private bool _previousTimeStopState;

		public override float LootMult_Orologion => 0f;

		public override float PCooldown()
		{
			return 0f;
		}

		public override float PMoveSpeed()
		{
			return 0f;
		}

		protected override void OnUpdate()
		{
		}

		private void OnTimeStopStart()
		{
		}

		private void OnTimeStopEnd()
		{
		}

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}
	}
}
