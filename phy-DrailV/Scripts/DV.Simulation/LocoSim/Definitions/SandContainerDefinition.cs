using LocoSim.Implementations;
using LocoSim.Resources;

namespace LocoSim.Definitions
{
	public class SandContainerDefinition : SimComponentDefinition, IDefaultMassProvider
	{
		public float capacity = 200f;

		public float defaultValue = 200f;

		public readonly PortDefinition sandRefillExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.SAND, "REFILL_EXT_IN");

		public readonly PortDefinition sandConsumeExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.SAND, "CONSUME_EXT_IN");

		public readonly PortDefinition amountReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.SAND, "AMOUNT");

		public readonly PortDefinition normalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.SAND, "NORMALIZED");

		public readonly PortDefinition capacityReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.SAND, "CAPACITY");

		public override SimComponent InstantiateImplementation()
		{
			return new ResourceContainer(ID, ResourceContainerType.SAND, defaultValue, capacity, sandRefillExtIn, sandConsumeExtIn, amountReadOut, normalizedReadOut, capacityReadOut);
		}

		public float DefaultMassValue()
		{
			return defaultValue * ResourceContainerType.SAND.GetResourceMassMultiplier();
		}
	}
}
