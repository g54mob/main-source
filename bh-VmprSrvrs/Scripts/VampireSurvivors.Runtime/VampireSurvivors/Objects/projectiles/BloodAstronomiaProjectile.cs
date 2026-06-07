using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BloodAstronomiaProjectile : Projectile
	{
		private Timer _expireTimer;

		private EggFloat _radius;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void MatchMagnetPosition()
		{
		}
	}
}
