using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKEffector
	{
		public Transform bone;

		public Transform target;

		[Range(0f, 1f)]
		public float positionWeight;

		[Range(0f, 1f)]
		public float rotationWeight;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 positionOffset;

		public bool effectChildNodes;

		[Range(0f, 1f)]
		public float maintainRelativePositionWeight;

		public Transform[] childBones;

		public Transform planeBone1;

		public Transform planeBone2;

		public Transform planeBone3;

		public Quaternion planeRotationOffset;

		private float tqe;

		private float tqf;

		private Vector3[] tqg;

		private bool tqh;

		private Quaternion tqi;

		private Vector3 tqj;

		private bool tqk;

		private int tql;

		private int tqm;

		private int tqn;

		private int tqo;

		private int tqp;

		private int tqq;

		private int tqr;

		private int tqs;

		private int[] tqt;

		private int[] tqu;

		public bool tqd
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

		public IKSolver.Node kbf(IKSolverFullBody a)
		{
			return null;
		}

		public void kbi(float a, float b)
		{
		}

		public IKEffector()
		{
		}

		public IKEffector(Transform bone, Transform[] childBones)
		{
		}

		public bool kbj(IKSolver a, ref string b)
		{
			return false;
		}

		public void kbk(IKSolverFullBody a)
		{
		}

		public void kbl(IKSolverFullBody a)
		{
		}

		public void kbm()
		{
		}

		public void kbn(IKSolverFullBody a)
		{
		}

		public void kbo()
		{
		}

		private Quaternion kbp(IKSolverFullBody a)
		{
			return default(Quaternion);
		}

		public void kbq(IKSolverFullBody a)
		{
		}

		private Vector3 kbr(IKSolverFullBody a, out Quaternion b)
		{
			b = default(Quaternion);
			return default(Vector3);
		}
	}
}
