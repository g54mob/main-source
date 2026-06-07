namespace DV.Simulation.Brake
{
	public class BrakeGameParams
	{
		public float CompressorProductionModifier { get; private set; }

		public bool PressureLeakAllowed { get; private set; }

		public bool OverheatingAllowed { get; private set; }

		public BrakeGameParams(float compressorProductionModifier, bool pressureLeakAllowed, bool overheatingAllowed)
		{
			OverrideGameParams(compressorProductionModifier, pressureLeakAllowed, overheatingAllowed);
		}

		public void OverrideGameParams(float compressorProductionModifier, bool pressureLeakAllowed, bool overheatingAllowed)
		{
			CompressorProductionModifier = compressorProductionModifier;
			PressureLeakAllowed = pressureLeakAllowed;
			OverheatingAllowed = overheatingAllowed;
		}
	}
}
