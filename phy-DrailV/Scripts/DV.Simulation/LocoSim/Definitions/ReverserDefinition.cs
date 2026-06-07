using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ReverserDefinition : SimComponentDefinition
	{
		public bool isAnalog;

		public readonly PortDefinition controlExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "CONTROL_EXT_IN");

		public readonly PortDefinition reverserReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "REVERSER");

		public override SimComponent InstantiateImplementation()
		{
			return new Reverser(this);
		}
	}
}
