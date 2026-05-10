using System.Collections.Generic;
using UnityEngine;

namespace MyBox
{
	[RequireComponent(typeof(PolygonCollider2D))]
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	public class ColliderToMesh : MonoBehaviour
	{
		private class Triangulator
		{
			private readonly List<Vector2> m_points;

			public Triangulator(Vector2[] points)
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

			private bool InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
			{
				return false;
			}
		}

		private void Start()
		{
		}

		[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
		public void FillShape()
		{
		}

		[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
		public void ClearShape()
		{
		}
	}
}
