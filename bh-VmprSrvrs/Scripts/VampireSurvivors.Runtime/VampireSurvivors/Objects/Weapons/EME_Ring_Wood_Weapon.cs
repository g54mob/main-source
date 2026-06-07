using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Ring_Wood_Weapon : EME_Ring_Generic_Magic_Weapon
	{
		public override WeaponType GlimmerName => default(WeaponType);

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
