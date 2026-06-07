namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Discus2_Projectile : TP_Discus1_Projectile
	{
		protected override float SpeedFactor => 0f;

		protected override bool CanBounce => false;

		protected override string FrameName => null;
	}
}
