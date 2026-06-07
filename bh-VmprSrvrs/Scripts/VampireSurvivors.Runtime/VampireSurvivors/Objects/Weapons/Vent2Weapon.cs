using TMPro;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Vent2Weapon : Weapon
	{
		private bool _firingQueued;

		public TextMeshPro _ejectionText;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
