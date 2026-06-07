using System.Collections.Generic;

public class GraphSearch
{
	public class SearchVars
	{
		public float g_score;

		public float h_score;

		public float f_score;

		public UnitManager came_from;

		public bool isStart;

		public bool IsConnected()
		{
			return false;
		}

		public void Clear()
		{
		}

		public void PartialClear()
		{
		}
	}

	private class CompareUnits : IComparer<UnitManager>
	{
		private UnitManager start;

		public CompareUnits(UnitManager start)
		{
		}

		public int Compare(UnitManager x, UnitManager y)
		{
			return 0;
		}
	}

	private static HashSet<UnitManager> openHashSetForThread;

	private static HashSet<UnitManager> closedHashSetForThread;

	private static HashSet<UnitManager> openHashSetShared;

	private static HashSet<UnitManager> closedHashSetShared;

	public static List<UnitManager> GetShortestPathFromSearch(UnitManager start, UnitManager searchRoot)
	{
		return null;
	}

	public static void Search(UnitManager start, bool forThread = false)
	{
	}

	public static List<UnitManager> GetTravelPath(UnitManager start, UnitManager goal, bool allowSearchPath = true)
	{
		return null;
	}

	private static List<UnitManager> ReversePath(UnitManager place)
	{
		return null;
	}

	public static UnitManager Astar(UnitManager start, UnitManager goal)
	{
		return null;
	}

	private static void CleanUpNodes(HashSet<UnitManager> nodes)
	{
	}

	private static float Hfunc(UnitManager start, UnitManager goal)
	{
		return 0f;
	}
}
