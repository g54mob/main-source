using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Shield1_Projectile : Projectile
	{
		private float _bodyRadius;

		private PhaserSprite _displaySprite1;

		private PhaserSprite _displaySprite2;

		private MultiTargetTween _alphaTween1;

		private MultiTargetTween _alphaTween2;

		private Timer _hitBoxTimer;

		private Timer _durationTimer;

		private TP_Shield1_Weapon _trueWeapon;

		private Timer _selfDelayTimer;

		private bool _canShoot;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void StartDespawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePosition()
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
