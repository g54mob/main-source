using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class TakeDamage : NimbatusAction
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public float Amount;

		public EDamageReason Reason = EDamageReason.Environment;

		public override void Execute()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
			HealthPool.TakeDamage(new DamageInformation(Amount, Reason, OwnWorldObject));
		}
	}
}
