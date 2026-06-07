using System;
using UnityEngine;

namespace VerletRope
{
	[Serializable]
	public struct Pin
	{
		public int pointIndex;

		public Vector3 pinLocalPos;

		public bool active;

		public Transform pinnedToTransform;

		public float addedBendingCorrection;
	}
}
