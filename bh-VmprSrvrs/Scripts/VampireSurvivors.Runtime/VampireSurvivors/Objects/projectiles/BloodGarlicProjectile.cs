using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BloodGarlicProjectile : Projectile
	{
		private Timer _expireTimer;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _angleTween;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void OverrideWeaponData(Weapon weapon)
		{
		}

		private void FadeOut()
		{
		}
	}
}
