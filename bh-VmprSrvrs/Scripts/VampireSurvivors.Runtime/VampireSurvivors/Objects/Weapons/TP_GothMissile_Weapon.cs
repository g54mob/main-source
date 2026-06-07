using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_GothMissile_Weapon : Weapon
	{
		private static float init;

		private static float unitX;

		private static float unitY;

		private List<float> offsetsX;

		private List<float> offsetsY;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
