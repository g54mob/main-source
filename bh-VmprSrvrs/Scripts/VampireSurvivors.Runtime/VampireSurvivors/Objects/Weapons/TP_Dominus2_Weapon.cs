using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Dominus2_Weapon : Weapon
	{
		private bool _initialisedParticles;

		private BulletPool _centralProjectilePool;

		[SerializeField]
		private Projectile _centralProjectilePrefab;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		public bool Inverted { get; set; }

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

		public void FireProjectiles()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
