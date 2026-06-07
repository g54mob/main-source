using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public class Grid2D<T>
	{
		private Dictionary<Vector2Int, HashSet<T>> grid;

		private Vector2Int[] neighbourOffsets;

		public void Add(Vector2Int position, T value)
		{
		}

		private void GetAt(Vector2Int position, HashSet<T> result)
		{
		}

		public void GetWithNeighbours(Vector2Int position, HashSet<T> result)
		{
		}

		public void ClearNonAlloc()
		{
		}
	}
}
