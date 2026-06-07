using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Katana1Weapon : EME_Weapon
	{
		private float MaxBonus;

		private float MaxEnemies;

		private float currentBonus;

		[Header("Additional Projectile Prefabs")]
		[SerializeField]
		private Projectile _gravediggerRockPrefab;

		[SerializeField]
		private Projectile _scatteredPetalsMiniSlashPrefab;

		[SerializeField]
		private Projectile _scatteredPetalsMoonPrefab;

		protected BulletPool _gravediggerRockPool;

		protected BulletPool _scatteredPetalsMiniSlashPool;

		protected BulletPool _scatteredPetalsMoonPool;

		private Timer _glimmerShotTimer;

		private const float _scatteredPetalsMaxArea = 2.5f;

		private float2 _scatteredPetalsOffsetFromPlayer;

		public BulletPool GravediggerRockPool => null;

		public float ScatteredPetalsMaxArea => 0f;

		public float2 ScatteredPetalsOffsetFromPlayer => default(float2);

		protected override int EvolutionLevel => 0;

		protected override int _comboIndex1 => 0;

		protected override int _comboIndex2 => 0;

		protected override int _comboIndex3 => 0;

		protected override int ComboIndexFinal => 0;

		public override float PPower()
		{
			return 0f;
		}

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

		private void LateUpdate()
		{
		}

		protected override void OnStart()
		{
		}

		public virtual void FireScatteredPetalsMiniSlashes()
		{
		}

		public void FireScatteredPetalsMoon(Vector2 position, int index, Action onProjectileDespawn)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void Cleanup()
		{
		}

		protected override void InitGlimmer1BulletPool()
		{
		}

		protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
