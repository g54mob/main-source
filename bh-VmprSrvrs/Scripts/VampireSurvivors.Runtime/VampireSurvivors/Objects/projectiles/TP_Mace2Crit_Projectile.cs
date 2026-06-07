using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Mace2Crit_Projectile : TP_Mace2Standard_Projectile
	{
		private bool m_CanRegisterNewFrameFreeze;

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
