using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class PowerFunctionDefinition : SimComponentDefinition
	{
		public float multiplier = 1f;

		public float exponent = 1.2f;

		public PortReferenceDefinition input = new PortReferenceDefinition(PortValueType.GENERIC, "IN");

		public PortDefinition output = new PortDefinition(PortType.READONLY_OUT, PortValueType.GENERIC, "OUT");

		public override SimComponent InstantiateImplementation()
		{
			return new PowerFunction(this);
		}
	}
}
