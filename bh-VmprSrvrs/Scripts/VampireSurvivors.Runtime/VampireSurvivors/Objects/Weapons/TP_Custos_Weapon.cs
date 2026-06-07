using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Custos_Weapon : Weapon
	{
		protected BulletPool _fireHeadPool;

		protected BulletPool _iceHeadPool;

		protected BulletPool _lightningHeadPool;

		protected BulletPool _fireTrailPool;

		protected BulletPool _iceTrailPool;

		protected BulletPool _lightningTrailPool;

		protected BulletPool _fireExplosionPool;

		protected BulletPool _iceExplosionPool;

		protected BulletPool _lightningExplosionPool;

		protected BulletPool _fireFireballPool;

		protected BulletPool _iceFireballPool;

		protected BulletPool _lightningFireballPool;

		public override float PArea()
		{
			return 0f;
		}

		protected void InitAllBulletPools()
		{
		}

		protected BulletPool InitBulletPool(WeaponType weaponType)
		{
			return null;
		}

		protected BulletPool InitSecondaryBulletPool(WeaponType weaponType)
		{
			return null;
		}

		public virtual Projectile AddFireTrailAt(Vector2 pos)
		{
			return null;
		}

		public virtual Projectile AddFireExplosionAt(Vector2 pos)
		{
			return null;
		}

		public virtual Projectile AddIceTrailAt(Vector2 pos)
		{
			return null;
		}

		public virtual Projectile AddIceExplosionAt(Vector2 pos)
		{
			return null;
		}

		public virtual Projectile AddLightningTrailAt(Vector2 pos)
		{
			return null;
		}

		public virtual Projectile AddLightningExplosionAt(Vector2 pos)
		{
			return null;
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void Cleanup()
		{
		}
	}
}
