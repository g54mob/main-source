using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	public class ShapeFill : MonoBehaviour
	{
		public int gridWidth;

		public int gridHeight;

		public List<Vector2D> pointsIn;

		private Polygon2D polygon;

		private Polygon2D polygon_world;

		public ShapeMovement movement;

		public bool visualisation;

		public bool guiInfo;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void OnGUI()
		{
		}

		public Polygon2D GetWorldPolygon()
		{
			return null;
		}

		public Polygon2D GetPolygon()
		{
			return null;
		}
	}
}
