using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class Heal : NimbatusAction
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public float Amount;

		public override void Execute()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
			HealthPool.Heal(Amount);
		}
	}
}
