using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_FullAutoWeapon : FB_QuantisedAngleWeapon
	{
		protected SpriteRenderer _muzzleFlash;

		protected bool _muzzleFlashLastRotated;

		protected int _frameCount;

		protected float _sinPhase;

		protected bool _randomizeSpeed;

		public override float SecondsToRotateAim360 => 0f;

		public override float QuantisationStep => 0f;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override bool LevelUp()
		{
			return false;
		}
	}
}
