using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Guns2CounterProjectile : Guns2Projectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		_firingAngles = new float[4] { 45f, -45f, 225f, -225f };
		((GunsProjectile)this).InitProjectile(pool, weapon, index);
	}
}
