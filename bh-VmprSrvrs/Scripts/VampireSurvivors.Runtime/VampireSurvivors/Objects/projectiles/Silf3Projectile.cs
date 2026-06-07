using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Silf3Projectile : SilfProjectile
	{
		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override string GetTrailTextureName()
		{
			return null;
		}

		protected override PhaserSpline GetSpline()
		{
			return null;
		}
	}
}
