using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Silf2Projectile : SilfProjectile
	{
		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override string GetTrailTextureName()
		{
			return null;
		}
	}
}
