using System.Collections.Generic;
using Brewery.NPC.Data;
using Brewery.Stand;

namespace Brewery.NPC.Simple
{
	public static class NPCRegistry
	{
		private static List<SimpleNPCController> activeNPCs;

		public static List<SimpleBarLocation> AllBars { get; }

		public static List<StandLocation> AllStands { get; }

		public static List<SimpleHotspot> TownHotspots { get; }

		public static void RegisterNPC(SimpleNPCController npc)
		{
		}

		public static void UnregisterNPC(SimpleNPCController npc)
		{
		}

		public static List<SimpleNPCController> GetActiveNPCs()
		{
			return null;
		}

		public static NPCProfile GetProfileByNpcId(string npcId)
		{
			return null;
		}

		public static void RegisterBar(SimpleBarLocation barLocation)
		{
		}

		public static void UnregisterBar(SimpleBarLocation barLocation)
		{
		}

		public static void RegisterStand(StandLocation standLocation)
		{
		}

		public static void UnregisterStand(StandLocation standLocation)
		{
		}

		public static void RegisterHotspot(SimpleHotspot hotspot)
		{
		}

		public static void UnregisterHotspot(SimpleHotspot hotspot)
		{
		}

		public static void ForceAllToBar()
		{
		}

		public static void ForceAllHome()
		{
		}

		public static void ClearAll()
		{
		}
	}
}
