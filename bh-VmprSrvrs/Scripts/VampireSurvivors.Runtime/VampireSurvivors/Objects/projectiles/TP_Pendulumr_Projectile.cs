using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Pendulumr_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _pendulumSprite;

		private PhaserSprite _shaftSprite;

		private PhaserSprite _stretchSprite;

		private Tween _radiusTween;

		private MultiTargetTween _scaleTween;

		private bool _isDespawning;

		private MultiTargetTween _angleTween;

		private Timer _expireTimer;

		private Timer _hitBoxTimer;

		private Vector3 penOrigin;

		private float _elapsedTime;

		private float _currentLength;

		private int _swingDirection;

		private float _previousAngle;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void LateUpdate()
		{
		}

		public Vector2 GetPositionAtTime(float time)
		{
			return default(Vector2);
		}

		private void CheckForDirectionChange(float angle)
		{
		}

		private void PlaySfx()
		{
		}
	}
}
