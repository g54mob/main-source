using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MirageRobeProjectile : Projectile
	{
		private Timer _expireTimer;

		private string _textureName;

		private string _frameName;

		private float _amount;

		private MultiTargetTween _fadeOutTween;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public void FadeOut()
		{
		}
	}
}
