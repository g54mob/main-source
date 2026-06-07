namespace LocoSim.Implementations
{
	public class SimGameParams
	{
		public bool DrivetrainFailuresAllowed { get; private set; }

		public bool OverheatingAllowed { get; private set; }

		public bool CompressorFailureAllowed { get; private set; }

		public float ResourceConsumptionModifier { get; private set; }

		public float SteamStartupMultiplier { get; private set; }

		public SimGameParams(bool drivetrainFailuresAllowed, bool overheatingAllowed, bool compressorFailureAllowed, float resourceConsumptionModifier, float steamStartupMultiplier)
		{
			OverrideGameParams(drivetrainFailuresAllowed, overheatingAllowed, compressorFailureAllowed, resourceConsumptionModifier, steamStartupMultiplier);
		}

		public void OverrideGameParams(bool drivetrainFailuresAllowed, bool overheatingAllowed, bool compressorFailureAllowed, float resourceConsumptionModifier, float steamStartupMultiplier)
		{
			DrivetrainFailuresAllowed = drivetrainFailuresAllowed;
			OverheatingAllowed = overheatingAllowed;
			CompressorFailureAllowed = compressorFailureAllowed;
			ResourceConsumptionModifier = resourceConsumptionModifier;
			SteamStartupMultiplier = steamStartupMultiplier;
		}
	}
}
