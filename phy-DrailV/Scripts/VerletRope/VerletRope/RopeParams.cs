using System;
using UnityEngine;

namespace VerletRope
{
	[Serializable]
	public class RopeParams
	{
		public float ropeLength;

		public int numPoints;

		public Vector3 gravity;

		public float friction;

		public float floorLevel = float.NegativeInfinity;

		public float floorFriction = 0.5f;

		public float bendingCorrectionFactor;

		public float floorBendingScale = 0.1f;

		public int solverIterations;

		public Transform receiveForcesFrom;
	}
}
