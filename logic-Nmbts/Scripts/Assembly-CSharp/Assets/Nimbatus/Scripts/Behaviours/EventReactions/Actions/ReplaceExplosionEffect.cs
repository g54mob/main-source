using Assets.Nimbatus.Scripts.Combat;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ReplaceExplosionEffect : NimbatusAction
	{
		public NimbatusParticleEffect NewExplosionEffect;

		public override void Execute()
		{
			OwnWorldObject.ExplosionEffect = NewExplosionEffect;
		}
	}
}
