using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class Traction : SimComponent
	{
		public readonly Port torqueIn;

		public readonly Port forwardSpeedExtIn;

		public readonly Port wheelRpmExtIn;

		public readonly Port wheelSpeedKmhExtIn;

		public Traction(TractionDefinition tDef)
			: base(tDef.ID)
		{
			torqueIn = AddPort(tDef.torqueIn);
			forwardSpeedExtIn = AddPort(tDef.forwardSpeedExtIn);
			wheelRpmExtIn = AddPort(tDef.wheelRpmExtIn);
			wheelSpeedKmhExtIn = AddPort(tDef.wheelSpeedKmhExtIn);
		}

		public override void Tick(float delta)
		{
		}
	}
}
