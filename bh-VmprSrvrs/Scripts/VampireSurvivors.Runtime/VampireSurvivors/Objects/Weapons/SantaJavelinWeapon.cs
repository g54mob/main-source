using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class SantaJavelinWeapon : Weapon
	{
		[NonSerialized]
		public bool _doFiring;

		private float _mul;

		protected bool _cooldownAffectedByMovement;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		protected SantaJavelinCounterWeapon _counterSet;

		protected bool _hasCounterSet;

		public virtual float PitchCorrection => 0f;

		public virtual bool SingleProjectile => false;

		public override float PAmount()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public virtual void ForcedFire(bool hasTarget, Vector3 position, bool skipTriggers = false)
		{
		}

		protected virtual Vector3 Fire_FireProjectiles(bool hasTarget, Vector3 position, bool skipTriggers = false)
		{
			return default(Vector3);
		}

		protected void Fire_FireCounter(Vector3 cachedPos, bool skipTriggers = false)
		{
		}

		public virtual Projectile FireOneProjectileTo(Vector2 pos, int index, Vector3 target)
		{
			return null;
		}

		public override void ResetFiringTimer()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}
	}
}
