using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class TransmissionFixedGear : SimComponent
	{
		public readonly float transmissionEfficiency;

		public readonly Port torqueIn;

		public readonly Port torqueOut;

		public readonly Port gearRatioReadOut;

		public TransmissionFixedGear(TransmissionFixedGearDefinition tfgDef)
			: base(tfgDef.ID)
		{
			transmissionEfficiency = tfgDef.transmissionEfficiency;
			torqueIn = AddPort(tfgDef.torqueIn);
			torqueOut = AddPort(tfgDef.torqueOut);
			gearRatioReadOut = AddPort(tfgDef.gearRatioReadOut, tfgDef.gearRatio);
		}

		public override void Tick(float delta)
		{
			torqueOut.Value = torqueIn.Value * gearRatioReadOut.Value * transmissionEfficiency;
		}
	}
}
