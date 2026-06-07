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
	public class TP_Dominus1_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _animatedSprite;

		private Tween _radiusTween;

		private bool _isDespawning;

		private List<uint> _tints;

		private MultiTargetTween _scaleTween;

		private Timer _expireTimer;

		private bool _canMove;

		private MultiTargetTween _speedTween;

		private bool _isMoving;

		private string start;

		private string loop;

		private string startInverse;

		private string loopInverse;

		private TP_Dominus1_Weapon _trueWeapon;

		private bool inverted;

		private Vector2 _initialVelocity;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private float _amount;

		private List<InvisibleProjectile> _damageBoxes;

		private float _targetRadius;

		private ParticleSystem _pfxInverse;

		private List<string> _normalPFXFrames;

		private List<string> _inversePFXFrames;

		private Tween speedTween;

		protected override void Awake()
		{
		}

		public void OverrideVelocity(Vector2 velocity)
		{
		}

		public void SetDamageBoxes(List<InvisibleProjectile> invis)
		{
		}

		public void LoopAnim()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
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
