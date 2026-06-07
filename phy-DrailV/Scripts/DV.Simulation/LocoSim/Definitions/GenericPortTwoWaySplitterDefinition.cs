using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class GenericPortTwoWaySplitterDefinition : SimComponentDefinition
	{
		public readonly PortDefinition portIn = new PortDefinition(PortType.IN, PortValueType.GENERIC, "PORT_IN");

		public readonly PortDefinition port1Out = new PortDefinition(PortType.OUT, PortValueType.GENERIC, "PORT1_OUT");

		public readonly PortDefinition port2Out = new PortDefinition(PortType.OUT, PortValueType.GENERIC, "PORT2_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new GenericPortTwoWaySplitter(this);
		}
	}
}
