using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KatanaProjectile_GravediggerRock : Projectile
	{
		private const float Radius = 16f;

		private const float AreaMultiplier = 0.7f;

		private Vector2 _velocity;

		private Tween _angleTween;

		private Tween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
