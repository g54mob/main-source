using LocoSim.Implementations;

namespace LocoSim.Definitions
{
	public class IndependentFusesDefinition : SimComponentDefinition
	{
		public FuseDefinition[] fuses;

		public bool saveState = true;

		public override SimComponent InstantiateImplementation()
		{
			return new IndependentFuses(this);
		}
	}
}
