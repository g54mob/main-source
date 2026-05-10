using System;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

public class bmo : IK
{
	[Serializable]
	public class References
	{
		public Transform root;

		[LargeHeader("Spine")]
		public Transform pelvis;

		public Transform spine;

		public Transform chest;

		public Transform neck;

		public Transform head;

		[LargeHeader("Left Arm")]
		public Transform leftShoulder;

		public Transform leftUpperArm;

		public Transform leftForearm;

		public Transform leftHand;

		[LargeHeader("Right Arm")]
		public Transform rightShoulder;

		public Transform rightUpperArm;

		public Transform rightForearm;

		public Transform rightHand;

		[LargeHeader("Left Leg")]
		public Transform leftThigh;

		public Transform leftCalf;

		public Transform leftFoot;

		public Transform leftToes;

		[LargeHeader("Right Leg")]
		public Transform rightThigh;

		public Transform rightCalf;

		public Transform rightFoot;

		public Transform rightToes;

		public bool xpz => false;

		public bool xqa => false;

		public References()
		{
		}

		public References(BipedReferences b)
		{
		}

		public Transform[] jyw()
		{
			return null;
		}

		public static bool jyz(Transform a, out References b)
		{
			b = null;
			return false;
		}
	}

	public References references;

	public IKSolverVR solver;

	protected override void jxp()
	{
	}

	protected override void jxq()
	{
	}

	private void jza()
	{
	}

	public void jzb()
	{
	}

	public void jzc()
	{
	}

	public override IKSolver jxu()
	{
		return null;
	}

	protected override void jqh()
	{
	}

	protected override void jqi()
	{
	}
}
