using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_AlucardShield_Weapon : Weapon
	{
		public int SlotNumber;

		private readonly List<Equipment> _weaponsHiddenByShield;

		public bool TryGetWeaponHiddenByShield(WeaponType weaponType, out Equipment weapon)
		{
			weapon = null;
			return false;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override float CalcCritMul()
		{
			return 0f;
		}
	}
}
