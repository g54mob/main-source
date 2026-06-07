using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class GenericControlDefinition : SimComponentDefinition
	{
		public float defaultValue;

		public float smoothTime;

		public bool saveState;

		public readonly PortDefinition controlExtIn = new PortDefinition(PortType.EXTERNAL_IN, PortValueType.CONTROL, "EXT_IN");

		public readonly PortDefinition controlReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "CONTROL");

		public override SimComponent InstantiateImplementation()
		{
			return new GenericControl(this);
		}
	}
}
