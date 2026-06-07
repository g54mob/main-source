using System.Collections.Generic;
using DG.Tweening;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Gear_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _animatedSprite;

		private PhaserSprite _animatedSprite2;

		private Tween _radiusTween;

		private MultiTargetTween _scaleTween;

		private float __force;

		private Tween _forceTween;

		private float _saveVelX;

		private float _saveVelY;

		private bool _isDespawning;

		private List<string> _framesFront;

		private List<string> _framesBack;

		private MultiTargetTween _angleTween;

		private Timer _expireTimer;

		private Timer _hitBoxTimer;

		private MultiTargetTween _angleTween2;

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
	}
}
