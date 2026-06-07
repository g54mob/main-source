using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Planets2_Weapon : LEM_Planets1_Weapon
	{
		protected override bool ShowBasePlanetCards => false;

		public override float PAmount()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private void AddSecretPlanets()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
