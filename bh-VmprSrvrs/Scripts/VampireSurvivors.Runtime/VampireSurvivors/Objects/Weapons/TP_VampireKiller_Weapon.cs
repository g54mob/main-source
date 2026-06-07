using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_VampireKiller_Weapon : TP_SpriteWhip_Weapon
	{
		public override bool ShootFireballs => false;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
