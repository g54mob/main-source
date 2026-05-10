using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverArm : IKSolver
	{
		[Range(0f, 1f)]
		public float IKRotationWeight;

		public Quaternion IKRotation;

		public Point chest;

		public Point shoulder;

		public Point upperArm;

		public Point forearm;

		public Point hand;

		public bool isLeft;

		public IKSolverVR.Arm arm;

		private Vector3[] trz;

		private Quaternion[] tsa;

		public override bool keb(ref string a)
		{
			return false;
		}

		public void kfe(float a)
		{
		}

		public bool kff(Transform a, Transform b, Transform c, Transform d, Transform e, Transform f)
		{
			return false;
		}

		public override Point[] kel()
		{
			return null;
		}

		public override Point kem(Transform a)
		{
			return null;
		}

		public override void keo()
		{
		}

		public override void ken()
		{
		}

		protected override void kep()
		{
		}

		protected override void keq()
		{
		}

		private void kfg()
		{
		}

		private void kfh()
		{
		}

		private void kfi()
		{
		}
	}
}
