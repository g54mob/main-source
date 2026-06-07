namespace LocoSim.Definitions
{
	public class PortForwardForceInDefinition : PortForwardBaseInDefinition
	{
		public readonly PortDefinition forwardIn = new PortDefinition(PortType.FORWARD_IN, PortValueType.FORCE, "FORWARD_IN");

		public readonly PortDefinition simOut = new PortDefinition(PortType.OUT, PortValueType.FORCE, "SIM_OUT");

		protected override PortDefinition ForwardIn => forwardIn;

		protected override PortDefinition SimOut => simOut;
	}
}
