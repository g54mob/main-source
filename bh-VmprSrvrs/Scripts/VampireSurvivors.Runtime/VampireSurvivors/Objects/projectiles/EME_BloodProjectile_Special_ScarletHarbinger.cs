using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_BloodProjectile_Special_ScarletHarbinger : Projectile
	{
		[SerializeField]
		private List<Color> _tints;

		protected List<BlendMode> _blendModes;

		protected MultiTargetTween _alphaTween;

		protected MultiTargetTween _scaleTween;

		protected ParticleSystem _damageVfx;

		protected ParticleEmitterManager _particlesManager;

		protected GravityWell _well;

		protected Timer bloodTimer;

		protected Timer expireTimer;

		protected PhaserSprite _displaySprite;

		protected EnemyController _myTarget;

		protected bool _targetFound;

		protected bool isFirstUpdate;

		private Tween _wellTween;

		[SerializeField]
		private SpriteRenderer _rockSprite;

		[SerializeField]
		private SpriteRenderer _starSprite;

		[SerializeField]
		private SpriteRenderer _starSprite2;

		[SerializeField]
		private SpriteRenderer _bubbleSprite;

		[SerializeField]
		private SpriteAnimation _animation;

		private bool _initialisedParticles;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private MultiTargetTween _tween4;

		private MultiTargetTween _tween5;

		private MultiTargetTween _tween6;

		protected string FrameName => null;

		protected float ExpireTime => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected void MakeEmitter()
		{
		}

		private void LateUpdate()
		{
		}

		public void Activate()
		{
		}

		public override void Despawn()
		{
		}

		private void FadeOut()
		{
		}

		private void OnRecycle(float salvoDuration)
		{
		}

		private void DisplayMe(float salvoDuration)
		{
		}
	}
}
