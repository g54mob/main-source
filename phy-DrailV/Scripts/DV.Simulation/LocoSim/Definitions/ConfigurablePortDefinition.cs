using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ConfigurablePortDefinition : SimComponentDefinition
	{
		public float value;

		public PortDefinition port;

		public override SimComponent InstantiateImplementation()
		{
			return new ConfigurablePort(this);
		}
	}
}
