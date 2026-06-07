using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class BarrelMetadataSaveData
	{
		public int state;

		public int beverageType;

		public double fermentationStartTime;

		public double agingStartTime;

		public int remainingBottles;

		public float effectiveFermentationDuration;

		public float effectiveAgingDuration;

		public float effectiveSpoilDuration;

		public double spoilStartTime;

		public double serverTimeAtSave;
	}
}
