using System;

namespace Assets.Scripts.Flight.Damage
{
	public class DamageThresholdEventArgs : EventArgs
	{
		public DamageThreshold NewThreshold { get; private set; }

		public int NewThresholdLevel { get; private set; }

		public DamageThreshold PreviousThreshold { get; private set; }

		public int PreviousThresholdLevel { get; private set; }

		public DamageThresholdEventArgs(int newLevel, DamageThreshold newThreshold, int previousLevel, DamageThreshold previousThreshold)
		{
			NewThresholdLevel = newLevel;
			NewThreshold = newThreshold;
			PreviousThresholdLevel = previousLevel;
			PreviousThreshold = previousThreshold;
		}
	}
}
