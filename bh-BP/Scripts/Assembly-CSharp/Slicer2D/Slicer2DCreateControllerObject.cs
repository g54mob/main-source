using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DCreateControllerObject : Slicer2DControllerObject
	{
		public enum CreateType
		{
			Slice = 0,
			PolygonType = 1
		}

		private List<Vector2D> pointsList;

		private Pair2D linearPair;

		public CreateType createType;

		public Polygon2D.PolygonType polygonType;

		public float polygonSize;

		public int edgeCount;

		public Material material;

		private float minVertexDistance;

		public void Update(Vector2 pos, Transform transform)
		{
		}

		private void CreatorSlice(List<Vector2D> slice, Transform transform)
		{
		}

		private void PolygonCreator(Vector2D pos, Transform transform)
		{
		}

		private void CreatePolygon(Polygon2D newPolygon, Transform transform)
		{
		}

		public void Draw(Transform transform)
		{
		}
	}
}
