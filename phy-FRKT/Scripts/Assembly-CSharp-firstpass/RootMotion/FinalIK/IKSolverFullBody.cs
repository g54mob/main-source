using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverFullBody : IKSolver
	{
		[Range(0f, 10f)]
		public int iterations;

		public FBIKChain[] chain;

		public IKEffector[] effectors;

		public IKMappingSpine spineMapping;

		public IKMappingBone[] boneMappings;

		public IKMappingLimb[] limbMappings;

		public bool FABRIKPass;

		public UpdateDelegate OnPreRead;

		public UpdateDelegate OnPreSolve;

		public IterationDelegate OnPreIteration;

		public IterationDelegate OnPostIteration;

		public UpdateDelegate OnPreBend;

		public UpdateDelegate OnPostSolve;

		public UpdateDelegate OnStoreDefaultLocalState;

		public UpdateDelegate OnFixTransforms;

		public IKEffector kgj(Transform a)
		{
			return null;
		}

		public FBIKChain kgk(Transform a)
		{
			return null;
		}

		public int kgl(Transform a)
		{
			return 0;
		}

		public Node kgm(int a, int b)
		{
			return null;
		}

		public void kgn(Transform a, out int b, out int c)
		{
			b = default(int);
			c = default(int);
		}

		public override Point[] kel()
		{
			return null;
		}

		public override Point kem(Transform a)
		{
			return null;
		}

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

		protected override void keq()
		{
		}

		protected virtual void kgo()
		{
		}

		protected virtual void kgp()
		{
		}

		protected virtual void kgq()
		{
		}

		protected virtual void kgr()
		{
		}
	}
}
