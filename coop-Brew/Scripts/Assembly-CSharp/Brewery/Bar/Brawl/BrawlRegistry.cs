using System.Collections.Generic;
using Brewery.NPC.Simple;
using UnityEngine;

namespace Brewery.Bar.Brawl
{
	public static class BrawlRegistry
	{
		private static HashSet<NPCBrawlAgent> allBrains;

		private static HashSet<NPCBrawlAgent> activeBrawlers;

		private static HashSet<NPCBrawlAgent> spectators;

		public static IReadOnlyCollection<NPCBrawlAgent> AllBrains => null;

		public static IReadOnlyCollection<NPCBrawlAgent> ActiveBrawlers => null;

		public static IReadOnlyCollection<NPCBrawlAgent> Spectators => null;

		public static int TotalBrainCount => 0;

		public static int ActiveBrawlerCount => 0;

		public static int SpectatorCount => 0;

		public static bool HasActiveBrawl => false;

		public static void RegisterBrain(NPCBrawlAgent brain)
		{
		}

		public static void UnregisterBrain(NPCBrawlAgent brain)
		{
		}

		public static void MarkActive(NPCBrawlAgent brain)
		{
		}

		public static void MarkInactive(NPCBrawlAgent brain)
		{
		}

		public static void MarkSpectator(NPCBrawlAgent brain)
		{
		}

		public static void UnmarkSpectator(NPCBrawlAgent brain)
		{
		}

		public static List<NPCBrawlAgent> GetActiveBrawlers()
		{
			return null;
		}

		public static List<NPCBrawlAgent> GetSpectators()
		{
			return null;
		}

		public static NPCBrawlAgent FindNearestActiveBrawler(Vector3 position, float maxRange, NPCBrawlAgent exclude = null)
		{
			return null;
		}

		public static List<NPCBrawlAgent> FindActiveBrawlersInRange(Vector3 position, float maxRange, NPCBrawlAgent exclude = null)
		{
			return null;
		}

		public static Vector3 GetBrawlCenter()
		{
			return default(Vector3);
		}

		public static NPCBrawlAgent FindBestTargetForJoiner(NPCBrawlAgent joiner, int maxAttackersPerTarget, BarBrawlManager coordinator)
		{
			return null;
		}

		private static bool IsValidTarget(NPCBrawlAgent target)
		{
			return false;
		}

		public static void Clear()
		{
		}

		public static string GetDebugSummary()
		{
			return null;
		}
	}
}
