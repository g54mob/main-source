using DG.Tweening;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_CrossbowCrashProjectile : Projectile
	{
		private FB_CrossbowCrashWeapon _crossbowCrash;

		private MultiTargetTween _fadeOutTween;

		private Tween _damageOnlyTimer;

		private Timer _fadeOutTimer;

		private MultiTargetTween _scaleTween;

		private Timer _hitboxTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
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
