using LocoSim.Attributes;
using LocoSim.DVExtensions.PortForward;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class BroadcastPortValueConsumer : MonoBehaviour
	{
		[PortId(null, null, true)]
		public string consumerPortId;

		public PortForwardConnectionType connection;

		public string connectionTag;

		public float disconnectedValue;

		public bool propagateConsumerValueChangeBackToProvider;

		private Port consumerPort;

		private Port providerPort;

		public TrainCar Car { get; private set; }

		private bool IsConnected => providerPort != null;

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			Car = car;
			if (!simFlow.TryGetPort(consumerPortId, out consumerPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BroadcastPortValueProvider isn't properly initialized. Destroying self!", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				consumerPort.Value = disconnectedValue;
			}
		}

		public bool IsCompatible(string providerConnectionTag, PortValueType providerValueType)
		{
			if (!IsConnected && providerValueType == consumerPort.valueType)
			{
				return providerConnectionTag == connectionTag;
			}
			return false;
		}

		public void Connect(Port providerPort)
		{
			this.providerPort = providerPort;
			OnProviderValueChange(providerPort.Value);
			providerPort.ValueUpdatedInternally += OnProviderValueChange;
			if (propagateConsumerValueChangeBackToProvider)
			{
				consumerPort.ValueUpdatedInternally += OnConsumerValueChange;
			}
		}

		public void Disconnect()
		{
			if (providerPort != null)
			{
				providerPort.ValueUpdatedInternally -= OnProviderValueChange;
			}
			providerPort = null;
			if (propagateConsumerValueChangeBackToProvider)
			{
				consumerPort.ValueUpdatedInternally -= OnConsumerValueChange;
			}
			consumerPort.Value = disconnectedValue;
		}

		private void OnProviderValueChange(float _)
		{
			float value = providerPort.Value;
			if (consumerPort.Value != value)
			{
				consumerPort.Value = value;
			}
		}

		private void OnConsumerValueChange(float _)
		{
			float value = consumerPort.Value;
			if (providerPort.Value != value)
			{
				providerPort.Value = value;
			}
		}
	}
}
