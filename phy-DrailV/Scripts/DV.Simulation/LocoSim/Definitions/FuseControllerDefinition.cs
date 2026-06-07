using LocoSim.Attributes;
using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class FuseControllerDefinition : SimComponentDefinition
	{
		public float setThreshold = 0.5f;

		public bool isActiveWhenOverThreshold = true;

		[FuseId]
		public string fuseId;

		public PortReferenceDefinition controllingPort = new PortReferenceDefinition(PortValueType.STATE, "CONTROLLING_PORT");

		public override SimComponent InstantiateImplementation()
		{
			return new FuseController(this);
		}
	}
}
