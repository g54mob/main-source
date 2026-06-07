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
	public class TP_Evil1_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _displaySprite;

		private PhaserSprite _displaySprite2;

		private Tween _radiusTween;

		private List<string> frames;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _alphaTween2;

		private Vector2 _sineOffset;

		private float _sineTime;

		private float _sineRadius;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		public void SetDirection(float dir)
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
