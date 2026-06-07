namespace LocoSim.Definitions
{
	public class PortForwardCoalInDefinition : PortForwardBaseInDefinition
	{
		public readonly PortDefinition forwardIn = new PortDefinition(PortType.FORWARD_IN, PortValueType.COAL, "FORWARD_IN");

		public readonly PortDefinition simOut = new PortDefinition(PortType.OUT, PortValueType.COAL, "SIM_OUT");

		protected override PortDefinition ForwardIn => forwardIn;

		protected override PortDefinition SimOut => simOut;
	}
}
