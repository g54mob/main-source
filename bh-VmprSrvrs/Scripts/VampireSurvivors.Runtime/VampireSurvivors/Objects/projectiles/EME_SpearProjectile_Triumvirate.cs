using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_SpearProjectile_Triumvirate : EME_SpearProjectile
	{
		protected override float ScaleMultiplier => 0f;

		protected override float InitialSpeed => 0f;

		protected override float DecelRate => 0f;

		protected override bool UsesPortalVFX => false;

		protected override string GetSpearSpriteName(WeaponType weapon)
		{
			return null;
		}

		protected override void SetupTrail()
		{
		}

		protected override void PlaySfx()
		{
		}
	}
}
