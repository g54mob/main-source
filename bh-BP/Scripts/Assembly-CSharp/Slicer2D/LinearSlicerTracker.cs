using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	public class LinearSlicerTracker
	{
		public Dictionary<Slicer2D, SlicerTrackerObject> trackerList;

		public void Update(Vector2 position, float minVertexDistance = 1f)
		{
		}

		public void CopyTracker(Slice2D slice, Slicer2D slicer)
		{
		}
	}
}
