using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class VentoProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private readonly uint[] _color;

		private SpriteAnimation _anims;

		private float prevArea;

		public override float ProjectileSpeed => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
