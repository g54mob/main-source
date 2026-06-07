using LocoSim.Attributes;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class HornDefinition : SimComponentDefinition
	{
		public bool controlNeutralAt0;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition hornControlReader = new PortReferenceDefinition(PortValueType.CONTROL, "HORN_CONTROL");

		public readonly PortDefinition hornReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.CONTROL, "HORN");

		public override SimComponent InstantiateImplementation()
		{
			return new Horn(this);
		}
	}
}
