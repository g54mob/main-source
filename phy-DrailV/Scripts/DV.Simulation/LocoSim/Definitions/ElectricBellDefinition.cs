using LocoSim.Attributes;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class ElectricBellDefinition : SimComponentDefinition
	{
		public float smoothDownTime = 2f;

		[FuseId]
		public string powerFuseId;

		public readonly PortReferenceDefinition bellControl = new PortReferenceDefinition(PortValueType.CONTROL, "CONTROL");

		public readonly PortDefinition bellNormalizedReadOut = new PortDefinition(PortType.READONLY_OUT, PortValueType.STATE, "BELL_NORMALIZED");

		public override SimComponent InstantiateImplementation()
		{
			return new ElectricBell(this);
		}
	}
}
