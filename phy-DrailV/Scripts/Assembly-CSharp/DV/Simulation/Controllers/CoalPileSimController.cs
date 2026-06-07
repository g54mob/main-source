using DV.Simulation.Cars;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class CoalPileSimController : MonoBehaviour, ICoalPile
	{
		public float coalChunkMass;

		[PortId(PortType.READONLY_OUT, PortValueType.COAL, true)]
		public string coalAvailablePortId;

		[PortId(PortType.READONLY_OUT, PortValueType.COAL, true)]
		public string coalCapacityPortId;

		[PortId(PortType.EXTERNAL_IN, PortValueType.COAL, true)]
		public string coalConsumePortId;

		private Port coalAvailablePort;

		private Port coalCapacityPort;

		private Port coalConsumePort;

		private float ConsumptionModifier => Globals.G.GameParams.ResourceConsumptionModifier;

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(coalAvailablePortId, out coalAvailablePort) || !simFlow.TryGetPort(coalCapacityPortId, out coalCapacityPort) || !simFlow.TryGetPort(coalConsumePortId, out coalConsumePort))
			{
				Debug.LogError("CoalPileSimController can't function! Destroying self!", this);
				Object.Destroy(this);
			}
		}

		public float CoalChunkMass()
		{
			return coalChunkMass;
		}

		public float CoalAvailable()
		{
			if (ConsumptionModifier == 0f)
			{
				return coalAvailablePort.Value;
			}
			return coalAvailablePort.Value / ConsumptionModifier;
		}

		public float SpaceForCoal()
		{
			float num = coalCapacityPort.Value - coalAvailablePort.Value;
			if (ConsumptionModifier == 0f)
			{
				return num;
			}
			return num / ConsumptionModifier;
		}

		public float TryAddCoal(float desiredCoalAmount)
		{
			float num = Mathf.Min(SpaceForCoal(), desiredCoalAmount);
			coalConsumePort.ExternalValueUpdate((0f - num) * ConsumptionModifier);
			return num;
		}

		public float TryRemoveCoal(float desiredCoalAmount)
		{
			float num = Mathf.Min(CoalAvailable(), desiredCoalAmount);
			coalConsumePort.ExternalValueUpdate(num * ConsumptionModifier);
			return num;
		}

		public void TransferToFirebox(FireboxSimController fireboxController, byte chunkCount)
		{
			float num = (float)(int)chunkCount * coalChunkMass;
			if (!(num < float.Epsilon) && !(fireboxController.SpaceForCoal() < num))
			{
				float coalMass = TryRemoveCoal(num);
				fireboxController.TransferCoal(coalMass);
			}
		}
	}
}
