using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SpriteWhip_Projectile : Projectile
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

		private bool _isDespawning;

		private float _heightOffset;

		private List<string> animNames;

		private Tween _offsetTween;

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

		protected virtual void OnAnimAttackComplete()
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
