using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_LongswordProjectile_SwallowSlice : Projectile
	{
		[SerializeField]
		private ParticleSystem swallowSliceVFX;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetDirection(Vector3 direction)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void DeactivateProjectile()
		{
		}
	}
}
