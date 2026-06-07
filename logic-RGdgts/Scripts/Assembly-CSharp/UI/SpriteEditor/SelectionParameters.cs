using System.Collections.Generic;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SelectionParameters
	{
		public readonly Vector2Int fullImageSize;

		public Vector2Int start;

		public Vector2Int end;

		public List<int> selectedPixelIndex;

		private SECoordinatesConverter convert;

		public SelectionParameters(Vector2Int start = default(Vector2Int), Vector2Int end = default(Vector2Int), List<int> selectedPixelIndex = null)
		{
		}

		public SelectionParameters()
		{
		}

		public void SetToImage()
		{
		}

		public void SetToFilter(SEFilter filter)
		{
		}

		public SelectionParameters GetCopy()
		{
			return null;
		}
	}
}
