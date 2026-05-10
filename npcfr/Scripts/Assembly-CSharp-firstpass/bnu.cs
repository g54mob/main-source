using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bnu : bnx
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

		public EffectorLink[] effectorLinks;

		public float speed;

		public float acceleration;

		[Range(0f, 1f)]
		public float matchVelocity;

		public float gravity;

		private Vector3 uey;

		private Vector3 uez;

		private Vector3 ufa;

		private Vector3 ufb;

		private bool ufc;

		public void lbg()
		{
		}

		public void lbh(IKSolverFullBodyBiped a, float b, float c)
		{
		}
	}

	public Body[] bodies;

	public OffsetLimits[] limits;

	public void hnf()
	{
	}

	public void ghv()
	{
	}

	public void lbi()
	{
	}

	public void fy()
	{
	}

	protected override void kzn()
	{
	}
}
