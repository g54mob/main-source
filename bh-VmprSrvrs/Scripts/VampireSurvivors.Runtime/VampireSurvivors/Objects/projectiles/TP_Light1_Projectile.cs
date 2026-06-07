using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Light1_Projectile : Projectile
	{
		private List<Projectile> _orbiters;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private float2 _centralPos;

		private float _angleInc;

		private float _flipNum;

		private Timer _expireTimer;

		protected SpriteAnimation _spriteAnimator;

		private float radiusMul;

		private TweenerCore<float, float, FloatOptions> radiusTween;

		private int _flipDir;

		protected PhaserSprite _glowSprite;

		private const float goldenRatio = 1.618034f;

		protected TP_Light1_Weapon _trueWeapon;

		public virtual float BodyRadius => 0f;

		public virtual float Scale => 0f;

		public virtual float Depth => 0f;

		public virtual bool HasOrbiters => false;

		public virtual int InvertMotion => 0;

		protected override void Awake()
		{
		}

		public virtual void MakeSpriteAnimation()
		{
		}

		protected virtual void InitAlpha()
		{
		}

		protected virtual void PlayFiringSfx()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void StartDespawn()
		{
		}

		private void TryDespawn()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}
	}
}
