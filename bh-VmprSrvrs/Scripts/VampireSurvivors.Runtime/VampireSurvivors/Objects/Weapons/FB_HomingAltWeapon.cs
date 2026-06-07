using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_HomingAltWeapon : FB_QuantisedAngleWeapon
	{
		private IDamageable _targetDamagable;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		private void UpdateTargeting()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
