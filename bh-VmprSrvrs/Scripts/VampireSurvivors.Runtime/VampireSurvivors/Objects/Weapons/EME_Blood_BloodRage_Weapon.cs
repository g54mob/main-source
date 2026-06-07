using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Blood_BloodRage_Weapon : Weapon
	{
		[SerializeField]
		protected Projectile _BloodRageSpecialPrefab;

		protected BulletPool _bloodRageSpecialPool;

		protected readonly Dictionary<WeaponType, string> _glimmerNames;

		protected override void Awake()
		{
		}

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

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void DoBloodRage(float2 position)
		{
		}

		public void SpawnSpecialProjectiles(float2 position, BulletPool pool, float amountMul = 1f, float areaMul = 1f)
		{
		}

		private void SetupSpecialBulletPools()
		{
		}

		protected bool OnBulletOverlapsEnemyDamagex2(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
