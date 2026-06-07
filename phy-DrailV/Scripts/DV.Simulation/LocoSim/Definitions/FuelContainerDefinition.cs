using LocoSim.Implementations;
using LocoSim.Resources;

namespace LocoSim.Definitions
{
	public class FuelContainerDefinition : SimComponentDefinition, IDefaultMassProvider
	{
		public float capacity = 100f;

		public float defaultValue = 100f;

		public readonly PortDefinition fuelRefillExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.FUEL, "REFILL_EXT_IN");

		public readonly PortDefinition fuelConsumeExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.FUEL, "CONSUME_EXT_IN");

		public readonly PortDefinition amountReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.FUEL, "AMOUNT");

		public readonly PortDefinition normalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.FUEL, "NORMALIZED");

		public readonly PortDefinition capacityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.FUEL, "CAPACITY");

		public override SimComponent InstantiateImplementation()
		{
			return new ResourceContainer(ID, ResourceContainerType.FUEL, defaultValue, capacity, fuelRefillExtIn, fuelConsumeExtIn, amountReadOut, normalizedReadOut, capacityReadOut);
		}

		public float DefaultMassValue()
		{
			return defaultValue * ResourceContainerType.FUEL.GetResourceMassMultiplier();
		}
	}
}
