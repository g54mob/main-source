using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Quest
{
	public static class QuestTargetRegistry
	{
		private static Dictionary<(string questId, int stepIndex), List<QuestTargetMarker>> markers;

		public static void Register(QuestTargetMarker marker)
		{
		}

		public static void Unregister(QuestTargetMarker marker)
		{
		}

		public static Transform GetTargetForStep(string questId, int stepIndex)
		{
			return null;
		}

		public static List<QuestTargetMarker> GetMarkersForStep(string questId, int stepIndex)
		{
			return null;
		}

		public static bool HasMarkersForStep(string questId, int stepIndex)
		{
			return false;
		}

		public static void Clear()
		{
		}

		public static int GetTotalMarkerCount()
		{
			return 0;
		}
	}
}
