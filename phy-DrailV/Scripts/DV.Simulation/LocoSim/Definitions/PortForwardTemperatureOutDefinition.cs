namespace LocoSim.Definitions
{
	public class PortForwardTemperatureOutDefinition : PortForwardBaseOutDefinition
	{
		public readonly PortDefinition simIn = new PortDefinition(PortType.IN, PortValueType.TEMPERATURE, "SIM_IN");

		public readonly PortDefinition forwardOut = new PortDefinition(PortType.FORWARD_OUT, PortValueType.TEMPERATURE, "FORWARD_OUT");

		protected override PortDefinition SimIn => simIn;

		protected override PortDefinition ForwardOut => forwardOut;
	}
}
