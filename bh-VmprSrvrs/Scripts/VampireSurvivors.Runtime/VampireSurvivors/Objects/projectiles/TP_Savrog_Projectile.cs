using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Savrog_Projectile : Projectile
	{
		private MultiTargetTween _tween1;

		protected PhaserSprite _spikeSprite;

		private Timer _hitboxTimer;

		private bool _isFading;

		private Timer _expireTimer;

		private float _radius;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		protected void FadeOut()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
