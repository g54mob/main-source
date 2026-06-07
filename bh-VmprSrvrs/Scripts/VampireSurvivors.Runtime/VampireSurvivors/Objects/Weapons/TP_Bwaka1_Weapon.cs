using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Bwaka1_Weapon : Weapon
	{
		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override int PBounces()
		{
			return 0;
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void CheckArcanas()
		{
		}
	}
}
