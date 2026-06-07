using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Morris_Character : TP_Character
	{
		private bool _canRetaliate;

		private float RetaliationDelay;

		private List<WeaponType> spells;

		private List<WeaponType> retaliatoryWeapons;

		public override void OnWeaponMadeLevelOne(WeaponType type)
		{
		}

		private void FireAllRetaliatoryWeapons()
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}
	}
}
