using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class GunsWeapon : Weapon
	{
		protected bool _hasSecondSet;

		protected Weapon _secondSet;

		protected WeaponType _secondSetType;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		[NonSerialized]
		public BulletPool _explosionPool;

		[SerializeField]
		private Projectile _explosionPrefab;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
