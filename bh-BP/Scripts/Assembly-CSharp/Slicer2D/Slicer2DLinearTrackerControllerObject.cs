using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DLinearTrackerControllerObject : Slicer2DControllerObject
	{
		private List<Vector2D> pointsList;

		public static LinearSlicerTracker linearTracker;

		private float minVertexDistance;

		public void Update(Vector2 pos)
		{
		}

		public void Draw(Transform transform)
		{
		}
	}
}
