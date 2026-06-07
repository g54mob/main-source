using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Pneuma_Projectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}
	}
}
