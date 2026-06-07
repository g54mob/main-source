using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverHeuristic : IKSolver
	{
		public Transform target;

		public float tolerance;

		public int maxIterations;

		public bool useRotationLimits;

		public bool XY;

		public Bone[] bones;

		protected Vector3 tsi;

		protected float tsj;

		protected virtual int xqh => 0;

		protected virtual bool xqj => false;

		protected virtual bool xrc => false;

		protected virtual Vector3 xqi => default(Vector3);

		protected float xrd => 0f;

		public bool kih(Transform[] a, Transform b)
		{
			return false;
		}

		public void kii(Transform a)
		{
		}

		public override void keo()
		{
		}

		public override void ken()
		{
		}

		public override bool keb(ref string a)
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

		protected override void kep()
		{
		}

		protected override void keq()
		{
		}

		protected void kik()
		{
		}

		protected Vector3 kim()
		{
			return default(Vector3);
		}

		private bool kin()
		{
			return false;
		}
	}
}
