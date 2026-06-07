using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Unused_TP_AlchemyWhipBasic_Projectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _posTween;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}
	}
}
