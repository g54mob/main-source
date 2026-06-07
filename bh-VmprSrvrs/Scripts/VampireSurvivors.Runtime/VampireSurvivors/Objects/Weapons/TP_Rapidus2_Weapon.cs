using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Rapidus2_Weapon : TP_Rapidus_Weapon
	{
		private bool _shouldCheckForSecret;

		protected override float _perLevelBonus => 0f;

		protected override int _maxCharges => 0;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
