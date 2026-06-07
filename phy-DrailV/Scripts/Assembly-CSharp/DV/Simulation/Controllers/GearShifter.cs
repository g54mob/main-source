using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class GearShifter : MonoBehaviour
	{
		[PortId(PortType.READONLY_OUT, PortValueType.GENERIC, true)]
		public string currentGearRatioPortId;

		public bool isGearboxA;

		private Port currentGearRatio;

		public bool InNeutral => GearRatio == 0f;

		public float GearRatio
		{
			get
			{
				if (currentGearRatio == null)
				{
					return 0f;
				}
				return currentGearRatio.Value;
			}
		}

		public void Init(SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(currentGearRatioPortId, out currentGearRatio))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: GearShifter isn't initialized properly");
			}
		}
	}
}
