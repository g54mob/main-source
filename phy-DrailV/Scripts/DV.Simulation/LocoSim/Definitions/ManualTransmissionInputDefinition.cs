using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ManualTransmissionInputDefinition : SimComponentDefinition
	{
		public bool gear0IsNeutral;

		public readonly PortDefinition controlExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "CONTROL_EXT_IN");

		public readonly PortReferenceDefinition reverserReader = new PortReferenceDefinition(PortValueType.CONTROL, "REVERSER");

		public readonly PortReferenceDefinition numOfGearsReader = new PortReferenceDefinition(PortValueType.GENERIC, "NUM_OF_GEARS");

		public readonly PortDefinition reverserReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "REVERSER_OUT");

		public readonly PortDefinition gearReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "GEAR");

		public override SimComponent InstantiateImplementation()
		{
			return new ManualTransmissionInput(this);
		}
	}
}
