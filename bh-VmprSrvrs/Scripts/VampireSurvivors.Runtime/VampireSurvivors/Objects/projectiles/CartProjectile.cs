using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class CartProjectile : Projectile
	{
		private ParticleSystem _pfxEmitter;

		private float _defaultSpeed;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SetDepths()
		{
		}

		private void GeneratePfx()
		{
		}
	}
}
