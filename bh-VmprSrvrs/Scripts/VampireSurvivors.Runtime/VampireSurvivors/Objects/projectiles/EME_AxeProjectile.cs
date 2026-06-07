using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_AxeProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _scaleTween2;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
