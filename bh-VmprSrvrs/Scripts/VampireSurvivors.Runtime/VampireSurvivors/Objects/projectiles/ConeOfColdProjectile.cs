using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class ConeOfColdProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		private ParticleEmitterManager _particleEmitterManager;

		private Sequence _scaleTween;

		private const float Radius = 16f;

		protected bool isPlayerFacing;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void AssignRandomColorToGroundFx()
		{
		}

		private void GenerateParticleSystems()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
