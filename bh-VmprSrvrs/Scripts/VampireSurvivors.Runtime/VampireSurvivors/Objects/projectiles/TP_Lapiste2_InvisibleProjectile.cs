using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Lapiste2_InvisibleProjectile : Projectile
	{
		private const float Radius = 16f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void AttachToTransform(Transform transform)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
