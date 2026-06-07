using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SpiritTornado_Weapon : Weapon
	{
		private BulletPool _invisibleProjectilePool;

		[SerializeField]
		private Projectile _invisibleProjectilePrefab;

		private BulletPool _spiritGemProjectilePool;

		[SerializeField]
		private Projectile _spiritGemProjectilePrefab;

		private BulletPool _gemExplosionProjectilePool;

		[SerializeField]
		private Projectile _gemExplosionProjectilePrefab;

		private bool canPickupItems;

		private Timer pickupsResetTimer;

		private List<Pickup> itemsPickedUp;

		private bool _isManualFire;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public void SetManualFire()
		{
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

		public override void Fire(bool skipTriggers = false)
		{
		}

		private bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
		{
			return false;
		}

		public void SpawnGemExplosion()
		{
		}

		protected bool OnGemOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void Cleanup()
		{
		}
	}
}
