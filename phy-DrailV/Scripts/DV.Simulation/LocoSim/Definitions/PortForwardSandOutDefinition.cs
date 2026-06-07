namespace LocoSim.Definitions
{
	public class PortForwardSandOutDefinition : PortForwardBaseOutDefinition
	{
		public readonly PortDefinition simIn = new PortDefinition(PortType.IN, PortValueType.SAND, "SIM_IN");

		public readonly PortDefinition forwardOut = new PortDefinition(PortType.FORWARD_OUT, PortValueType.SAND, "FORWARD_OUT");

		protected override PortDefinition SimIn => simIn;

		protected override PortDefinition ForwardOut => forwardOut;
	}
}
