using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_PrototypeAWeapon : FB_FullAutoWeapon
	{
		private BulletPool _planePool;

		private BulletPool _planeBulletsPool;

		private FB_PlaneProjectile[] planeProjectiles;

		public override void CheckArcanas()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public void startFiring(int planeIndex)
		{
		}

		public void stopFiring(int planeIndex)
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
