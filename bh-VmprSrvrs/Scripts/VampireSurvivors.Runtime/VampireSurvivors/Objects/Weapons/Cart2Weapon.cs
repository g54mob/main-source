using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Cart2Weapon : Weapon
	{
		private float _mul;

		private bool _cooldownAffectedByMovement;

		public ArcadeBodyBounds CustomWorldBounds { get; private set; }

		public ArcadeBodyBounds CustomWorldBoundsHoming { get; private set; }

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private void UpdateCollisionBounds()
		{
		}

		private void SetHomingCollisionBounds()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override int PBounces()
		{
			return 0;
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
