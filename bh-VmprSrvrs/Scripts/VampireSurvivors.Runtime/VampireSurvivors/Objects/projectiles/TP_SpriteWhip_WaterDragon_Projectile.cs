using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SpriteWhip_WaterDragon_Projectile : Projectile
	{
		private int AnimFPS;

		private SpriteAnimation _anim;

		private MultiTargetTween _alphaTween;

		private bool _cachedFlipX;

		private PhaserSprite _animatedSprite;

		private Vector3 _directionalOffset;

		private float _bodyRadius;

		private float _extensionLength;

		private float _extensionDuration;

		private float _heightOffset;

		private List<string> animNames;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
		{
		}

		private void SetupAnimations()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected virtual void OnAnimAttackComplete()
		{
		}

		private void AlphaTweenFinished()
		{
		}

		public override void Despawn()
		{
		}
	}
}
