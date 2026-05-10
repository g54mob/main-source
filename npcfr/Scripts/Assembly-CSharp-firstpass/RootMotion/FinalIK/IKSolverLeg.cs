using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverLeg : IKSolver
	{
		[Range(0f, 1f)]
		public float IKRotationWeight;

		public Quaternion IKRotation;

		public Point pelvis;

		public Point thigh;

		public Point calf;

		public Point foot;

		public Point toe;

		public IKSolverVR.Leg leg;

		public Vector3 heelOffset;

		private Vector3[] tsk;

		private Quaternion[] tsl;

		public override bool keb(ref string a)
		{
			return false;
		}

		public void kio(float a)
		{
		}

		public bool kip(Transform a, Transform b, Transform c, Transform d, Transform e, Transform f)
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

		private void kiq()
		{
		}

		private void kir()
		{
		}

		private void kis()
		{
		}
	}
}
