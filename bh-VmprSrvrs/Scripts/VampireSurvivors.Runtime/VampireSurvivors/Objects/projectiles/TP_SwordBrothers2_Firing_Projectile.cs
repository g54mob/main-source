using DG.Tweening;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SwordBrothers2_Firing_Projectile : Projectile
	{
		private const float Radius = 36f;

		private Tween _scaleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void ScaleUp()
		{
		}

		public override void Despawn()
		{
		}
	}
}
