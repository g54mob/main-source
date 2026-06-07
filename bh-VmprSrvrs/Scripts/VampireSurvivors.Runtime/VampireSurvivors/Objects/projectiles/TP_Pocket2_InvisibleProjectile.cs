using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Pocket2_InvisibleProjectile : Projectile
	{
		private const float Radius = 20f;

		public bool IsSuperAttack { get; set; }

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void AttachToTransform(Transform transform)
		{
		}
	}
}
