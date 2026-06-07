using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class AutomaticTransmissionInputDefinition : SimComponentDefinition
	{
		public float gearUpRpmThreshold = 800f;

		public float gearDownRpmThreshold = 120f;

		public readonly PortReferenceDefinition rpmIndicatorReader = new PortReferenceDefinition(PortValueType.RPM, "RPM_INDICATOR");

		public readonly PortReferenceDefinition numOfGearsReader = new PortReferenceDefinition(PortValueType.GENERIC, "NUM_OF_GEARS");

		public readonly PortDefinition gearReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "GEAR");

		public override SimComponent InstantiateImplementation()
		{
			return new AutomaticTransmissionInput(this);
		}
	}
}
