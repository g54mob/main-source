namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Banana2_ExplosionProjectile : LEM_Banana1_ExplosionProjectile
{
	protected override float ExplosionTweenMillis => 100f;

	protected override int ExplosionFPS => 24;

	protected override float ExplosionAlpha => 0.6f;
}
