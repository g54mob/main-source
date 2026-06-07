using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMABlendFrame
	{
		public float frameWeight;

		public Vector3[] deltaVertices;

		public Vector3[] deltaNormals;

		public Vector3[] deltaTangents;

		public UMABlendFrame()
		{
		}

		public UMABlendFrame(int vertexCount, bool hasNormals = true, bool hasTangents = true)
		{
		}

		public bool HasNormals()
		{
			return false;
		}

		public bool HasTangents()
		{
			return false;
		}

		public static bool isAllZero(Vector3[] deltas)
		{
			return false;
		}
	}
}
