using System;
using System.Collections.Generic;
using UnityEngine;

namespace SuperTiled2Unity
{
	public class SuperColliderComponent : MonoBehaviour
	{
		[Serializable]
		public class Shape
		{
			public Vector2[] m_Points;
		}

		public List<Shape> m_PolygonShapes;

		public List<Shape> m_OutlineShapes;
	}
}
