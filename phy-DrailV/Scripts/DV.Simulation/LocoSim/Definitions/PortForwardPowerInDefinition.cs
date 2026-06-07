namespace LocoSim.Definitions
{
	public class PortForwardPowerInDefinition : PortForwardBaseInDefinition
	{
		public readonly PortDefinition forwardIn = new PortDefinition(PortType.FORWARD_IN, PortValueType.POWER, "FORWARD_IN");

		public readonly PortDefinition simOut = new PortDefinition(PortType.OUT, PortValueType.POWER, "SIM_OUT");

		protected override PortDefinition ForwardIn => forwardIn;

		protected override PortDefinition SimOut => simOut;
	}
}
