using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class FireboxSimController : MonoBehaviour
	{
		public float coalConsumptionMultiplier = 1f;

		[PortId(null, null, false)]
		public string fireboxCapacityPortId;

		[PortId(null, null, false)]
		public string fireboxContentsPortId;

		[PortId(null, null, false)]
		public string fireboxDoorPortId;

		[PortId(null, null, false)]
		public string combustionRateNormalizedPortId;

		[PortId(null, null, false)]
		public string fireOnPortId;

		[PortId(null, null, false)]
		public string fireboxCoalControlPortId;

		[PortId(null, null, false)]
		public string fireboxIgnitionPortId;

		private Port fireboxCapacityPort;

		private Port fireboxContentsPort;

		private Port fireboxDoorPort;

		private Port combustionRateNormalizedPort;

		private Port fireOnPort;

		private Port fireboxCoalControlPort;

		private Port fireboxIgnitionPort;

		public float FireboxCapacity => fireboxCapacityPort.Value;

		public float FireboxContents => fireboxContentsPort.Value;

		public float NormalizedFireboxContents => FireboxContents / FireboxCapacity;

		public float FireboxDoorOpening => fireboxDoorPort.Value;

		public float CombustionRateNormalized => combustionRateNormalizedPort.Value;

		public bool IsFireOn => fireOnPort.Value == 1f;

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(fireboxCapacityPortId, out fireboxCapacityPort) || !simFlow.TryGetPort(fireboxContentsPortId, out fireboxContentsPort) || !simFlow.TryGetPort(fireboxDoorPortId, out fireboxDoorPort) || !simFlow.TryGetPort(combustionRateNormalizedPortId, out combustionRateNormalizedPort) || !simFlow.TryGetPort(fireOnPortId, out fireOnPort) || !simFlow.TryGetPort(fireboxCoalControlPortId, out fireboxCoalControlPort) || !simFlow.TryGetPort(fireboxIgnitionPortId, out fireboxIgnitionPort))
			{
				Debug.LogError("FireboxSimController can't function! Destroying self!", this);
				Object.Destroy(this);
			}
		}

		public float SpaceForCoal()
		{
			return (FireboxCapacity - FireboxContents) * coalConsumptionMultiplier;
		}

		public void TransferCoal(float coalMass)
		{
			fireboxCoalControlPort.Value += coalMass / coalConsumptionMultiplier;
		}

		public void Ignite()
		{
			fireboxIgnitionPort.Value = 1f;
		}

		public void AddCoal()
		{
			TransferCoal(10f);
		}
	}
}
