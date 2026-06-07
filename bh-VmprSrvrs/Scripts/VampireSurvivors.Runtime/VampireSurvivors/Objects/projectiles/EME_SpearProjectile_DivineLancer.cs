namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_SpearProjectile_DivineLancer : EME_SpearProjectile
	{
		protected override float ScaleMultiplier => 0f;

		protected override float InitialSpeed => 0f;

		protected override bool UsesPortalVFX => false;

		protected override float PortalVFXScale => 0f;

		protected override void SetupTrail()
		{
		}

		protected override void PlaySfx()
		{
		}
	}
}
