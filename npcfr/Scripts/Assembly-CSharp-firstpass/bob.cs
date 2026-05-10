using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bob : bnx
{
	[Serializable]
	public class Avoider
	{
		[Serializable]
		public class EffectorLink
		{
			public FullBodyBipedEffector effector;

			public float weight;
		}

		public Transform[] raycastFrom;

		public Transform raycastTo;

		[Range(0f, 1f)]
		public float raycastRadius;

		public EffectorLink[] effectors;

		public float smoothTimeIn;

		public float smoothTimeOut;

		public LayerMask layers;

		private Vector3 ufs;

		private Vector3 uft;

		private Vector3 ufu;

		public void lch(IKSolverFullBodyBiped a, float b)
		{
		}

		private Vector3 lci(IKSolverFullBodyBiped a)
		{
			return default(Vector3);
		}

		private Vector3 lcj(Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}
	}

	public Avoider[] avoiders;

	protected override void kzn()
	{
	}
}
