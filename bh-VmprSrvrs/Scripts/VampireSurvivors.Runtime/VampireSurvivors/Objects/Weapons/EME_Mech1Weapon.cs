using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Mech1Weapon : EME_Weapon, EME_iCosmicRaveVFX
	{
		[Header("Additional Projectile Prefabs")]
		[SerializeField]
		private Projectile _BasicExplosionPrefab;

		[SerializeField]
		private Projectile _HailstormExplosionPrefab;

		private BulletPool _cosmicRaveVFXpool;

		[SerializeField]
		private Projectile _CosmicRaveVFXPrefab;

		[SerializeField]
		public bool UprightCosmicWaveSilhouette;

		private Timer _glimmerShotTimer;

		protected BulletPool _basicExplosionPool;

		protected BulletPool _hailstormExplosionPool;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		public BulletPool BasicExplosionPool => null;

		public BulletPool HailstormExplosionPool => null;

		protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
		{
			return default(WeaponType);
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void OnStart()
		{
		}

		public void DisplayCosmicRaveVFX(float2 position)
		{
		}

		protected bool OnBulletOverlapsEnemy_Freeze(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override void Fire_DoAttacks(BulletPool glimmerPool, bool skipTriggers = false)
		{
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		public Vector2 RandomPosOnScreenEdge()
		{
			return default(Vector2);
		}

		public void FireVolley(Vector2 pos, int _amount, Transform target = null)
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
