using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKMappingLimb : IKMapping
	{
		[Serializable]
		public enum BoneMapType
		{
			Parent = 0,
			Bone1 = 1,
			Bone2 = 2,
			Bone3 = 3
		}

		public Transform parentBone;

		public Transform bone1;

		public Transform bone2;

		public Transform bone3;

		[Range(0f, 1f)]
		public float maintainRotationWeight;

		[Range(0f, 1f)]
		public float weight;

		[NonSerialized]
		public bool updatePlaneRotations;

		private BoneMap trg;

		private BoneMap trh;

		private BoneMap tri;

		private BoneMap trj;

		public override bool kcq(IKSolver a, ref string b)
		{
			return false;
		}

		public BoneMap kcy(BoneMapType a)
		{
			return null;
		}

		public void kcz(Vector3 a, Vector3 b)
		{
		}

		public IKMappingLimb()
		{
		}

		public IKMappingLimb(Transform bone1, Transform bone2, Transform bone3, Transform parentBone = null)
		{
		}

		public void kda(Transform a, Transform b, Transform c, Transform d = null)
		{
		}

		public void kdb()
		{
		}

		public void kdc()
		{
		}

		public override void kcr(IKSolverFullBody a)
		{
		}

		public void kdd()
		{
		}

		public void kde(IKSolverFullBody a, bool b)
		{
		}
	}
}
