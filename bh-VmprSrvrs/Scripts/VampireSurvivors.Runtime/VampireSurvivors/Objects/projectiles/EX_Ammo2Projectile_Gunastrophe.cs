using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_Ammo2Projectile_Gunastrophe : Projectile
	{
		private Timer _fadeOutTimer;

		private Timer _despawnTimer;

		private Bounds _cameraBounds;

		private Tween _damageOnlyTimer;

		private MultiTargetTween _scaleTween;

		private const int _fps = 60;

		private const double _frameTime = 1.0 / 60.0;

		private const double _frameTimeMS = 16.666666666666668;

		private double _elapsed;

		private bool _aftershockDamageMovement;

		private Ex_Ammo2Weapon _ammo2Weapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void HandleAftershockDamage()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void Shoot()
		{
		}
	}
}
