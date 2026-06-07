namespace LocoSim.Definitions
{
	public class PortForwardCoalOutDefinition : PortForwardBaseOutDefinition
	{
		public readonly PortDefinition simIn = new PortDefinition(PortType.IN, PortValueType.COAL, "SIM_IN");

		public readonly PortDefinition forwardOut = new PortDefinition(PortType.FORWARD_OUT, PortValueType.COAL, "FORWARD_OUT");

		protected override PortDefinition SimIn => simIn;

		protected override PortDefinition ForwardOut => forwardOut;
	}
}
