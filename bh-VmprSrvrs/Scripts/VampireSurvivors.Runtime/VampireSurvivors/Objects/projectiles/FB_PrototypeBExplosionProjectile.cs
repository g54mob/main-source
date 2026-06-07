using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_PrototypeBExplosionProjectile : Projectile
	{
		private PhaserSprite _explosionSprite;

		private PhaserSprite _bombSprite;

		private MultiTargetTween _tweenBomb;

		private Timer _timerEvent;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void explode()
		{
		}

		public override void Despawn()
		{
		}
	}
}
