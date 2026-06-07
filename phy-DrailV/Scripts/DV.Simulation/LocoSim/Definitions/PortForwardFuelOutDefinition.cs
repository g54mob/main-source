namespace LocoSim.Definitions
{
	public class PortForwardFuelOutDefinition : PortForwardBaseOutDefinition
	{
		public readonly PortDefinition simIn = new PortDefinition(PortType.IN, PortValueType.FUEL, "SIM_IN");

		public readonly PortDefinition forwardOut = new PortDefinition(PortType.FORWARD_OUT, PortValueType.FUEL, "FORWARD_OUT");

		protected override PortDefinition SimIn => simIn;

		protected override PortDefinition ForwardOut => forwardOut;
	}
}
