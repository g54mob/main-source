using System.Collections.Generic;

namespace NSMedieval.DebugEvents
{
	public struct StateSnapshot
	{
		public long TimeMinutes;

		public string TimeDisplayText;

		public Dictionary<ushort, CreatureState> ShortIdToState;

		public StateSnapshot(long timeMinutes)
		{
			TimeMinutes = timeMinutes;
			ShortIdToState = new Dictionary<ushort, CreatureState>();
			TimeDisplayText = string.Empty;
		}

		public StateSnapshot Clone()
		{
			StateSnapshot result = this;
			result.ShortIdToState = new Dictionary<ushort, CreatureState>(ShortIdToState);
			return result;
		}
	}
}
