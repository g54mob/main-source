using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class CherryStarsWeapon : CherryWeapon
	{
		private CherryStarProjectile _bulletA;

		private bool _hasBullets;

		private bool _hasImage;

		private bool _hasCharacterImage;

		private PhaserSprite _cow;

		private BulletPool _explosionPool;

		private BulletPool _drawerPool;

		private float _critChance;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float SecondaryPPower()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void ShootStarAt(float x, float y, int index)
		{
		}

		public void InitBullets()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void InitImage()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateImage()
		{
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
