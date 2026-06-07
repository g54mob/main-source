using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_AxeProjectile_ReverseDelta : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private EME_RapierWeapon _trueWeapon;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _pfxEmitter;

		[SerializeField]
		private TrailRenderer _Trail1;

		[SerializeField]
		private TrailRenderer _Trail2;

		[SerializeField]
		private TrailRenderer _Trail3;

		[SerializeField]
		private ParticleSystem punchVFX;

		[SerializeField]
		private MeshRenderer _Quad1;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private Timer _DespawnTimer;

		private PhaserSprite _displayImage;

		private float _offsetX;

		private MultiTargetTween slashTween;

		private MultiTargetTween modelTween1;

		private MultiTargetTween modelTween2;

		private Timer _hitboxTimer;

		private PhaserSprite cloneImage1;

		private PhaserSprite cloneImage2;

		private PhaserSprite cloneImage3;

		private MultiTargetTween clonesAlphaTween;

		private Vector2[] _deltaPoints;

		private List<Vector2> _currentDelta;

		private float _radius;

		private bool _isAttacking;

		private float _attackTime;

		private Timer _attackAnimTimer;

		private Tween _materialFadeTween;

		private MultiTargetTween _blockAlphaTween;

		private int _strikeTimes;

		private void LateUpdate()
		{
		}

		private void MakeCloneSprites()
		{
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Activate()
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void FadeClonesAlphaTo(float fadeToValue)
		{
		}

		private void PlayStrikeAnim(float delay)
		{
		}
	}
}
