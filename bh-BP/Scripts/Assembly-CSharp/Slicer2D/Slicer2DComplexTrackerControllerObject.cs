using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DComplexTrackerControllerObject : Slicer2DControllerObject
	{
		private List<Vector2D> pointsList;

		private ComplexSlicerTracker complexTracker;

		public Slicer2D.SliceType complexSliceType;

		public float minVertexDistance;

		public void Update(Vector2 pos)
		{
		}

		public void Draw(Transform transform)
		{
		}
	}
}
