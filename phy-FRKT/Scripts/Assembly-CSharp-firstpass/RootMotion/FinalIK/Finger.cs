using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class Finger
	{
		[Serializable]
		public enum DOF
		{
			One = 0,
			Three = 1
		}

		[Range(0f, 1f)]
		public float weight;

		[Range(0f, 1f)]
		public float rotationWeight;

		public DOF rotationDOF;

		public bool fixBone1Twist;

		public Transform bone1;

		public Transform bone2;

		public Transform bone3;

		public Transform tip;

		public Transform target;

		private IKSolverLimb tld;

		private Quaternion tle;

		private Vector3 tlf;

		private Quaternion tlg;

		private Vector3 tlh;

		private Vector3 tli;

		private Vector3 tlj;

		private Vector3 tlk;

		public bool tlc
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

		public Vector3 xpq
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion xpr
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public bool jtd(ref string a)
		{
			return false;
		}

		public void jte(Transform a, int b)
		{
		}

		public void jtf()
		{
		}

		public void jtg()
		{
		}

		public void jth(float a)
		{
		}
	}
}
