using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_SpiritRings1Weapon : Weapon
	{
		[SerializeField]
		protected Projectile _SunlightPrefab;

		[SerializeField]
		protected Projectile _AquaSpherePrefab;

		[SerializeField]
		protected Projectile _HeavensThunderPrefab;

		[SerializeField]
		protected Projectile _HyperGravityPrefab;

		[SerializeField]
		protected Projectile _VermillionSandsPrefab;

		[SerializeField]
		protected Projectile _ChaosDisasterPrefab;

		[Space]
		[SerializeField]
		private int _sunlightPoolCount;

		[SerializeField]
		private int _aquaSpherePoolCount;

		[SerializeField]
		private int _heavensThunderPoolCount;

		[SerializeField]
		private int _hyperGravityPoolCount;

		[SerializeField]
		private int _vermillionSandsPoolCount;

		[SerializeField]
		private int _chaosDisasterPoolCount;

		private BulletPool _sunlightPool;

		private BulletPool _aquaSpherePool;

		private BulletPool _heavensThunderPool;

		private BulletPool _hyperGravityPool;

		private BulletPool _vermillionSandsPool;

		private BulletPool _chaosDisasterPool;

		private BulletPool _fireExplosionPool;

		protected const float IntervalMul_Water = 3f;

		protected const float IntervalMul_WoodA = 5f;

		protected const float IntervalMul_Earth = 7f;

		protected const float IntervalMul_Metal = 11f;

		protected const float IntervalMul_Chaos = 13f;

		protected float _elapsed_Firee;

		protected float _elapsed_Water;

		protected float _elapsed_Earth;

		protected float _elapsed_WoodA;

		protected float _elapsed_Metal;

		protected float _elapsed_Chaos;

		private readonly Dictionary<WeaponType, string> _glimmerNames;

		protected virtual bool IsEvolved => false;

		protected override void OnStart()
		{
		}

		private void AddGlimmerName(WeaponType glimmerWeaponType)
		{
		}

		private string GetGlimmerName(WeaponType weaponType)
		{
			return null;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireSpell(BulletPool spellPool, bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Fire_Fire()
		{
		}

		private void Fire_Water()
		{
		}

		private void Fire_WoodA()
		{
		}

		private void Fire_Earth()
		{
		}

		private void Fire_Metal()
		{
		}

		private void Fire_Chaos()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		private bool OnBulletOverlapsEnemyDamagex15(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnBulletOverlapsEnemyDamagex2(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnBulletOverlapsEnemyDamagex3(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		public void SpawnFireExplosionAt(float2 pos)
		{
		}
	}
}
