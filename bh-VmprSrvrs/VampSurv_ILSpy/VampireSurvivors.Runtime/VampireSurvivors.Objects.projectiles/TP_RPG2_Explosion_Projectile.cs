namespace VampireSurvivors.Objects.Projectiles;

public class TP_RPG2_Explosion_Projectile : TP_RPG1_Explosion_Projectile
{
	public TP_RPG2_Explosion_Projectile()
	{
		base._radius = 32f;
		base._exploRadius = 16f;
		((Projectile)this)._002Ector();
	}
}
