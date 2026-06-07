using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverFABRIKRoot : IKSolver
	{
		public int iterations;

		[Range(0f, 1f)]
		public float rootPin;

		public FABRIKChain[] chains;

		private bool tsd;

		private bool[] tse;

		private Vector3 tsf;

		public override bool keb(ref string a)
		{
			return false;
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

		private bool kgg(int a)
		{
			return false;
		}

		protected override void keq()
		{
		}

		public override Point[] kel()
		{
			return null;
		}

		public override Point kem(Transform a)
		{
			return null;
		}

		private void kgh(ref Point[] a, FABRIKChain b)
		{
		}

		private Vector3 kgi()
		{
			return default(Vector3);
		}
	}
}
