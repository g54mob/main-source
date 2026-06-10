using System;
using UnityEngine;

namespace UnityMeshSimplifier
{
	[Serializable]
	public struct BlendShapeFrame
	{
		public string shapeName;

		public float frameWeight;

		public Vector3[] deltaVertices;

		public Vector3[] deltaNormals;

		public Vector3[] deltaTangents;

		public int vertexOffset;

		public BlendShapeFrame(float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents)
		{
			shapeName = null;
			this.frameWeight = 0f;
			this.deltaVertices = null;
			this.deltaNormals = null;
			this.deltaTangents = null;
			vertexOffset = 0;
		}

		public BlendShapeFrame(string shapeName, float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents, int vertexOffset)
		{
			this.shapeName = null;
			this.frameWeight = 0f;
			this.deltaVertices = null;
			this.deltaNormals = null;
			this.deltaTangents = null;
			this.vertexOffset = 0;
		}
	}
}
