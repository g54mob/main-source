using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Evil0_Skull_Projectile : Projectile
	{
		private float _radius;

		private Tween _radiusTween;

		private PhaserSprite _animatedSprite;

		private PhaserSprite _jawSprite;

		private PhaserSprite _animatedSprite2;

		private PhaserSprite _jawSprite2;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private bool _isDespawning;

		private TP_Evil1_Weapon _trueWeapon;

		private float _direction;

		private Vector3 _cursorOffset;

		private float ScaledAlpha => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void FireRunes()
		{
		}

		private void StartDespawn()
		{
		}

		private void SyncSprites()
		{
		}

		public override void Despawn()
		{
		}

		private void DisplayCursorVFX(int _times, float _duration)
		{
		}
	}
}
