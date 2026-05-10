using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class FBIKChain
	{
		[Serializable]
		public class ChildConstraint
		{
			public float pushElasticity;

			public float pullElasticity;

			[SerializeField]
			private Transform bone1;

			[SerializeField]
			private Transform bone2;

			private float tpf;

			private float tpg;

			private int tph;

			private int tpi;

			public float tpd
			{
				[CompilerGenerated]
				get
				{
					return 0f;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public bool tpe
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

			public ChildConstraint(Transform bone1, Transform bone2, float pushElasticity = 0f, float pullElasticity = 0f)
			{
			}

			public void kaa(IKSolverFullBody a)
			{
			}

			public void kab(IKSolverFullBody a)
			{
			}

			public void kac(IKSolverFullBody a)
			{
			}
		}

		[Serializable]
		public enum Smoothing
		{
			None = 0,
			Exponential = 1,
			Cubic = 2
		}

		[Range(0f, 1f)]
		public float pin;

		[Range(0f, 1f)]
		public float pull;

		[Range(0f, 1f)]
		public float push;

		[Range(-1f, 1f)]
		public float pushParent;

		[Range(0f, 1f)]
		public float reach;

		public Smoothing reachSmoothing;

		public Smoothing pushSmoothing;

		public IKSolver.Node[] nodes;

		public int[] children;

		public ChildConstraint[] childConstraints;

		public IKConstraintBend bendConstraint;

		private float tpj;

		private bool tpk;

		private float tpl;

		private float tpm;

		private IKSolver.Point tpn;

		private float tpo;

		private float tpp;

		private float[] tpq;

		private float tpr;

		private float tps;

		private float tpt;

		private const float tpu = 0.99999f;

		public FBIKChain()
		{
		}

		public FBIKChain(float pin, float pull, params Transform[] nodeTransforms)
		{
		}

		public void kad(params Transform[] boneTransforms)
		{
		}

		public int kae(Transform a)
		{
			return 0;
		}

		public bool kaf(ref string a)
		{
			return false;
		}

		public void kag(IKSolverFullBody a)
		{
		}

		public void kah(IKSolverFullBody a, bool b)
		{
		}

		private void kai(IKSolverFullBody a)
		{
		}

		public void kaj(IKSolverFullBody a)
		{
		}

		public Vector3 kak(IKSolverFullBody a)
		{
			return default(Vector3);
		}

		public void kal(IKSolverFullBody a, bool b = false)
		{
		}

		public void kam(IKSolverFullBody a)
		{
		}

		public void kan(IKSolverFullBody a, Vector3 b)
		{
		}

		public void kao(IKSolverFullBody a)
		{
		}

		private Vector3 kap(Vector3 a, Vector3 b, float c)
		{
			return default(Vector3);
		}

		protected Vector3 kaq(Vector3 a, Vector3 b, float c)
		{
			return default(Vector3);
		}

		private void kar(IKSolverFullBody a)
		{
		}

		private void kas(IKSolver.Node a, IKSolver.Node b, float c, float d)
		{
		}

		public void kat(Vector3 a)
		{
		}

		private void kau(Vector3 a)
		{
		}
	}
}
