using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Guns3Weapon : Weapon
	{
		private float _rayAngle;

		private float _angleUnit;

		private MultiTargetTween _scaleTween;

		private List<PhaserSprite> _rays;

		private float _pxUnit;

		private MultiTargetTween _permaTween;

		protected WeaponType _counterWeaponType1;

		protected WeaponType _counterWeaponType2;

		protected Weapon _counterWeapon1;

		protected Weapon _counterWeapon2;

		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float PSpeed()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public Projectile FireOneBullet(float x, float y, int index, double angle, BulletPool pool = null)
		{
			return null;
		}

		public override void InternalUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}

		private void PermaTween()
		{
		}
	}
}
