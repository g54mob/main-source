using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class TakeDamagePercentage : NimbatusAction
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public float Percent;

		public EDamageReason Reason = EDamageReason.Environment;

		public override void Execute()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
			float amount = HealthPool.ActiveMaxHealth / 100f * Percent;
			HealthPool.TakeDamage(new DamageInformation(amount, Reason, OwnWorldObject));
		}
	}
}
