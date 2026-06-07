using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Evil2_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _sprite1;

		private PhaserSprite _sprite2;

		private PhaserSprite _sprite3;

		private PhaserSprite _sprite4;

		private PhaserSprite _sprite5;

		private Tween _radiusTween;

		private MultiTargetTween _scaleTween;

		private Timer _expireTimer;

		private Timer _hitboxTimer;

		private MultiTargetTween _rotTween;

		private MultiTargetTween _alphaTween;

		private Vector2 startingVelocity;

		private float _accel;

		private MultiTargetTween _alphaTween2;

		private MultiTargetTween _scaleTween2;

		private List<bool> _cachedInRange;

		private float _cachedArea;

		private TP_Evil2_Weapon trueWeapon;

		protected override void Awake()
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

		private void DoTwilightExplosions()
		{
		}

		public override void Despawn()
		{
		}
	}
}
