using LocoSim.Implementations;
using LocoSim.Resources;

namespace LocoSim.Definitions
{
	public class CoalContainerDefinition : SimComponentDefinition, IDefaultMassProvider
	{
		public float capacity = 100f;

		public float defaultValue = 100f;

		public readonly PortDefinition coalRefillExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.COAL, "REFILL_EXT_IN");

		public readonly PortDefinition coalConsumeExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.COAL, "CONSUME_EXT_IN");

		public readonly PortDefinition amountReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "AMOUNT");

		public readonly PortDefinition normalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "NORMALIZED");

		public readonly PortDefinition capacityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.COAL, "CAPACITY");

		public override SimComponent InstantiateImplementation()
		{
			return new ResourceContainer(ID, ResourceContainerType.COAL, defaultValue, capacity, coalRefillExtIn, coalConsumeExtIn, amountReadOut, normalizedReadOut, capacityReadOut);
		}

		public float DefaultMassValue()
		{
			return defaultValue * ResourceContainerType.COAL.GetResourceMassMultiplier();
		}
	}
}
