using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Pistol1Weapon : EME_Weapon
	{
		private BulletPool _bdShotPool;

		[SerializeField]
		protected Projectile _bdShotPrefsb;

		private BulletPool _ffExplosionPool;

		[SerializeField]
		protected Projectile _ffExplosionPrefsb;

		private BulletPool _destructibleProjectilePool;

		[SerializeField]
		private Projectile _destructibleProjectilePrefab;

		private float _timeSinceLastFalconFire;

		private float _range;

		private float _defaultRange;

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int ComboIndexFinal => 0;

		protected override bool CanWeaponGlimmer => false;

		private bool CanFireFalconFire => false;

		public override float PSpeed()
		{
			return 0f;
		}

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override void OnStart()
		{
		}

		public void DoFalconFireExplosionAt(Vector2 position)
		{
		}

		public void DoBoundingShotExplosionAt(Vector2 position)
		{
		}

		protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		public void SpawnSpecialProjectiles(float2 position, BulletPool pool, float amountMul = 1f, float areaMul = 1f)
		{
		}

		protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		protected override void Fire_DoAttacks(BulletPool glimmerPool, bool skipTriggers = false)
		{
		}

		public override void ParadoxFire()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
