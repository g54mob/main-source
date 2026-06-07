using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverAim : IKSolverHeuristic
	{
		public Transform transform;

		public Vector3 axis;

		public Vector3 poleAxis;

		public Vector3 polePosition;

		[Range(0f, 1f)]
		public float poleWeight;

		public Transform poleTarget;

		[Range(0f, 1f)]
		public float clampWeight;

		[Range(0f, 2f)]
		public int clampSmoothing;

		public IterationDelegate OnPreIteration;

		private float trv;

		private Vector3 trw;

		private bnd trx;

		private Transform @try;

		public Vector3 xqf => default(Vector3);

		public Vector3 xqg => default(Vector3);

		protected override int xqh => 0;

		protected override Vector3 xqi => default(Vector3);

		public float kev()
		{
			return 0f;
		}

		protected override void kep()
		{
		}

		protected override void keq()
		{
		}

		private void kfa()
		{
		}

		private Vector3 kfb()
		{
			return default(Vector3);
		}

		private void kfc(Vector3 a, Bone b, float c)
		{
		}
	}
}
