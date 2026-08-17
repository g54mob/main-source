namespace VampireSurvivors.Objects.Projectiles;

public class HolyWandProjectile : MagicMissileProjectile
{
	public HolyWandProjectile()
	{
		base._IndexOffsetScaleFactor = 0.1f;
		((Projectile)this)._002Ector();
	}
}
