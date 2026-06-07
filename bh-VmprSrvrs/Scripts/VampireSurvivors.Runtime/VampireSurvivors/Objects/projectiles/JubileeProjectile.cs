using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class JubileeProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private JubileeWeapon _trueWeapon;

		private MultiTargetTween _emitterCounter;

		private int _basePixelSize;

		public float counter;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
