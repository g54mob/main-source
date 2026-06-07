using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class Explosion : PoolableMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		private Transform _cachedTransform;

		private PlayerOptions _playerOptions;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter1;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _gravityWell;

		private Tween _scaleTween;

		private Timer _despawnTimer;

		private Circle _circleArea;

		private float _damage;

		private float _radius;

		private bool _hasHit;

		private bool _isDespawning;

		[Inject]
		private void Construct(PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public void Init(float damage, float radius)
		{
		}

		public void SetDepthPlease(float depth)
		{
		}

		public void InternalUpdate()
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

		private void InitGravityWell()
		{
		}

		private void ReleaseGravityWell()
		{
		}
	}
}
