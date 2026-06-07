using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Trapano2Weapon : Weapon
	{
		public Color[] _UnionSpriteColours;

		public Color[] _UnionTrailColours;

		private const float Mul = 16.666666f;

		public bool IsUnion { get; set; }

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
