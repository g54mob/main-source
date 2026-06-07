using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Guns2Weapon : Weapon
	{
		[NonSerialized]
		public bool _doFiring;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		protected WeaponType _secondSetType;

		public override void ResetFiringTimer()
		{
		}

		public void ResetFiringTimerPublic()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override bool LevelUp()
		{
			return false;
		}
	}
}
