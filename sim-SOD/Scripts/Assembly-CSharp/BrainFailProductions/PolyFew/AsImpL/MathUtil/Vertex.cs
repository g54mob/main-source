using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL.MathUtil
{
	public class Vertex
	{
		private Vertex prevVertex;

		private Vertex nextVertex;

		private float triangleArea;

		private bool triangleHasChanged;

		public Vector3 Position { get; private set; }

		public int OriginalIndex { get; private set; }

		public Vertex PreviousVertex
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vertex NextVertex
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float TriangleArea => 0f;

		public Vertex(int originalIndex, Vector3 position)
		{
		}

		public Vector2 GetPosOnPlane(Vector3 planeNormal)
		{
			return default(Vector2);
		}

		private void ComputeTriangleArea()
		{
		}
	}
}
