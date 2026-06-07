using LocoSim.Implementations;
using LocoSim.Resources;

namespace LocoSim.Definitions
{
	public class ElectricChargeContainerDefinition : SimComponentDefinition
	{
		public float capacity = 1000f;

		public float defaultValue = 1000f;

		public readonly PortDefinition electricChargeRefillExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.ELECTRIC_CHARGE, "REFILL_EXT_IN");

		public readonly PortDefinition electricChargeConsumeExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.ELECTRIC_CHARGE, "CONSUME_EXT_IN");

		public readonly PortDefinition amountReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.ELECTRIC_CHARGE, "AMOUNT");

		public readonly PortDefinition normalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.ELECTRIC_CHARGE, "NORMALIZED");

		public readonly PortDefinition capacityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.ELECTRIC_CHARGE, "CAPACITY");

		public override SimComponent InstantiateImplementation()
		{
			return new ResourceContainer(ID, ResourceContainerType.ELECTRIC_CHARGE, defaultValue, capacity, electricChargeRefillExtIn, electricChargeConsumeExtIn, amountReadOut, normalizedReadOut, capacityReadOut);
		}
	}
}
