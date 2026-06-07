using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class WaterDetector : SimComponent
	{
		public readonly Port stateExtIn;

		public WaterDetector(WaterDetectorDefinition oiDef)
			: base(oiDef.ID)
		{
			stateExtIn = AddPort(oiDef.stateExtIn);
		}

		public override void Tick(float delta)
		{
		}
	}
}
