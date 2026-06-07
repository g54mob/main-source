using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DAnchor
	{
		public bool enable;

		public Collider2D[] anchorsList;

		public Slicer2D.AnchorType anchorType;

		public List<Polygon2D> anchorPolygons;

		public List<Collider2D> anchorColliders;

		public Slicer2DAnchor Copy()
		{
			return null;
		}

		public static Polygon2D GetPolygonInWorldSpace(Slicer2D slicer, Polygon2D poly)
		{
			return null;
		}

		public static bool OnAnchorSlice(Slicer2D slicer, Slice2D sliceResult)
		{
			return false;
		}

		public static void OnAnchorSliceResult(Slicer2D slicer, Slice2D sliceResult)
		{
		}
	}
}
