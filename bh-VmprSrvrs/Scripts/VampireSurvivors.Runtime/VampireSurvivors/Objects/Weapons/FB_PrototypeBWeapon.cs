using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_PrototypeBWeapon : FB_RapidFireWeapon
	{
		private BulletPool _planePool;

		private BulletPool _planeBulletsPool;

		private int _planeProjectileAmount;

		private FB_PlaneProjectile[] planeProjectiles;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public Projectile FireOnePlaneProjectile(Vector2 pos, int index, Transform target, BulletPool pool, FB_PlaneProjectile planeProjectile)
		{
			return null;
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
