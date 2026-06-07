using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverLookAt : IKSolver
	{
		[Serializable]
		public class LookAtBone : Bone
		{
			public Vector3 baseForwardOffsetEuler;

			public Vector3 xrf => default(Vector3);

			public LookAtBone()
			{
			}

			public LookAtBone(Transform transform)
			{
			}

			public void kjb(Transform a)
			{
			}

			public void kjc(Vector3 a, float b)
			{
			}
		}

		public Transform target;

		public LookAtBone[] spine;

		public LookAtBone head;

		public LookAtBone[] eyes;

		[Range(0f, 1f)]
		public float bodyWeight;

		[Range(0f, 1f)]
		public float headWeight;

		[Range(0f, 1f)]
		public float eyesWeight;

		[Range(0f, 1f)]
		public float clampWeight;

		[Range(0f, 1f)]
		public float clampWeightHead;

		[Range(0f, 1f)]
		public float clampWeightEyes;

		[Range(0f, 2f)]
		public int clampSmoothing;

		public AnimationCurve spineWeightCurve;

		public Vector3 spineTargetOffset;

		protected Vector3[] tsx;

		protected Vector3[] tsy;

		protected Vector3[] tsz;

		private bool tta;

		protected bool xrg => false;

		protected bool xrh => false;

		protected bool xri => false;

		protected bool xrj => false;

		protected bool xrk => false;

		protected bool xrl => false;

		public void kje(float a)
		{
		}

		public void kjf(float a, float b)
		{
		}

		public void kjg(float a, float b, float c)
		{
		}

		public void kjh(float a, float b, float c, float d)
		{
		}

		public void kji(float a, float b, float c, float d, float e)
		{
		}

		public void kjj(float a, float b = 0f, float c = 1f, float d = 0.5f, float e = 0.5f, float f = 0.5f, float g = 0.3f)
		{
		}

		public override void keo()
		{
		}

		public void kjk()
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

		public bool kjl(Transform[] a, Transform b, Transform[] c, Transform d)
		{
			return false;
		}

		protected override void kep()
		{
		}

		protected override void keq()
		{
		}

		protected void kjo()
		{
		}

		protected void kjr()
		{
		}

		protected void kju()
		{
		}

		protected Vector3[] kjv(ref Vector3[] a, Vector3 b, Vector3 c, int d, float e)
		{
			return null;
		}

		protected void kjw(Transform[] a, ref LookAtBone[] b)
		{
		}
	}
}
