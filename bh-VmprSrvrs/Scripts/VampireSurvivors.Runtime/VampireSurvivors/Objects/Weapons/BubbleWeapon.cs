using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class BubbleWeapon : Weapon
	{
		protected override void OnStart()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		protected override void OnUpdate()
		{
		}

		private void OverlapCirc(float x, float y, float radius)
		{
		}

		private bool CircleToCircle(Circle circleA, BaseBody circleB)
		{
			return false;
		}

		private float DistanceBetween(float x1, float y1, float x2, float y2)
		{
			return 0f;
		}

		public override void ParadoxFire()
		{
		}
	}
}
