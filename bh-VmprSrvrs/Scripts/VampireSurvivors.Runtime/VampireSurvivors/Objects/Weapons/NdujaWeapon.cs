using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class NdujaWeapon : Weapon
	{
		public Vector3 FiringOffset;

		private const WeaponType COUNTER_WEAPON_TYPE = WeaponType.NDUJA_COUNTER;

		private Weapon _counterWeapon;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
