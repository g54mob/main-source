using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Icicle_Projectile : Projectile
	{
		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Timer _expireTimer2;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private float _deltaTime;

		private float2 posOffset;

		private PhaserSprite _crystalSprite;

		private PhaserSprite _icicleSprite;

		private PhaserSprite _animatedSprite;

		private const float Percentage = 0.0625f;

		private const float Radius = 0.5f;

		private const float SpeedModifier = 35f;

		private List<string> _frameNames;

		private float _angle1;

		private float _angle2;

		private float _angle3;

		private bool isAiming;

		private bool isExploding;

		private TP_Icicle_Weapon trueWeapon;

		private float2 targetPosition;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void AimAtTarget()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public void Shoot()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
