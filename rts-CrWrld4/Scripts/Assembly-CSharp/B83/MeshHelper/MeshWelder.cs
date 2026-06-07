using System.Collections.Generic;
using UnityEngine;

namespace B83.MeshHelper
{
	public class MeshWelder
	{
		private Vertex[] vertices;

		private List<Vertex> newVerts;

		private int[] map;

		private EVertexAttribute m_Attributes;

		private Mesh m_Mesh;

		public float MaxUVDelta;

		public float MaxPositionDelta;

		public float MaxAngleDelta;

		public float MaxColorDelta;

		public float MaxBWeightDelta;

		public MeshWelder(Mesh aMesh)
		{
		}

		private bool HasAttr(EVertexAttribute aAttr)
		{
			return false;
		}

		private bool CompareColor(Color c1, Color c2)
		{
			return false;
		}

		private bool CompareBoneWeight(BoneWeight v1, BoneWeight v2)
		{
			return false;
		}

		private bool Compare(Vertex v1, Vertex v2)
		{
			return false;
		}

		private void CreateVertexList()
		{
		}

		private void RemoveDuplicates()
		{
		}

		private void AssignNewVertexArrays()
		{
		}

		private void RemapTriangles()
		{
		}

		public void Weld()
		{
		}
	}
}
