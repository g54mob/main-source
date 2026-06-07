using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_SonicBloomWeapon : Weapon
	{
		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
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
