using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Kick1Weapon : EME_Weapon
	{
		public float bonusPower;

		public float overhealingTotal;

		private BulletPool _dragonBpool;

		private BulletPool _dragonCpool;

		private BulletPool _dragonSpool;

		[SerializeField]
		protected Projectile _DragonBPrefab;

		[SerializeField]
		protected Projectile _DragonCPrefab;

		[SerializeField]
		protected Projectile _DragonSPrefab;

		private bool _cooldownAffectedByMovement;

		private const float Mul = 166.66667f;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		public virtual bool IsEvolved => false;

		public virtual int WallBounces => 0;

		public override float PPower()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		private void BonusOverHealDamage(float value, float rawValue)
		{
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		protected override void InitGlimmer2BulletPool()
		{
		}

		protected bool OnBulletOverlapsEnemyDamageX15(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemyRecoveryBonus(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void CheckArcanas()
		{
		}
	}
}
