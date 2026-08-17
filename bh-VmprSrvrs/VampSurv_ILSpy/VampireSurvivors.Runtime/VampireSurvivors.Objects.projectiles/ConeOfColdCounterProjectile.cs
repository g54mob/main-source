using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class ConeOfColdCounterProjectile : ConeOfColdProjectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		isPlayerFacing = false;
		base.InitProjectile(pool, weapon, index);
	}

	public ConeOfColdCounterProjectile()
	{
		isPlayerFacing = true;
		((Projectile)this)._002Ector();
	}
}
