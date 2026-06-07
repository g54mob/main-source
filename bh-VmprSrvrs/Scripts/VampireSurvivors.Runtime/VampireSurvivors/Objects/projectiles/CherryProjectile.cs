using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class CherryProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _ringRenderer;

		[SerializeField]
		private SpriteRenderer _rainbowRenderer;

		[SerializeField]
		private SpriteRenderer _raysRenderer;

		private Tween _angleTween;

		private Tween _speedTween;

		private Tween _scaleTween;

		private Tween _bodyScaleTween;

		private Sequence _tween1;

		private Sequence _tween2;

		private Tween _tween3;

		private Sequence _tween4;

		private Sequence _tween5;

		private Tween _tween6;

		private Timer _bounceTimer;

		private float _save_vel_x;

		private float _save_vel_y;

		private Vector2 _aimVector;

		private bool _canBounce;

		private float _bombDeceleration;

		private uint[] _onEmitCustomTints;

		private uint[] _onEmitcustomTint2;

		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _fwEmitter;

		private ParticleSystem _fwEmitter2;

		private Circle _a;

		private bool _particlesGenerated;

		private CherryWeapon _trueWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void ResetRenderers()
		{
		}

		private void GenerateParticleSystems()
		{
		}

		private void TryDetonate()
		{
		}

		public override void Despawn()
		{
		}

		private void PlayAudio()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetIsStar()
		{
		}
	}
}
