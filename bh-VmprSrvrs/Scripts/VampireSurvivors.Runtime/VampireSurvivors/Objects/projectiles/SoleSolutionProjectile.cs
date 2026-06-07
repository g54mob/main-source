using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SoleSolutionProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private MultiTargetTween _scaleTween2;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
