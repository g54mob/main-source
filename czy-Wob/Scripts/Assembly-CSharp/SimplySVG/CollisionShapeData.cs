using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class CollisionShapeData : ScriptableObject
	{
		[Serializable]
		public class Polygon
		{
			public List<Vector2> points;
		}

		public List<Polygon> collisionPolygons;

		public void Add(List<Vector2> polygon)
		{
			if (collisionPolygons == null)
			{
				collisionPolygons = new List<Polygon>();
			}
			collisionPolygons.Add(new Polygon
			{
				points = polygon
			});
		}

		public void Clear()
		{
			collisionPolygons.Clear();
		}
	}
}
