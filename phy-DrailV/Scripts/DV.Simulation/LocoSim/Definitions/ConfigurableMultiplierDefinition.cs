using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ConfigurableMultiplierDefinition : SimComponentDefinition
	{
		public bool invertA;

		public bool invertB;

		public PortReferenceDefinition aReader = new PortReferenceDefinition(PortValueType.GENERIC, "A");

		public PortReferenceDefinition bReader = new PortReferenceDefinition(PortValueType.GENERIC, "B");

		public PortDefinition mulReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "MUL_OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new ConfigurableMultiplier(this);
		}
	}
}
