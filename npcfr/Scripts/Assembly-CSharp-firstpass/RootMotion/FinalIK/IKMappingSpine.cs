using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKMappingSpine : IKMapping
	{
		public Transform[] spineBones;

		public Transform leftUpperArmBone;

		public Transform rightUpperArmBone;

		public Transform leftThighBone;

		public Transform rightThighBone;

		[Range(1f, 3f)]
		public int iterations;

		[Range(0f, 1f)]
		public float twistWeight;

		private int trk;

		private BoneMap[] trl;

		private BoneMap trm;

		private BoneMap trn;

		private BoneMap tro;

		private BoneMap trp;

		private bool trq;

		public override bool kcq(IKSolver a, ref string b)
		{
			return false;
		}

		public IKMappingSpine()
		{
		}

		public IKMappingSpine(Transform[] spineBones, Transform leftUpperArmBone, Transform rightUpperArmBone, Transform leftThighBone, Transform rightThighBone)
		{
		}

		public void kdf(Transform[] a, Transform b, Transform c, Transform d, Transform e)
		{
		}

		public void kdg()
		{
		}

		public void kdh()
		{
		}

		public override void kcr(IKSolverFullBody a)
		{
		}

		private bool kdi()
		{
			return false;
		}

		public void kdj()
		{
		}

		public void kdk(IKSolverFullBody a)
		{
		}

		public void kdl(Vector3 a)
		{
		}

		private void kdm(Vector3 a)
		{
		}

		private void kdn(IKSolverFullBody a)
		{
		}
	}
}
