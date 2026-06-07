using System;

namespace Assets.Scripts.Flight.Events
{
	public class SeaLevelChangedEventArgs : EventArgs
	{
		public float? NewSeaLevel { get; private set; }

		public float? OldSeaLevel { get; private set; }

		public SeaLevelChangedEventArgs(float? oldSeaLevel, float? newSeaLevel)
		{
			OldSeaLevel = oldSeaLevel;
			NewSeaLevel = newSeaLevel;
		}
	}
}
