using System;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class MaterialSettings
	{
		public PolygonTriangulator2D.Triangulation triangulation;

		public Material material;

		public Material sideMaterial;

		public Vector2 scale;

		public Vector2 offset;

		public float depth;

		public bool batchMaterial;

		public MaterialSettings Copy()
		{
			return null;
		}

		public void CreateMesh(GameObject gameObject, Polygon2D polygon)
		{
		}

		public PolygonTriangulator2D.Triangulation GetTriangulation()
		{
			return default(PolygonTriangulator2D.Triangulation);
		}
	}
}
