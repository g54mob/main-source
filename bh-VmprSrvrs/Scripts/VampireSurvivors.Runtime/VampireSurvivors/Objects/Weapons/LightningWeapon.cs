using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LightningWeapon : Weapon
	{
		private bool _cooldownAffectedByMovement;

		private const float Mul = 166.66667f;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
