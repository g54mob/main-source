using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bnl : bnx
{
	[Serializable]
	public class Body
	{
		[Serializable]
		public class EffectorLink
		{
			public FullBodyBipedEffector effector;

			public float weight;
		}

		public Transform transform;

		public Transform relativeTo;

		public EffectorLink[] effectorLinks;

		public float verticalWeight;

		public float horizontalWeight;

		public float speed;

		private Vector3 udw;

		private Vector3 udx;

		private bool udy;

		public void kzl(IKSolverFullBodyBiped a, float b, float c)
		{
		}

		private static Vector3 kzm(Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}
	}

	public Body[] bodies;

	protected override void kzn()
	{
	}
}
