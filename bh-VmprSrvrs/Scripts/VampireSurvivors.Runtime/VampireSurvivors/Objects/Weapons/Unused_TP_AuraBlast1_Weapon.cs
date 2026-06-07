using Unity.Mathematics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_AuraBlast1_Weapon : TP_WhipCore1_Weapon
	{
		protected BulletPool _slamPool;

		protected override void Awake()
		{
		}

		public Projectile CreateSlamProjectile(float2 pos)
		{
			return null;
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
	}
}
