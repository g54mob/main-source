using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class VespersWeapon : Weapon
	{
		public bool _displayHoly;

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

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target, BulletPool pool = null)
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}
	}
}
