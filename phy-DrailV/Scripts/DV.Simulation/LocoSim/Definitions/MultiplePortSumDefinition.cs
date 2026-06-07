using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class MultiplePortSumDefinition : SimComponentDefinition
	{
		public PortReferenceDefinition[] inputs;

		public PortDefinition output = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new MultiplePortSum(this);
		}
	}
}
