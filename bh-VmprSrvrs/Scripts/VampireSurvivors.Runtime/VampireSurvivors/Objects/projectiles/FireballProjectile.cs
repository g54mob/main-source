using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FireballProjectile : Projectile
	{
		private ParticleSystem _pfxEmitter;

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

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
