using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public static class PatronPopulationObserver
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Invalidate()
		{
		}

		private static void MergeCloseRanges(List<(int startHour, int endHour)> activeNeeds)
		{
		}

		private static void EnsureGameEventsExist(string needType, List<(int startHour, int endHour)> ranges)
		{
		}
	}
}
