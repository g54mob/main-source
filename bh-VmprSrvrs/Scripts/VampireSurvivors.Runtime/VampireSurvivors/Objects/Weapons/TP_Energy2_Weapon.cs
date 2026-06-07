using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Energy2_Weapon : Weapon
	{
		private bool _initialisedParticles;

		private float _totalTimeCounterWeapon;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		protected SantaJavelinCounterWeapon _counterSet;

		protected bool _hasCounterSet;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		public bool IsBeamActive { get; set; }

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		protected void Fire_FireCounter(bool skipTriggers = false)
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}
	}
}
