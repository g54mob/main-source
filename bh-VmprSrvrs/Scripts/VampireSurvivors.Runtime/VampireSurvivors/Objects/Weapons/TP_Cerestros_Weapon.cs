using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Cerestros_Weapon : TP_Custos_Weapon
	{
		private BulletPool _firePool_;

		private BulletPool _fireExplosionPool_;

		private BulletPool _icePool_;

		private BulletPool _iceExplosionPool_;

		private BulletPool _sinistroPool_;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override Projectile AddFireTrailAt(Vector2 pos)
		{
			return null;
		}

		public override Projectile AddFireExplosionAt(Vector2 pos)
		{
			return null;
		}

		public override Projectile AddIceTrailAt(Vector2 pos)
		{
			return null;
		}

		public override Projectile AddIceExplosionAt(Vector2 pos)
		{
			return null;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Cleanup()
		{
		}
	}
}
