using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ConfigurableAddDefinition : SimComponentDefinition
	{
		public bool negativeA;

		public bool negativeB;

		public PortReferenceDefinition aReader = new PortReferenceDefinition(PortValueType.GENERIC, "A");

		public PortReferenceDefinition bReader = new PortReferenceDefinition(PortValueType.GENERIC, "B");

		public PortDefinition addReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "ADD_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new ConfigurableAdd(this);
		}
	}
}
