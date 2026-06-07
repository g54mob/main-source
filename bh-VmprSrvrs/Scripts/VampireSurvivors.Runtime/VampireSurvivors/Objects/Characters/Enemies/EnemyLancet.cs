using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyLancet : PoolableMonoBehaviour
	{
		private SpriteRenderer _groundFx;

		private Transform _cachedTransform;

		private GameSessionData _gameSessionData;

		private PlayerOptions _playerOptions;

		private EnemyGallo _owner;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private GravityWell _gravityWell;

		private bool _hasHit;

		private Tween _despawnTimer;

		private Circle _circle;

		private const float Radius = 30f;

		private const float Diameter = 60f;

		public float Duration { get; set; }

		protected virtual void FakeConstruct()
		{
		}

		private void Awake()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void Init()
		{
		}

		public void SetDepthPlease(float depth)
		{
		}

		public void InternalUpdate()
		{
		}

		public void SetOwner(EnemyGallo enemyGallo)
		{
		}

		private void Despawn()
		{
		}

		private void OnHit()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
