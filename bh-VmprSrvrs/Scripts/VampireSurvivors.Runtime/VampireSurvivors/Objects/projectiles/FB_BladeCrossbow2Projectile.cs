using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_BladeCrossbow2Projectile : FB_BladeCrossbowProjectile
	{
		[SerializeField]
		private SpriteTrail _Trail;

		protected override string _FrameName => null;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}
	}
}
