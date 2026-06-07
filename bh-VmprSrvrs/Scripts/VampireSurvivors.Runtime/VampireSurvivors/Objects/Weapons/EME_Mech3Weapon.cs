using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Mech3Weapon : EME_Mech2Weapon
	{
		protected override int GlimmerTier => 0;

		protected override int ComboIndexFinal => 0;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}
	}
}
