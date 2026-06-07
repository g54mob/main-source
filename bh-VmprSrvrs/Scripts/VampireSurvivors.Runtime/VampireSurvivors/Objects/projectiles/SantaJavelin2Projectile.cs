using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SantaJavelin2Projectile : Projectile
	{
		[SerializeField]
		private SpriteAnimation _AngelAnimation;

		[SerializeField]
		private SpriteRenderer _AngelSprite;

		[SerializeField]
		private SpriteRenderer _JavelinSprite;

		[SerializeField]
		private SpriteRenderer _GroundFx;

		[SerializeField]
		private SpriteTrail _Trail;

		protected SantaJavelin2Weapon _trueWeapon;

		private Camera _camera;

		private Tween _positionTween;

		private Timer _expireTimer;

		private ParticleSystem _explosionPfx1;

		private ParticleSystem _explosionPfx2;

		private const float Radius = 32f;

		private const float ExploRadius = 8f;

		private bool _isBroken;

		private bool _isDespawning;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private MultiTargetTween _tween4;

		private float fullSalvoDuration;

		private MultiTargetTween _angelAlphaTween;

		private TweenerCore<Vector3, Vector3, VectorOptions> _positionTweenAngel;

		private GravityWell _well;

		private ParticleEmitterManager _particlesManager;

		protected virtual bool MirrorMotion => false;

		protected override void Awake()
		{
		}

		private void PlaySFX()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Break()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void GetComponents()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
