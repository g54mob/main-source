using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LoopWeapon : Weapon
	{
		private bool _cooldownAffectedByMovement;

		private const float Mul = 166.66667f;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
