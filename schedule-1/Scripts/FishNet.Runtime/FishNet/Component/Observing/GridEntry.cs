using System.Collections.Generic;
using UnityEngine;

namespace FishNet.Component.Observing
{
	public class GridEntry
	{
		public Vector2Int Position;

		public HashSet<GridEntry> NearbyEntries;

		public GridEntry()
		{
		}

		public GridEntry(HashSet<GridEntry> nearby)
		{
		}

		public void SetValues(Vector2Int position, HashSet<GridEntry> nearby)
		{
		}

		public void SetValues(HashSet<GridEntry> nearby)
		{
		}

		public void SetValues(Vector2Int position)
		{
		}

		public void Reset()
		{
		}
	}
}
