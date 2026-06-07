using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class BasePortsOverrider : MonoBehaviour
	{
		[PortId(PortType.EXTERNAL_IN, PortValueType.WATER, false)]
		[Header("Steamer")]
		public string boilerSpecialRequestPortId;

		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, false)]
		public string oilingPointsSpecialRequestPortId;

		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, false)]
		public string lubricatorSpecialRequestPortId;

		private Port boilerSpecialRequestPort;

		private Port oilingPointsSpecialRequestPort;

		private Port lubricatorSpecialRequestPort;

		public void BoilerSpecialRequest(float requestValue)
		{
			boilerSpecialRequestPort?.ExternalValueUpdate(requestValue);
		}

		public void OilingPointsSpecialRequest(float requestValue)
		{
			oilingPointsSpecialRequestPort?.ExternalValueUpdate(requestValue);
		}

		public void LubricatorSpecialRequest(float requestValue)
		{
			lubricatorSpecialRequestPort?.ExternalValueUpdate(requestValue);
		}

		public void Init(SimulationFlow simFlow)
		{
			simFlow.TryGetPort(boilerSpecialRequestPortId, out boilerSpecialRequestPort, canBeNullOrEmpty: true);
			simFlow.TryGetPort(oilingPointsSpecialRequestPortId, out oilingPointsSpecialRequestPort, canBeNullOrEmpty: true);
			simFlow.TryGetPort(lubricatorSpecialRequestPortId, out lubricatorSpecialRequestPort, canBeNullOrEmpty: true);
		}
	}
}
