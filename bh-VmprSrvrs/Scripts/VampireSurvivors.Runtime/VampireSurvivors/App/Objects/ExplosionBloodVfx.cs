using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.App.Objects
{
	public class ExplosionBloodVfx : PoolablePhaserSprite
	{
		[SerializeField]
		private PhaserSprite _RingSprite;

		[SerializeField]
		private PhaserSprite _GroundFx;

		private float _radius;

		private Circle _circleArea;

		private MultiTargetTween _despawnTimer;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _well;

		protected override void Awake()
		{
		}

		public void OnRecycle(float radius)
		{
		}

		public void SetDepthPlease(float depth)
		{
		}

		private void GenerateParticles()
		{
		}

		private void InitGravityWell()
		{
		}

		private void ReleaseGravityWell()
		{
		}

		private void Explode()
		{
		}

		private void Despawn()
		{
		}

		private void Die()
		{
		}
	}
}
