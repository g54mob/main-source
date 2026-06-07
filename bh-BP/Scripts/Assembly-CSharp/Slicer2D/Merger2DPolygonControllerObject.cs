using System;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Merger2DPolygonControllerObject : Slicer2DControllerObject
	{
		public Polygon2D.PolygonType polygonType;

		public float polygonSize;

		public int edgeCount;

		public void Update(Vector2 pos)
		{
		}

		private void PolygonSlice(Vector2 pos)
		{
		}

		public void Draw(Transform transform)
		{
		}
	}
}
