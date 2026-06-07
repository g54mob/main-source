using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Cannon2Weapon : EME_Cannon1Weapon
	{
		[Header("Bombarding Fire Explosion Projectile")]
		[SerializeField]
		private Projectile BombardingFireExplosionPrefab;

		private BulletPool _bombardingFire_Explosion_Pool;

		private Timer _bombardingFireTimer;

		protected Camera _mainCamera;

		protected Bounds _camBounds;

		protected override int ComboIndexFinal => 0;

		protected override int GlimmerTier => 0;

		public BulletPool BombardingFireExplosionPool => null;

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		public override void Cleanup()
		{
		}

		private bool OnBulletOverlapsEnemyHighDamageWithSlow(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
		}

		public void FireBombardment()
		{
		}

		private List<float2> GenerateBombardmentTargets()
		{
			return null;
		}

		private List<float2> GenerateBombardmentSpawnPoints(List<float2> targets)
		{
			return null;
		}
	}
}
