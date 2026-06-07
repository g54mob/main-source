using LocoSim.Implementations;
using LocoSim.Resources;

namespace LocoSim.Definitions
{
	public class OilContainerDefinition : SimComponentDefinition, IDefaultMassProvider
	{
		public float capacity = 100f;

		public float defaultValue = 100f;

		public readonly PortDefinition oilRefillExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.OIL, "REFILL_EXT_IN");

		public readonly PortDefinition oilConsumeExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.OIL, "CONSUME_EXT_IN");

		public readonly PortDefinition amountReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.OIL, "AMOUNT");

		public readonly PortDefinition normalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.OIL, "NORMALIZED");

		public readonly PortDefinition capacityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.OIL, "CAPACITY");

		public override SimComponent InstantiateImplementation()
		{
			return new ResourceContainer(ID, ResourceContainerType.OIL, defaultValue, capacity, oilRefillExtIn, oilConsumeExtIn, amountReadOut, normalizedReadOut, capacityReadOut);
		}

		public float DefaultMassValue()
		{
			return defaultValue * ResourceContainerType.OIL.GetResourceMassMultiplier();
		}
	}
}
