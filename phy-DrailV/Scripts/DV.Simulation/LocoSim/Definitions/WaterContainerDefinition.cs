using LocoSim.Implementations;
using LocoSim.Resources;

namespace LocoSim.Definitions
{
	public class WaterContainerDefinition : SimComponentDefinition, IDefaultMassProvider
	{
		public float capacity = 100f;

		public float defaultValue = 100f;

		public readonly PortDefinition waterRefillExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.WATER, "REFILL_EXT_IN");

		public readonly PortDefinition waterConsumeExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.WATER, "CONSUME_EXT_IN");

		public readonly PortDefinition amountReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.WATER, "AMOUNT");

		public readonly PortDefinition normalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.WATER, "NORMALIZED");

		public readonly PortDefinition capacityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.WATER, "CAPACITY");

		public override SimComponent InstantiateImplementation()
		{
			return new ResourceContainer(ID, ResourceContainerType.WATER, defaultValue, capacity, waterRefillExtIn, waterConsumeExtIn, amountReadOut, normalizedReadOut, capacityReadOut);
		}

		public float DefaultMassValue()
		{
			return defaultValue * ResourceContainerType.WATER.GetResourceMassMultiplier();
		}
	}
}
