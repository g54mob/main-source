namespace LocoSim.Definitions
{
	public class PortForwardWaterInDefinition : PortForwardBaseInDefinition
	{
		public readonly PortDefinition forwardIn = new PortDefinition(PortType.FORWARD_IN, PortValueType.WATER, "FORWARD_IN");

		public readonly PortDefinition simOut = new PortDefinition(PortType.OUT, PortValueType.WATER, "SIM_OUT");

		protected override PortDefinition ForwardIn => forwardIn;

		protected override PortDefinition SimOut => simOut;
	}
}
