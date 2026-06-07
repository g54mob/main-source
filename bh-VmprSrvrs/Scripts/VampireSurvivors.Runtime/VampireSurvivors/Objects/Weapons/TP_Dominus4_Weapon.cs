using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Dominus4_Weapon : Weapon
	{
		private bool _totalDamageCalculated;

		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		private TP_Dominus1_Weapon _weaponDominus1;

		private TP_Dominus2_Weapon _weaponDominus2;

		private TP_Dominus3_Weapon _weaponDominus3;

		private BulletPool invisPool;

		[SerializeField]
		private Projectile _invisProjectilePrefab;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		protected override void Awake()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		protected override void OnStart()
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

		public void FireDominusWeapons()
		{
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}

		public void FireInvisibleProjectiles()
		{
		}

		protected virtual bool OnBulletOverlapsEnemyOHKO(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
