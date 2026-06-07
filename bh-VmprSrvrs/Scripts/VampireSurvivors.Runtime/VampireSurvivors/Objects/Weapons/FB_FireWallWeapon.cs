using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_FireWallWeapon : Weapon
	{
		private List<FlameData> flameData;

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		private FlameData nextFlameData()
		{
			return null;
		}

		public void addFlameSprite(float2 pos)
		{
		}

		protected override bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
