using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnTemperatureChanged : NimbatusEvent
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		private HealthPool _pool;

		protected override void Subscribe()
		{
			_pool = (CustomHealthPool ? HealthPool : OwnWorldObject.HealthPool);
			if (_pool != null)
			{
				_pool.TemperatureChanged += _healthPool_tempChange;
			}
		}

		protected override void Unsubscribe()
		{
			if (_pool != null)
			{
				_pool.TemperatureChanged -= _healthPool_tempChange;
			}
		}

		private void _healthPool_tempChange(float oldTemp, float newTemp)
		{
			RaiseEvent();
		}
	}
}
