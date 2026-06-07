using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class HolyBookWeapon : Weapon
	{
		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float SecondaryPPower()
		{
			return 0f;
		}

		public override float SecondaryPAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}
	}
}
