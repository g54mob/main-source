using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DComplexClickControllerObject : Slicer2DControllerObject
	{
		private List<Vector2D> pointsList;

		public Slicer2D.SliceType complexSliceType;

		public int pointsLimit;

		public bool sliceJoints;

		public bool endSliceIfPossible;

		public bool addForce;

		public float addForceAmount;

		public void Update(Vector2 pos)
		{
		}

		private bool ComplexSlice(List<Vector2D> slice)
		{
			return false;
		}

		public void Draw(Transform transform)
		{
		}
	}
}
