using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Discus1_Weapon : Weapon
	{
		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
