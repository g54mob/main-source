using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class GemCannonWeapon : Weapon
	{
		[SerializeField]
		private Projectile _ExplosionProjectilePrefab;

		private BulletPool _explosionPool;

		public float GemValue { get; set; }

		public string GemFrame { get; set; }

		protected override void OnStart()
		{
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnExplosionOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private bool OnExplosionOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void TriggerExplosion(Vector2 pos)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
