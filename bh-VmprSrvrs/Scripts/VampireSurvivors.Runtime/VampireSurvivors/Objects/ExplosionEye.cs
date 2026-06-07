using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class ExplosionEye : PoolableMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		[SerializeField]
		private SpriteRenderer _WarningSprite;

		[SerializeField]
		private SpriteRenderer _StarSprite;

		[SerializeField]
		private SpriteRenderer _GroundWarning;

		[SerializeField]
		private TrailRenderer _Trail;

		private GameSessionData _gameSessionData;

		private PlayerOptions _playerOptions;

		private SpriteAnimation _starsSpriteAnim;

		private Camera _camera;

		private Circle _circleArea;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _starsPfx;

		private ParticleSystem _cloudPfx;

		private GravityWell _gravityWell;

		private Sequence _warningTween;

		private Sequence _groundWarningTween;

		private Tween _arcAngleTween;

		private Tween _scaleTween;

		private Timer _despawnTimer;

		private Color _color;

		private bool _hasHit;

		private bool _exploding;

		private float _arcAngle;

		private float _arcRadius;

		private float Damage { get; set; }

		private float Radius { get; set; }

		[Inject]
		private void Construct(GameSessionData gameSessionData, PlayerOptions playerOptions)
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

		public void InternalUpdate()
		{
		}

		public void SetDepthPlease(float depth)
		{
		}

		public void Despawn()
		{
		}

		private void Explode()
		{
		}

		private void TriggerDespawnTimer()
		{
		}

		private void AssignRandomColor()
		{
		}

		private void TrailUpdate()
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
