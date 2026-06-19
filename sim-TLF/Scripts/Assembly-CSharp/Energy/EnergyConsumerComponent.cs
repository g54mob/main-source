using UnityEngine;

namespace Energy
{
	public class EnergyConsumerComponent : MonoBehaviour
	{
		[SerializeField]
		protected float _energyConsumptionRate = 1f;

		private IEnergyConsumer _defaultEnergyConsumer;

		public virtual IEnergyConsumer EnergyConsumer => _defaultEnergyConsumer;

		private void Awake()
		{
			_defaultEnergyConsumer = new DefaultEnergyConsumer(_energyConsumptionRate);
		}
	}
}
