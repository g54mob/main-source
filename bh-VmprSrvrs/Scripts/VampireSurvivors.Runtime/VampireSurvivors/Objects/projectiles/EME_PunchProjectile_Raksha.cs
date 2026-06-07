using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_PunchProjectile_Raksha : Projectile
	{
		[SerializeField]
		private ParticleSystem rakshaSparksVFX;

		[SerializeField]
		private ParticleSystem rakshaImpactBigVFX;

		[SerializeField]
		private ParticleSystem rakshaImpactSmallVFX;

		[SerializeField]
		private ParticleSystem rakshaPunchVFX;

		[SerializeField]
		private ParticleSystem rakshaExplosionVFX;

		[SerializeField]
		private ParticleEventCall rakshaExplosionVFXparticleEventCall;

		private float radius;

		private bool _isDespawning;

		private Tween _radiusTween;

		private TweenerCore<Vector3, Vector3, VectorOptions> _moveTween;

		private Vector3 _targetPosition;

		private bool _showVfx;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVisuals()
		{
		}

		private void Strike()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void Explode()
		{
		}

		public void SetTargetPosition(Vector3 target)
		{
		}

		public void StartDespawn()
		{
		}

		private void DespawnAfterParticlesStopped()
		{
		}

		private void FinishDespawn()
		{
		}
	}
}
