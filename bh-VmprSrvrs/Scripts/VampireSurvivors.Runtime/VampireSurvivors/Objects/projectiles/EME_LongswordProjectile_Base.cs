using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_LongswordProjectile_Base : Projectile
	{
		protected float Radius;

		private PhaserSprite _animatedSprite;

		private Timer _hitboxTimer;

		private MultiTargetTween _fadeOutTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupMechanics()
		{
		}

		private void SetupVisuals()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdatePositionAndScale()
		{
		}

		public override void Despawn()
		{
		}
	}
}
