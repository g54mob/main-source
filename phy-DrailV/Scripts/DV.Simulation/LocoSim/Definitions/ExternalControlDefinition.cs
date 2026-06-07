using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ExternalControlDefinition : SimComponentDefinition
	{
		public float defaultValue;

		public bool saveState;

		public readonly PortDefinition controlExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "EXT_IN");

		public override SimComponent InstantiateImplementation()
		{
			return new ExternalControl(this);
		}
	}
}
