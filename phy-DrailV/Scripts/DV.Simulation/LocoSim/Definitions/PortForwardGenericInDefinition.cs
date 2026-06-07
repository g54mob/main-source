namespace LocoSim.Definitions
{
	public class PortForwardGenericInDefinition : PortForwardBaseInDefinition
	{
		public readonly PortDefinition forwardIn = new PortDefinition(PortType.FORWARD_IN, PortValueType.GENERIC, "FORWARD_IN");

		public readonly PortDefinition simOut = new PortDefinition(PortType.OUT, PortValueType.GENERIC, "SIM_OUT");

		protected override PortDefinition ForwardIn => forwardIn;

		protected override PortDefinition SimOut => simOut;
	}
}
