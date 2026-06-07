using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKConstraintBend
	{
		public Transform bone1;

		public Transform bone2;

		public Transform bone3;

		public Transform bendGoal;

		public Vector3 direction;

		public Quaternion rotationOffset;

		[Range(0f, 1f)]
		public float weight;

		public Vector3 defaultLocalDirection;

		public Vector3 defaultChildDirection;

		[NonSerialized]
		public float clampF;

		private int tpv;

		private int tpw;

		private int tpx;

		private int tpy;

		private int tpz;

		private int tqa;

		private bool tqc;

		public bool tqb
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool kav(IKSolverFullBody a, blv.Logger b)
		{
			return false;
		}

		public IKConstraintBend()
		{
		}

		public IKConstraintBend(Transform bone1, Transform bone2, Transform bone3)
		{
		}

		public void kay(Transform a, Transform b, Transform c)
		{
		}

		public void kaz(IKSolverFullBody a)
		{
		}

		public void kba(Vector3 a, Vector3 b, Vector3 c)
		{
		}

		public void kbb(float a, float b)
		{
		}

		public Vector3 kbc(IKSolverFullBody a)
		{
			return default(Vector3);
		}

		private Vector3 kbd(IKSolverFullBody a, Vector3 b)
		{
			return default(Vector3);
		}

		private Vector3 kbe(IKSolverFullBody a, Vector3 b)
		{
			return default(Vector3);
		}
	}
}
