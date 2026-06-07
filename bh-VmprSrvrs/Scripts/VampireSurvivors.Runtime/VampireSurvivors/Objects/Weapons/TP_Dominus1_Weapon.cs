using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Dominus1_Weapon : Weapon
	{
		private BulletPool _invisibleProjectilePool;

		[SerializeField]
		private Projectile _invisibleProjectilePrefab;

		private bool _initialisedParticles;

		private bool _isManualFire;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		public bool Inverted { get; set; }

		protected override void Awake()
		{
		}

		public void SetManualFire()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireProjectiles()
		{
		}

		protected Vector2 GetVelocityToNearestEnemy()
		{
			return default(Vector2);
		}

		public override void CheckArcanas()
		{
		}
	}
}
