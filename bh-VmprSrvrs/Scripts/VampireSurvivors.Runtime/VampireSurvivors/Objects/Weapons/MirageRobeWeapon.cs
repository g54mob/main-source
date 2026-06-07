using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class MirageRobeWeapon : Weapon
	{
		protected bool collides;

		private SpriteRenderer _ringSprite;

		private MultiTargetTween _ringTween;

		private MultiTargetTween _ringTween2;

		private Collider ProjectileOnProjectileCollider;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void OnStart()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override float SecondaryPPower()
		{
			return 0f;
		}

		public override void CheckArcanas()
		{
		}
	}
}
