using System.Collections.Generic;
using UnityEngine;

namespace AmplifyImpostors
{
	public class Triangulator
	{
		private List<Vector2> m_points;

		public List<Vector2> Points => null;

		public Triangulator(Vector2[] points)
		{
		}

		public Triangulator(Vector2[] points, bool invertY = true)
		{
		}

		public int[] Triangulate()
		{
			return null;
		}

		private float Area()
		{
			return 0f;
		}

		private bool Snip(int u, int v, int w, int n, int[] V)
		{
			return false;
		}

		private bool InsideTriangle(Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3)
		{
			return false;
		}
	}
}
