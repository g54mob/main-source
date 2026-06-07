using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class SummonNight2Weapon : Weapon
	{
		private BulletPool _redPool;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected Projectile FireOneBullet_RedPool(float2 position, int index, Transform target)
		{
			return null;
		}

		protected override void OnStart()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
