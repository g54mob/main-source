using System;

namespace Assets.Scripts.Rendering.Events
{
	public class LodLevelChangedEvent : EventArgs
	{
		public int LodLevel { get; }

		public LodScript LodScript { get; }

		public int PreviousLodLevel { get; }

		public LodLevelChangedEvent(LodScript lodScript, int previousLevel, int level)
		{
			LodScript = lodScript;
			PreviousLodLevel = previousLevel;
			LodLevel = level;
		}
	}
}
