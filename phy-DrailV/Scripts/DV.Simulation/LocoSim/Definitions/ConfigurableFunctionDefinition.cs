using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ConfigurableFunctionDefinition : SimComponentDefinition
	{
		public enum FunctionType
		{
			MAX = 0,
			MIN = 1,
			SUM = 2
		}

		public FunctionType type;

		public PortReferenceDefinition[] readers;

		public PortDefinition outReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new ConfigurableFunction(this);
		}
	}
}
