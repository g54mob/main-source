namespace LocoSim.Definitions
{
	public class PortForwardTorqueOutDefinition : PortForwardBaseOutDefinition
	{
		public readonly PortDefinition simIn = new PortDefinition(PortType.IN, PortValueType.TORQUE, "SIM_IN");

		public readonly PortDefinition forwardOut = new PortDefinition(PortType.FORWARD_OUT, PortValueType.TORQUE, "FORWARD_OUT");

		protected override PortDefinition SimIn => simIn;

		protected override PortDefinition ForwardOut => forwardOut;
	}
}
