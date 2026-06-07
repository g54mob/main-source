using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKMapping
	{
		[Serializable]
		public class BoneMap
		{
			public Transform transform;

			public int chainIndex;

			public int nodeIndex;

			public Vector3 defaultLocalPosition;

			public Quaternion defaultLocalRotation;

			public Vector3 localSwingAxis;

			public Vector3 localTwistAxis;

			public Vector3 planePosition;

			public Vector3 ikPosition;

			public Quaternion defaultLocalTargetRotation;

			private Quaternion tqv;

			public float length;

			public Quaternion animatedRotation;

			private Transform tqw;

			private Transform tqx;

			private Transform tqy;

			private int tqz;

			private int tra;

			private int trb;

			private int trc;

			private int trd;

			private int tre;

			public Vector3 xqb => default(Vector3);

			public bool xqc => false;

			private Quaternion xqd => default(Quaternion);

			public void kbs(Transform a, IKSolverFullBody b)
			{
			}

			public void kbu()
			{
			}

			public void kbv(bool a)
			{
			}

			public void kbx(BoneMap a)
			{
			}

			public void kby(BoneMap a)
			{
			}

			public void kbz(BoneMap a, BoneMap b)
			{
			}

			public void kca(Vector3 a, Vector3 b)
			{
			}

			public void kcb(IKSolverFullBody a, Transform b, Transform c, Transform d)
			{
			}

			public void kcc(bool a, bool b)
			{
			}

			public void kcd()
			{
			}

			public void kce()
			{
			}

			public void kcf()
			{
			}

			public void kcg(IKSolverFullBody a, float b, IKSolver.Node c = null)
			{
			}

			public Vector3 kch(IKSolverFullBody a)
			{
				return default(Vector3);
			}

			public void kci(IKSolverFullBody a)
			{
			}

			public void kcj(IKSolverFullBody a, float b)
			{
			}

			public void kck(Vector3 a, float b)
			{
			}

			public void kcl(Vector3 a, Vector3 b, float c)
			{
			}

			public void Twist(Vector3 twistDirection, Vector3 normalDirection, float weight)
			{
			}

			public void kcm(float a)
			{
			}

			public void kcn(IKSolverFullBody a, float b)
			{
			}

			private Quaternion kco(IKSolverFullBody a)
			{
				return default(Quaternion);
			}
		}

		public virtual bool kcq(IKSolver a, ref string b)
		{
			return false;
		}

		public virtual void kcr(IKSolverFullBody a)
		{
		}

		protected bool kcs(Transform a, IKSolver b, ref string c, blv.Logger d = null)
		{
			return false;
		}

		protected Vector3 kct(Vector3 a, Vector3 b, float c)
		{
			return default(Vector3);
		}
	}
}
