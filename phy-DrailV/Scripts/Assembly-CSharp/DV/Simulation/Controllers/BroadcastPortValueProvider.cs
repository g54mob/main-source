using LocoSim.Attributes;
using LocoSim.DVExtensions.PortForward;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class BroadcastPortValueProvider : MonoBehaviour
	{
		[PortId(null, null, true)]
		public string providerPortId;

		public PortForwardConnectionType connection;

		public string connectionTag;

		private Port providerPort;

		private TrainCar car;

		private BroadcastPortValueConsumer connectedConsumer;

		private bool IsConnected => connectedConsumer != null;

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			this.car = car;
			if (!simFlow.TryGetPort(providerPortId, out providerPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BroadcastPortValueProvider isn't properly initialized. Destroying self!", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				InitializeConnectionDetection();
			}
		}

		private void InitializeConnectionDetection()
		{
			switch (connection)
			{
			case PortForwardConnectionType.COUPLED_FRONT:
				car.frontCoupler.Coupled += OnCoupled;
				car.frontCoupler.Uncoupled += OnUncoupled;
				break;
			case PortForwardConnectionType.COUPLED_REAR:
				car.rearCoupler.Coupled += OnCoupled;
				car.rearCoupler.Uncoupled += OnUncoupled;
				break;
			case PortForwardConnectionType.COUPLED_ANY:
				car.frontCoupler.Coupled += OnCoupled;
				car.rearCoupler.Coupled += OnCoupled;
				car.frontCoupler.Uncoupled += OnUncoupled;
				car.rearCoupler.Uncoupled += OnUncoupled;
				break;
			default:
				Debug.LogError(string.Format("Unexpected state: Unhandled {0}: {1}. Can't initialize properly", "PortForwardConnectionType", connection));
				break;
			}
		}

		private void OnCoupled(object sender, CoupleEventArgs e)
		{
			if (IsConnected || !PortForwardConnectionTypeUtils.IsCouplerCompatibleWithConnectionType(connection, e.thisCoupler))
			{
				return;
			}
			BroadcastPortController broadcastPortController = e.otherCoupler?.train?.SimController?.broadcastPortController;
			if (broadcastPortController == null)
			{
				return;
			}
			BroadcastPortValueConsumer[] consumers = broadcastPortController.consumers;
			foreach (BroadcastPortValueConsumer broadcastPortValueConsumer in consumers)
			{
				if (broadcastPortValueConsumer.IsCompatible(connectionTag, providerPort.valueType) && PortForwardConnectionTypeUtils.IsCouplerCompatibleWithConnectionType(broadcastPortValueConsumer.connection, e.otherCoupler))
				{
					broadcastPortValueConsumer.Connect(providerPort);
					connectedConsumer = broadcastPortValueConsumer;
					break;
				}
			}
		}

		private void OnUncoupled(object sender, UncoupleEventArgs e)
		{
			if (IsConnected && PortForwardConnectionTypeUtils.IsCouplerCompatibleWithConnectionType(connection, e.thisCoupler) && PortForwardConnectionTypeUtils.IsCouplerCompatibleWithConnectionType(connectedConsumer.connection, e.otherCoupler) && !(e.otherCoupler.train != connectedConsumer.Car))
			{
				connectedConsumer.Disconnect();
				connectedConsumer = null;
			}
		}
	}
}
