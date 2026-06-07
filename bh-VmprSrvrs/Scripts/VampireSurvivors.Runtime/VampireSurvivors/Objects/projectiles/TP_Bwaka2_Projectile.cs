using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Bwaka2_Projectile : TP_Bwaka1_Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		protected override string FrameName => null;

		protected override bool InfiniteBounces => false;

		protected override float Radius => 0f;

		protected override float OrbitRadius => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupTrail()
		{
		}
	}
}
