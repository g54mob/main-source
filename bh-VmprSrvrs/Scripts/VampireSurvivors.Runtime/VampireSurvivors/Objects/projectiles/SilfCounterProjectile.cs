using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SilfCounterProjectile : SilfProjectile
	{
		protected override string GetTrailTextureName()
		{
			return null;
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
