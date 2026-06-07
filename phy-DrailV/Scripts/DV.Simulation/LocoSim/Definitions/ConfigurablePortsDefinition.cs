using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ConfigurablePortsDefinition : SimComponentDefinition
	{
		public PortDefinition[] ports;

		public float[] startingValues;

		public override SimComponent InstantiateImplementation()
		{
			return new ConfigurablePorts(this);
		}
	}
}
