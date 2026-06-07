using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_MartialWhip1_Weapon : TP_WhipCore1_Weapon
	{
		[SerializeField]
		private Projectile _impactProjectile;

		protected BulletPool _impactPool;

		public override float SecondaryPPower()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public void FireImpactProjectiles(Vector2 pos)
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
