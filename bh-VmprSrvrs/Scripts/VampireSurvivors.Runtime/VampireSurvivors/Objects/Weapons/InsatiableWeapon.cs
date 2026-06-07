using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class InsatiableWeapon : Weapon
	{
		private PhaserSprite _image;

		private MultiTargetTween _imageTween;

		private MultiTargetTween _imageTween2;

		private float _imagePixelSize;

		public bool IsFromDarkana;

		public override float PPower()
		{
			return 0f;
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		private float GetImageScale()
		{
			return 0f;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
