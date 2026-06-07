using System;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BoneGiantProjectile : Projectile
	{
		private MultiTargetTween _angleTween;

		private MultiTargetTween _scaleTween;

		private float _saveVelX;

		private float _saveVelY;

		private Timer _bounceTimer;

		private bool _canBounce;

		private bool _isAttached;

		private bool _isSpinning;

		[NonSerialized]
		public PhaserSprite _displaySprite;

		[NonSerialized]
		public Vector2 _anchorPosition;

		private MultiTargetTween _attachTween;

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void CreateDisplaySprite()
		{
		}

		public void Attach()
		{
		}

		public void OnAttached()
		{
		}

		public void Detach(float angle)
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected void Bounce(Body bdy, bool up, bool down, bool left, bool right)
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

		public override void Despawn()
		{
		}

		public void AdjustBodyOffset()
		{
		}

		public void Spinnn(float angle, float duration, int times)
		{
		}

		public void SetProjectileVisible(bool visible)
		{
		}
	}
}
