using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace LocoSim.Definitions
{
	public class SanderDefinition : SimComponentDefinition
	{
		public float sandConsumptionRate = 5f;

		[Min(1f)]
		public float sandCoeficientMax = 1.5f;

		[Header("Optional")]
		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition sand = new PortReferenceDefinition(PortValueType.SAND, "SAND");

		public readonly PortReferenceDefinition sandConsumption = new PortReferenceDefinition(PortValueType.SAND, "SAND_CONSUMPTION", writeAllowed: true);

		public readonly PortDefinition controlExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "CONTROL_EXT_IN");

		public readonly PortDefinition sandCoefReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "SAND_COEF");

		public readonly PortDefinition sandFlowReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.SAND, "SAND_FLOW");

		public override SimComponent InstantiateImplementation()
		{
			return new Sander(this);
		}
	}
}
