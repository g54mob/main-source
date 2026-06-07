using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnChemicalStateChanged : NimbatusEvent
	{
		public EChemicalState State;

		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		private HealthPool _pool;

		protected override void Subscribe()
		{
			_pool = (CustomHealthPool ? HealthPool : OwnWorldObject.HealthPool);
			if (_pool != null)
			{
				_pool.StateChanged += _healthPool_stateChanged;
			}
		}

		protected override void Unsubscribe()
		{
			if (_pool != null)
			{
				_pool.StateChanged -= _healthPool_stateChanged;
			}
		}

		private void _healthPool_stateChanged(EChemicalState oldstate, EChemicalState newState)
		{
			if (newState == State)
			{
				RaiseEvent();
			}
		}
	}
}
