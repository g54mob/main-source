using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects
{
	public class ExplosionVFX : PoolableMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		[SerializeField]
		private SpriteRenderer _RingSprite;

		private Transform _cachedTransform;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _well;

		private Tween _scaleTween;

		private Tween _scaleRingTween;

		private Timer _despawnTimer;

		private Circle _circleArea;

		private float _damage;

		private float _radius;

		private uint[] _tints;

		private void Awake()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public void SpawnAt(float damage, float radius, bool flashingVFX)
		{
		}

		public void SetDepthPlease(float depth)
		{
		}

		private void Explode(bool flashingVFX)
		{
		}

		private void TriggerDespawnTimer()
		{
		}

		private void Despawn()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
