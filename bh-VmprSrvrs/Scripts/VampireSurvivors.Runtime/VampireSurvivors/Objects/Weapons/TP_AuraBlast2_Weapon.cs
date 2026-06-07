using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_AuraBlast2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _HellfireProjectilePrefab;

		private const float HellfireDamageMultiplier = 3f;

		private BulletPool _hellfireProjectilePool;

		public override float HeartOfFirePower => 0f;

		public BulletPool HellfireProjectilePool => null;

		protected override void OnStart()
		{
		}

		protected override void MakeLevelOne()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}

		private bool OnBulletOverlapsEnemy_Hellfire(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
