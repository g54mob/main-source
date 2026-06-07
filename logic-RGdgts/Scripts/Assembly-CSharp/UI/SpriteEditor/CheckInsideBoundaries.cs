using System.Collections.Generic;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class CheckInsideBoundaries
	{
		public bool CheckInsideRectangularSelection(int x, int y, Vector2Int start, Vector2Int end)
		{
			return false;
		}

		public bool CheckInsideCircularSelection(int x, int y, Vector2Int centre, Vector2Int radius)
		{
			return false;
		}

		public bool CheckInsideFreeSelection(int x, int y)
		{
			return false;
		}

		public bool CheckInList(int x, int y, List<Vector2Int> coords)
		{
			return false;
		}

		public bool CheckInPixelIndexList(int pixel, List<int> pixelList)
		{
			return false;
		}

		public bool CheckInsideImage(int x, int y)
		{
			return false;
		}

		public bool CheckInsideFilter(int x, int y, SEFilter filter)
		{
			return false;
		}

		public bool CheckInsideBorder(int x, int y, List<Vector2Int> borderCoords)
		{
			return false;
		}
	}
}
