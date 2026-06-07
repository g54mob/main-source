using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Earth2_Projectile : Projectile
	{
		private float _radius;

		private float _alpha;

		private PhaserSprite _animatedSprite;

		private float _startingAngle;

		private float _rotationSpeed;

		private bool _isDespawning;

		private TP_Earth2_Weapon _parentWeapon;

		private List<uint> _tints;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _tintTween;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
