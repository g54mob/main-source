using System.Collections.Generic;
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
	public class TP_Frog_Projectile : Projectile
	{
		[SerializeField]
		private SpriteTrail _SpriteTrail;

		private const float Radius = 10f;

		private readonly Vector2 SquashedScale;

		private TP_Frog_Weapon _trueWeapon;

		protected PhaserSprite _frogSprite;

		private List<Vector3> _frogSpritePositions;

		private Vector2 _nextJumpPos;

		private float _cachedWeaponArea;

		private Timer _moveTimer;

		private Timer _expireTimer;

		private Tween _posTween;

		private MultiTargetTween _posTween2;

		protected MultiTargetTween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitSpriteTrail()
		{
		}

		private void StartTimers()
		{
		}

		private void PlaySfx()
		{
		}

		protected virtual void ScaleIn()
		{
		}

		private void ScaleOut()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateBody()
		{
		}

		private void UpdateDepth()
		{
		}

		private void UpdateSpriteTrailPositions()
		{
		}

		private void CalculateNextJump(bool firstJump = false)
		{
		}

		public void Jump(Vector2 destintion)
		{
		}

		public void IdleOnSpawn()
		{
		}

		private void Idle()
		{
		}

		private void PlayFrogAnim(string animName)
		{
		}

		public void SetFlipX(bool flipX)
		{
		}

		private void DisableSpriteTrail()
		{
		}

		public override void Despawn()
		{
		}
	}
}
