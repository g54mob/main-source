using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Tongue2Projectile : TongueProjectile
	{
		public bool AssassinationTongue { get; set; }

		protected override void InitTrailSprite()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override Vector3[] GetCurve(float2 startPoint, float2 currentPoint)
		{
			return null;
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}
	}
}
