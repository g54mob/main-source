using System.Collections.Generic;
using NSMedieval.Goap;

namespace NSMedieval.DebugEvents
{
	public class DebugEventWindowModelContext
	{
		public readonly Dictionary<ushort, CreatureInfo> ShortIdToCreatureInfo = new Dictionary<ushort, CreatureInfo>();

		public readonly List<DebugEventWithTime> InputEvents = new List<DebugEventWithTime>();

		public readonly Dictionary<int, string> GoalHashToName;

		public StateSnapshot StateSnapshot;

		public Vec3Int MapSize;

		public DebugEventWindowModelContext()
		{
			GoalHashToName = new Dictionary<int, string>();
			foreach (string key in GoalsMap.Constuctors.Keys)
			{
				GoalHashToName[key.GetHashCode()] = key;
			}
		}
	}
}
