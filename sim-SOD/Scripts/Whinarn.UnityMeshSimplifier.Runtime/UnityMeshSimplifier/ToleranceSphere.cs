using System;
using UnityEngine;

namespace UnityMeshSimplifier
{
	[Serializable]
	public class ToleranceSphere
	{
		public Vector3 worldPosition;

		public Matrix4x4 localToWorldMatrix;

		public float diameter;

		public GameObject targetObject;

		public int currentEnclosedTrianglesCount;

		public float preservationStrength;

		public int initialEnclosedTrianglesCount { get; private set; }

		public int leastTrianglesCount { get; private set; }

		public void SetInitialEnclosedTrianglesCount(int initialCount)
		{
		}

		public ToleranceSphere()
		{
		}

		public ToleranceSphere(Vector3 worldPosition, Matrix4x4 localToWorldMatrix, float diameter, GameObject targetObject, float preservationStrength)
		{
		}
	}
}
