using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Shield2_Meteor_Projectile : Projectile
	{
		[SerializeField]
		private SpriteTrail spriteTrail;

		private MultiTargetTween _posTween;

		private SpriteAnimation _anim;

		private Timer _durationTimer;

		private PhaserSprite _animatedSprite;

		private PhaserSprite _animatedSprite2;

		private MultiTargetTween _scaleTween;

		private float radius;

		private float _accelMul;

		private float maxDist;

		private Vector2 initialVelocity;

		private Tween accelTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private bool _isDespawning;

		private bool _increaseAngle;

		private float _intendedAngle;

		private MultiTargetTween _alphaTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnUpdate()
		{
		}

		public void SetAngleVelocity(float _angle)
		{
		}

		private void Spinnn()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
