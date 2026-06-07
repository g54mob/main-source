using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class HellfireProjectile : Projectile
	{
		private ParticleSystem _pfx;

		private Tween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetTarget(Transform target)
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private void SetDepth()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
