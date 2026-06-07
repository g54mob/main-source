using Assets.Nimbatus.Scripts.Combat;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class CreateParticleEffect : CustomTransformAction
	{
		public NimbatusParticleEffect Effect;

		public override void Execute()
		{
			if (Effect != null)
			{
				Effect.PlayEffect(GetTransform());
			}
		}
	}
}
