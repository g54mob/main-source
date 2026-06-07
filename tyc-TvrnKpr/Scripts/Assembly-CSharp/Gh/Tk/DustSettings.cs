using System;

namespace Gh.Tk
{
	[Serializable]
	public class DustSettings
	{
		public float MinGenerationInterval;

		public float MaxGenerationInterval;

		public float BaseGainPerMinute;

		public float PerActorPerMinute;

		public float PerLarderItemPerMinute;

		public float PerDirtPilePerMinute;

		public float PerPropWithCreatesDustTraitPerMinute;

		public float PropSpawnRadius;

		public float PropSpawnRadiusDeadZone;
	}
}
