using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class WaterDetectorDefinition : SimComponentDefinition
	{
		public readonly PortDefinition stateExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.STATE, "STATE_EXT_IN");

		public override SimComponent InstantiateImplementation()
		{
			return new WaterDetector(this);
		}
	}
}
