using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class SetTemperature : NimbatusAction
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public float Amount;

		private HealthPool _pool;

		public override void Execute()
		{
			_pool = (CustomHealthPool ? HealthPool : OwnWorldObject.HealthPool);
			_pool.SetTemperature(Amount);
		}
	}
}
